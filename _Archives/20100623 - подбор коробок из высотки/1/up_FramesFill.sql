SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_FramesFill]
	@nID				int				= Null, 
	@cIDList			varchar(max)	= Null,	-- список Frames.ID (через ,)
	@cBarCode			varchar(100)	= Null,	-- штрих-код контейнера (последние цифры)
	@bActual			bit				= Null,	-- актуальные контейнеры?
	@bLocked			bit				= Null,	-- контейнеры блокированы?
	@bHasFrameContent	bit				= Null,	-- есть наполнение контейнера?
	@bStereo			bit				= Null,	-- не монотовар?
	@cOwnersList		varchar(max)	= Null,	-- список владельцев (через ,)
	@cGoodsStatesList	varchar(max)	= Null,	-- список состояний товара (через ,)
	@cFramesStatesStr	varchar(max)	= Null,	-- строка статусов контейнера
	-- параметры поиска контейнеров по содержимому
	@cPackingsList		varchar(max)	= Null,	-- список упаковок (через ,)
	@cGoodsList			varchar(max)	= Null,	-- список товаров (через ,)
	@dDateValidLess		smalldatetime	= Null,	-- срок годности (дата), не более
	@cCellsList			varchar(max)	= Null,	-- список ячеек (через ,)
	-- геометрия
	@nHeightBeg			numeric(10, 3)	= Null,	-- высота контейнера (м), от	
	@nHeightEnd			numeric(10, 3)	= Null,	-- высота контейнера (м), до
	@nWeightBeg			numeric(10, 3)	= Null,	-- вес контейнера (кг), от	
	@nWeightEnd			numeric(10, 3)	= Null,	-- вес контейнера (кг), до
	@cPalletsTypesList	varchar(max)	= Null,	-- список типов поддонов (через ,)
	-- последняя операция
	@dDateLastOperationBeg	smalldatetime	= Null, -- дата нач.периода
	@dDateLastOperationEnd	smalldatetime	= Null, -- дата кон.периода
	@nInputID			int				= Null -- ID прихода
AS

set nocount on

declare @cSelect varchar(max), @cFrom varchar(max), @cWhere varchar(max), @cOrderBy varchar(max)

-- содержимое контейнеров
select	FrameID, count(ID) as Cnt, min(CellID) as CellID  
	into	#CellsContents
	from	CellsContents with (nolock) 
	where   FrameID is not Null and	
			(@nID is Null or FrameID = IsNull(@nID, 0)) -- если нужен только один контейнер, то только его содержимое 
	group by FrameID
create index IX_CellsContents_FrameID on #CellsContents (FrameID)

-- для поиска по содержимому
declare @cExtraFramesList varchar(max)
select FrameID 
	into #FramesContents 
	from CellsContents with (nolock) 
	where 1 = 2
select CC.FrameID, CC.PackingID, 
		G.Alias as GoodAlias, P.InBox, G.Weighting, 
		CC.Qnt, 
		CC.Qnt / P.InBox as BoxQnt, 
		CC.DateValid 
	into #FramesContents_X
	from CellsContents CC with (nolock)
	inner join Packings P with (nolock) on CC.PackingID = P.ID
	inner join Goods G with (nolock) on P.GoodID = G.ID
	where 1 = 2 

if	@nID is Null and 
	(@cPackingsList is not Null or 
	 @cGoodsList is not Null or 
	 @dDateValidLess is not Null or 
	 @cCellsList is not Null or 
	 @bStereo = 0) begin
	set @cSelect = 	
	'insert #FramesContents (FrameID) 
		select  FrameID 
			from CellsContents CC with (nolock) 
			inner join Packings P with (nolock) on CC.PackingID = P.ID 
			inner join Goods G with (nolock) on P.GoodID = G.ID 
			inner join Frames F with (nolock) on CC.FrameID = F.ID '
	set @cWhere = 'where 1 = 1 '
	if @cPackingsList is not Null 
		set @cWhere = @cWhere + ' and CC.PackingID in (' + dbo._NormalizeList(@cPackingsList) + ') '
	if @cGoodsList is not Null
		set @cWhere = @cWhere + ' and P.GoodID in (' + dbo._NormalizeList(@cGoodsList) + ') '
	if @cCellsList is not Null
		set @cWhere = @cWhere + ' and CC.CellID in (' + dbo._NormalizeList(@cCellsList) + ') '
	if @dDateValidLess is not Null
		set @cWhere = @cWhere + ' and datediff(day, CC.DateValid, ''' + convert(varchar, @dDateValidLess, 112) + ''') >= 0 '
	set @cSelect = @cSelect + @cWhere 
	exec (@cSelect)

	create index IX_FramesContents_FrameID on #FramesContents (FrameID)

	set @cExtraFramesList = ''
	if exists (select top 1 FrameID from #FramesContents)
		select @cExtraFramesList = @cExtraFramesList + ltrim(str(FrameID)) + ',' 
			from #FramesContents
	else 
		set @cExtraFramesList = '0'

	-- для моноконтейнеров
	if @bStereo = 0 begin
		insert #FramesContents_X (FrameID, PackingID, 
				GoodAlias, InBox, Weighting, Qnt, BoxQnt, DateValid) 
			select CX.FrameID, CX.PackingID, 
					G.Alias, P.InBox, G.Weighting, 
					CX.Qnt, 
					CX.Qnt / P.InBox as BoxQnt, 
					CX.DateValid
				from (select CC.FrameID, CC.PackingID, sum(CC.Qnt) as Qnt, min(DateValid) as DateValid
						from CellsContents CC with (nolock)
						inner join #FramesContents FC on CC.FrameID = FC.FrameID 
						group by CC.FrameID, CC.PackingID
						having(count(PackingID)) = 1 ) CX
				inner join Packings P with (nolock) on CX.PackingID = P.ID
				inner join Goods G with (nolock) on P.GoodID = G.ID
		create index IX_FramesContents_X_FrameID on #FramesContents_X (FrameID)
	end 
end

-- итоговая выборка
set @cSelect = 
'select	F.ID, F.ID as FrameID, 
		F.BarCode, 
		F.DateBirth, F.DateLastOperation, 
		F.Actual, F.Locked, 
		F.State, F.HasTraffic, 
		dbo.IsFrameGoodsMono(F.ID) as GoodsMono, 
		F.FrameHeight, 
		dbo.GetFrameWeight(F.ID) as FrameWeight, 
		F.PalletTypeID, PT.Name as PalletTypeName, 
		F.OwnerID, Ow.Name as OwnerName, 
		F.GoodStateID, GS.Name as GoodStateName, 
		C.ID as CellID, C.Address as CellAddress, C.BarCode as CellBarCode, 
		C.StoreZoneID as StoreZoneID, SZ.Name as StoreZoneName, 
		SZ.StoreZoneTypeID as StoreZoneTypeID, SZT.Name as StoreZoneTypeName, SZT.ShortCode, 
		IsNull(CC.Cnt, 0) as FrameContentCnt, 
		cast(case when IsNull(CC.Cnt, 0) > 1 then 1 else 0 end as bit) as Stereo, 
		cast(case when IsNull(CC.Cnt, 0) > 0 then 1 else 0 end as bit) as HasFrameContent, 
		dbo.IsFullPallet(F.ID) as IsFullPallet,  
		cast(case when exists (select top 1 T.ID from TrafficsFrames T where T.FrameID = F.ID) then 1 else 0 end as bit) as HasTraffics, 
		cast(case when exists (select top 1 TNC.ID from TrafficsFrames TNC where TNC.FrameID = F.ID and TNC.DateConfirm is Null) then 1 else 0 end as bit) as HasNotConfirmedTraffics, 
		
		dbo.IsFrameHasTrafficsGoods(F.ID) as HasTrafficsGoods, 
		dbo.GetFrameQntInTrafficsGoods(F.ID) as QntInTrafficsGoods, 
		
		cast('''' as char(1)) as IsUsing, 
		FC_X.PackingID as Frames_PackingID, 
		FC_X.GoodAlias as Frames_GoodAlias, 
		FC_X.Weighting as Frames_Weighting, 
		FC_X.Qnt as Frames_Qnt, 
		FC_X.BoxQnt as Frames_BoxQnt, 
		FC_X.InBox as Frames_InBox, 
		FC_X.DateValid as Frames_DateValid, 
		dbo.GetFrameInputID(F.ID) as InputID ' 
set @cFrom = 
'from Frames F with (nolock) 
left join PalletsTypes PT with (nolock) on F.PalletTypeID = PT.ID 
left join Partners Ow with (nolock) on F.OwnerID = Ow.ID 
left join GoodsStates GS with (nolock) on F.GoodStateID = GS.ID 
left join #CellsContents CC on F.ID = CC.FrameID 
left join Cells C with (nolock) on CC.CellID = C.ID 
left join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
left join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID '

if @nID is not Null begin
	set @cWhere = ' where F.ID = ' + str(@nID)
	set @cFrom = @cFrom + 'left join #FramesContents_X FC_X on 1 = 1 '
end
else begin
	set @cWhere = ' where 1 = 1 '
	
	if @cIDList is not Null
		set @cWhere = @cWhere + ' and F.ID in (' + dbo._NormalizeList(@cIDList) + ') '
	
	if @cExtraFramesList is not Null
		set @cWhere = @cWhere + ' and F.ID in (' + dbo._NormalizeList(@cExtraFramesList) + ') '
	if @cBarCode is not Null
		--set @cWhere = @cWhere + ' and charindex(''' + @cBarCode + ''', F.BarCode) > 0 '
		set @cWhere = @cWhere + ' and right(F.BarCode, ' + ltrim(str(len(@cBarCode))) + ') = ''' + @cBarCode + ''' '
	if @bActual is not Null 
		set @cWhere = @cWhere + ' and F.Actual = ' + str(@bActual) + ' '
	if @bLocked is not Null
		set @cWhere = @cWhere + ' and F.Locked = ' + str(@bLocked) + ' ' 
	
	if @bHasFrameContent is not Null 
		set @cWhere = @cWhere + ' and IsNull(CC.Cnt, 0) ' + 
			(case when @bHasFrameContent = 1 then '>' else '=' end) + ' 0 '
	
	if @bStereo is not Null begin
		set @cWhere = @cWhere + ' and IsNull(CC.Cnt, 0) ' + 
			(case when @bStereo = 1 then '>' else '=' end) + ' 1 '
		-- для моноконтейнеров - доп.поля
		if @bStereo = 0 
			set @cFrom = @cFrom + 'inner join #FramesContents_X FC_X on F.ID = FC_X.FrameID '
		else
			set @cFrom = @cFrom + 'left join #FramesContents_X FC_X on 1 = 1 '
	end	
	else 
		set @cFrom = @cFrom + 'left join #FramesContents_X FC_X on 1 = 1 '
		
	if @cOwnersList is not Null
		set @cWhere = @cWhere + ' and F.OwnerID in (' + dbo._NormalizeList(@cOwnersList) + ') '
	if @cGoodsStatesList is not Null
		set @cWhere = @cWhere + ' and F.GoodStateID in (' + dbo._NormalizeList(@cGoodsStatesList) + ') '
	if @cFramesStatesStr is not Null
		set @cWhere = @cWhere + ' and charindex(F.State, ''' + @cFramesStatesStr + ''') > 0 '
	if @cPalletsTypesList is not Null
		set @cWhere = @cWhere + ' and F.PalletTypeID in (' + dbo._NormalizeList(@cPalletsTypesList) + ') '
	
	if @nHeightBeg is not Null
		set @cWhere = @cWhere + ' and F.FrameHeight >= ' + str(@nHeightBeg, 15, 3) + ' ' 
	if @nHeightEnd is not Null
		set @cWhere = @cWhere + ' and F.FrameHeight <= ' + str(@nHeightEnd, 15, 3) + ' ' 
	if @nWeightBeg is not Null
		set @cWhere = @cWhere + ' and dbo.GetFrameWeight(F.ID) >= ' + str(@nWeightBeg, 15, 3) + ' ' 
	if @nWeightEnd is not Null
		set @cWhere = @cWhere + ' and dbo.GetFrameWeight(F.ID) <= ' + str(@nWeightEnd, 15, 3) + ' '
	
	if @dDateLastOperationBeg is not Null
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateLastOperationBeg, 112) + ''', F.DateLastOperation) >= 0 '
	if @dDateLastOperationEnd is not Null
		set @cWhere = @cWhere + ' and datediff(day, F.DateLastOperation, ''' + convert(varchar, @dDateLastOperationEnd, 112) + ''') >= 0 '
	if @nInputID is not Null
		set @cWhere = @cWhere + ' and dbo.GetFrameInputID(F.ID) = ' + str(@nInputID) + ' '
end

set @cOrderBy = ' order by '
if @cIDList is not Null 
	set @cOrderBy = @cOrderBy + 'charindex('','' + ltrim(str(F.ID)) + '','', '',' + @cIDList + ',''), '
set @cOrderBy = @cOrderBy + 'F.BarCode'

set @cSelect = @cSelect + @cFrom + @cWhere + @cOrderBy
exec (@cSelect)
return