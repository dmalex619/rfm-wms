SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_TrafficsGoodsFill]
	@nID							int				= Null, 
	@cIDList						varchar(max)	= Null, -- список TrafficsGoods.ID (через ,) 
	--@cBarCode						varchar(100)	= Null, -- штрих-код документа-прихода (контекст), 
	@bConfirmed						bit				= Null, -- завершенные?
	@bSuccess						bit				= Null, -- успешно завершенные?
	@bCritical						bit				= Null, -- для поддержки транспортировок?
	@dDateBeg						smalldatetime	= Null, -- дата нач.периода (для DateBirth)
	@dDateEnd						smalldatetime	= Null, -- дата кон.периода (для DateBirth)
	@cUsersList						varchar(max)	= Null, -- список пользователей (через ,)
	@cDevicesList					varchar(max)	= Null, -- список устройств (через ,)
	@cCellsSourceList				varchar(max)	= Null, -- список ячеек-источников (через ,)
	@cCellsTargetList				varchar(max)	= Null, -- список ячеек-приемников (через ,)
	@cStoresZonesSourceList			varchar(max)	= Null, -- список складских зон-источников (через ,)
	@cStoresZonesTargetList			varchar(max)	= Null, -- список складских зон-приемников (через ,)
	@cStoresZonesTypesSourceList	varchar(max)	= Null, -- список типов складских зон-источников (через ,)
	@cStoresZonesTypesTargetList	varchar(max)	= Null,	-- список типов складских зон-приемников (через ,)
	@bPrinted						bit				= Null, -- напечатано?
	@cPackingsList					varchar(max)	= Null,	-- список упаковок (через ,)
	@cGoodsList						varchar(max)	= Null, -- список товаров (через ,)
	@cInputsList					varchar(max)	= Null, -- список ID приходов (через ,)
	@cOutputsList					varchar(max)	= Null, -- список ID расходов (через ,)
	@cMovingsList					varchar(max)	= Null, -- список ID перемещений (через ,)
	@cFramesList					varchar(max)	= Null  -- список ID контейнеров (через ,)
AS

-- exec up_TrafficsGoodsFill null, null, null, null, null, '20080808'
-- exec up_TrafficsGoodsFill @cOutputsList = '1846'

set nocount on

declare @cSelect varchar(max), @cWhere varchar(max), @cOrderBy varchar(max)

set @cSelect = '
select	T.ID, T.ID as TrafficID,
		
		T.CellSourceID, C_S.Address as CellSourceAddress, 
		C_S.CLine as CellSourceCLine, 
		C_S.BarCode as CellSourceBarCode, 
		C_S.StoreZoneID as StoreZoneSourceID, SZ_S.Name as StoreZoneSourceName, 
		SZ_S.StoreZoneTypeID as StoreZoneTypeSourceID, SZT_S.Name as StoreZoneTypeSourceName, SZT_S.ShortCode as StoreZoneTypeSourceShortCode, 
		C_S.BufferCellID as BufferCellSourceID, C_S_B.Address as BufferCellSourceAddress, 
		
		T.CellTargetID, C_T.Address as CellTargetAddress, 
		C_T.CLine as CellTargetCLine, 
		C_T.BarCode as CellTargetBarCode, 
		C_T.StoreZoneID as StoreZoneTargetID, SZ_T.Name as StoreZoneTargetName, 
		SZ_T.StoreZoneTypeID as StoreZoneTypeTargetID, SZT_T.Name as StoreZoneTypeTargetName, SZT_T.ShortCode as StoreZoneTypeTargetShortCode, 
		C_T.BufferCellID as BufferCellTargetID, C_T_B.Address as BufferCellTargetAddress, 
		C_S.Rank as CellSourceRank, 
		
		T.InputID, 
		I.ErpBarCode as InputBarCode, 
		T.OutputID, 
		O.ErpBarCode as OutputBarCode, O.ErpCode as OutputErpCode, 
		O.DateOutput, O.DateConfirm as OutputDateConfirm, O.Note as OutputNote, 
		T.MovingID, 
		
		T.Note, 
		
		T.Critical, T.Priority, T.ByOrder, 
		T.DateBirth, T.DateSend, T.DateAccept, T.DatePrint, 
		T.DateConfirm, 
		cast(case when T.DateConfirm is null then 0 else 1 end as bit) as IsConfirmed, 
		T.Success, 
		T.UserID, U.Name as UserName, 
		T.ErrorID, TE.Name as TrafficGoodErrorName, TE.Severity as TrafficGoodErrorSeverity, 
		T.OwnerID, Ow.Name as OwnerName, 
		T.GoodStateID, GS.Name as GoodStateName, 
		
		T.PackingID, P.InBox, P.BoxHeight,
		T.QntWished, 
		T.QntWished / P.InBox as BoxWished, 
		T.QntConfirmed, 
		T.QntConfirmed / P.InBox as BoxConfirmed, 
		floor(T.QntWished / P.InBox) as RestBoxWished, 
		T.QntWished - floor(T.QntWished / P.InBox) * P.InBox as RestQntWished, 
		floor(T.QntConfirmed / P.InBox) as RestBoxConfirmed, 
		T.QntConfirmed - floor(T.QntConfirmed / P.InBox) * P.InBox as RestQntConfirmed, 
		T.DateValid, 
		
		T.FrameID, 
		
		(case when T.OutputID is not Null 
				then dbo.GetTrafficsGoodsOutputsFramesInfo(T.ID) 
				else Null end) as TrafficsGoodsOutputsFramesInfo, 
		G.Alias as GoodAlias, G.Name as GoodName, 
		G.Alias + '' ('' + ltrim(str(P.InBox, 12, (case when G.Weighting = 1 then 3 else 0 end))) + '')'' as PackingAlias, 
		G.BarCode as GoodBarCode, 
		G.Articul, 
		G.Weighting, G.Retention, 
		GG.Name as GoodGroupName, GB.Name as GoodBrandName, 
		
		cast(case when T.DateConfirm is not null then T.QntConfirmed / P.InBox 
			 else case when T.Critical = 1 then 0 else T.QntWished / P.InBox end end as Decimal(12,3))
				as ForBoxConfirmed, 
		case when T.DateConfirm is not null then T.QntConfirmed 
			 else case when T.Critical = 1 then 0 else T.QntWished end end as ForQntConfirmed,
		cast(case when T.Critical = 1 then 0 else 1 end as bit) as Checked
		
	from TrafficsGoods T with (nolock) 
	
	inner join Cells C_S with (nolock) on T.CellSourceID = C_S.ID
	left  join Cells C_S_B with (nolock) on C_S.BufferCellID = C_S_B.ID
	inner join Cells C_T with (nolock) on T.CellTargetID = C_T.ID
	left  join Cells C_T_B with (nolock) on C_T.BufferCellID = C_T_B.ID
	
	inner join StoresZones SZ_S with (nolock) on C_S.StoreZoneID = SZ_S.ID
	inner join StoresZones SZ_T with (nolock) on C_T.StoreZoneID = SZ_T.ID
	inner join StoresZonesTypes SZT_S with (nolock) on SZ_S.StoreZoneTypeID = SZT_S.ID
	inner join StoresZonesTypes SZT_T with (nolock) on SZ_T.StoreZoneTypeID = SZT_T.ID
	
	left join TrafficsGoodsErrors TE with (nolock) on TE.ID = T.ErrorID
	
	left join _Users U with (nolock) on U.ID  = T.UserID
	
	left join Partners Ow with (nolock) on T.OwnerID = Ow.ID
	
	inner join GoodsStates GS with (nolock) on T.GoodStateID = GS.ID
	inner join Packings P with (nolock) on T.PackingID = P.ID
	inner join Goods G with (nolock) on P.GoodID = G.ID
	inner join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID
	inner join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID
	
	left join Inputs I with (nolock) on T.InputID = I.ID
	left join Outputs O with (nolock) on T.OutputID = O.ID '

if @nID is not Null
	set @cWhere = ' where T.ID = ' + str(@nID)
else begin
	set @cWhere = ' where 1 = 1 '
	
	-- Основная таблица
	if @cIDList is not Null
		set @cWhere = @cWhere + ' and T.ID in (' + dbo._NormalizeList(@cIDList) + ') '
	
	if @bConfirmed is not Null
		set @cWhere = @cWhere + ' and T.DateConfirm is ' + 
			case when @bConfirmed = 1 then 'not' else '' end + ' Null '
	
	if @bSuccess is not Null
		set @cWhere = @cWhere + ' and T.Success = ' + str(@bSuccess) + ' ' 
	
	if @bCritical is not Null
		set @cWhere = @cWhere + ' and T.Critical = ' + str(@bCritical) + ' ' 
	
	if @dDateBeg is not Null
		set @cWhere = @cWhere + ' and datediff(day, ''' + convert(varchar, @dDateBeg, 112) + ''', T.DateBirth) >= 0 '
	
	if @dDateEnd is not Null
		set @cWhere = @cWhere + ' and datediff(day, T.DateBirth, ''' + convert(varchar, @dDateEnd, 112) + ''') >= 0 '
	
	if @cUsersList is not Null
		set @cWhere = @cWhere + ' and T.UserID in (' + dbo._NormalizeList(@cUsersList) + ') '
	
	if @cCellsSourceList is not Null
		set @cWhere = @cWhere + ' and T.CellSourceID in (' + dbo._NormalizeList(@cCellsSourceList) + ') '
	
	if @cCellsTargetList is not Null
		set @cWhere = @cWhere + ' and T.CellTargetID in (' + dbo._NormalizeList(@cCellsTargetList) + ') '
	
	if @cStoresZonesSourceList is not Null
		set @cWhere = @cWhere + ' and C_S.StoreZoneID in (' + dbo._NormalizeList(@cStoresZonesSourceList) + ') '
	
	if @cStoresZonesTargetList is not Null
		set @cWhere = @cWhere + ' and C_T.StoreZoneID in (' + dbo._NormalizeList(@cStoresZonesTargetList) + ') '
	
	if @cStoresZonesTypesSourceList is not Null
		set @cWhere = @cWhere + ' and SZ_S.StoreZoneTypeID in (' + dbo._NormalizeList(@cStoresZonesTypesSourceList) + ') '
	
	if @cStoresZonesTypesTargetList is not Null
		set @cWhere = @cWhere + ' and SZ_T.StoreZoneTypeID in (' + dbo._NormalizeList(@cStoresZonesTypesTargetList) + ') '
	
	if @bPrinted is not Null
		set @cWhere = @cWhere + ' and T.DatePrint is ' + 
			case when @bPrinted = 1 then 'not' else '' end + ' Null '
	
	if @cPackingsList is not Null 
		set @cWhere = @cWhere + ' and T.PackingID in (' + dbo._NormalizeList(@cPackingsList) + ') '
	
	if @cGoodsList is not Null
		set @cWhere = @cWhere + ' and P.GoodID in (' + dbo._NormalizeList(@cGoodsList) + ') ' 
	
	if @cInputsList is not Null 
		set @cWhere = @cWhere + ' and T.InputID is not Null 
				and T.InputID in (' + dbo._NormalizeList(@cInputsList) + ') '
	
	if @cOutputsList is not Null 
		set @cWhere = @cWhere + ' and T.OutputID is not Null 
				and T.OutputID in (' + dbo._NormalizeList(@cOutputsList) + ') '
	
	if @cMovingsList is not Null 
		set @cWhere = @cWhere + ' and T.MovingID is not Null 
				and T.MovingID in (' + dbo._NormalizeList(@cMovingsList) + ') '
	
	if @cFramesList is not Null 
		set @cWhere = @cWhere + ' and T.FrameID is not Null 
				and T.FrameID in (' + dbo._NormalizeList(@cFramesList) + ') '
end

set @cOrderBy = ' order by '
if @cIDList is not Null 
	set @cOrderBy = @cOrderBy + ' charindex('','' + ltrim(str(T.ID)) + '','', '',' + dbo._NormalizeList(@cIDList) + ',''), '
set @cOrderBy = @cOrderBy + ' T.DateBirth, T.ID'

set @cSelect = @cSelect + @cWhere + @cOrderBy
exec (@cSelect)
return