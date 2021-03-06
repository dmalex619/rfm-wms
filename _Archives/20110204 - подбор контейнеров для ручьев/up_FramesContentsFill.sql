SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_FramesContentsFill]
	@nFrameID			int = Null, -- код записи о контейнере
	@cPackingsList		varchar(MAX) = Null,  -- список упаковок (через ,)
	@cGoodsList			varchar(MAX) = Null,  -- список товаров (через ,)
	@dDateValidLess		smalldatetime = Null  -- срок годности (дата), не более 
AS

set nocount on

declare @cSelect varchar(max), @cWhere varchar(max), @cOrderBy varchar(max)

select CC.ID, 
		CC.CellID, CC.FrameID, CC.ByOrder,  
		CC.OwnerID, CC.GoodStateID, 
		CC.PackingID, P.GoodID, CC.DateValid, 
		CC.Qnt 
	into #CellsContentsX 
	from CellsContents CC with (nolock) 
	inner join Packings P with (nolock) on CC.PackingID = P.ID 
	where 1 = 2 

set @cSelect = 
'insert #CellsContentsX 
		(ID, CellID, FrameID, ByOrder,  
		OwnerID, GoodStateID, 
		PackingID, GoodID, DateValid, 
		Qnt) 
	select CC.ID, 
			CC.CellID, CC.FrameID, CC.ByOrder, 
			CC.OwnerID, CC.GoodStateID, 
			CC.PackingID, P.GoodID, CC.DateValid, 
			CC.Qnt 
		from CellsContents CC with (nolock) 
		inner join Frames F with (nolock) on CC.FrameID = F.ID 
		inner join Packings P with (nolock) on CC.PackingID = P.ID 
		inner join Goods G with (nolock) on P.GoodID = G.ID '
if @nFrameID is not Null
	set @cWhere = ' where CC.FrameID = ' + str(@nFrameID)
else begin
	set @cWhere = ' where 1 = 1 '
	if @cPackingsList is not Null 
		set @cWhere = @cWhere + ' and CC.PackingID in (' + dbo._NormalizeList(@cPackingsList) + ') '
	if @cGoodsList is not Null
		set @cWhere = @cWhere + ' and P.GoodID in (' + dbo._NormalizeList(@cGoodsList) + ') '
	if @dDateValidLess is not Null
		set @cWhere = @cWhere + ' and datediff(day, CC.DateValid, ''' + convert(varchar, @dDateValidLess, 112) + ''') >= 0 '
end
set @cSelect = @cSelect + @cWhere 
exec (@cSelect)

select  min(ID) as ID, 
		CellID, FrameID, min(ByOrder) as ByOrder, 
		OwnerID, GoodStateID, 
		PackingID, GoodID, DateValid, 
		sum(Qnt) as Qnt 
	into	#CellsContents 
	from	#CellsContentsX
	group by CellID, FrameID, 
			OwnerID, GoodStateID, 
			PackingID, GoodID, DateValid

select	CC.ID, 
		-- ячейка 
		CC.CellID, 
		C.BarCode as CellBarCode, C.Address, 
		C.State as CellState, 
		C.FixedOwnerID as CellFixedOwnerID, Fix_Ow.Name as CellFixedOwnerName, 
		C.FixedGoodStateID as CellFixedGoodStateID, Fix_GS.Name as CellFixedGoodStateName, 
		C.FixedPackingID as CellFixedPackingID, 
		-- контейнер
		CC.FrameID, 
		F.State as FrameState, 
		F.BarCode as FrameBarCode,  
		F.OwnerID, Ow_F.Name as FrameOwnerName, 
		F.GoodStateID, GS_F.Name as FrameGoodStateName, 
		-- содержимое 
		CC.OwnerID, Ow.Name as OwnerName, 
		CC.GoodStateID, GS.Name as GoodStateName, 
		CC.PackingID, CC.GoodID, 
		G.BarCode as GoodBarCode, P.BarCode as PackingBarCode,
		G.Name as GoodName, G.Alias as GoodAlias, 
		G.Articul, 
		G.Retention, G.Weighting, 
		G.Netto, G.Brutto, 
		G.GoodGroupID, GG.Name as GoodGroupName, 
		G.GoodBrandID, GB.Name as GoodBrandName, 
		P.InBox, P.BoxInPal, 
		CC.ByOrder, 
		CC.Qnt, 
		CC.Qnt / P.InBox as BoxQnt, 
		cast(CC.Qnt / P.InBox / P.BoxInPal as decimal(12, 4)) as PalQnt, 
		CC.DateValid
	from #CellsContents CC
	inner join Cells C with (nolock) on CC.CellID = C.ID
	left  join Partners Ow with (nolock) on CC.OwnerID = Ow.ID
	inner join GoodsStates GS with (nolock) on CC.GoodStateID = GS.ID
	left  join Frames F with (nolock) on CC.FrameID = F.ID
	left  join Partners Ow_F with (nolock) on F.OwnerID = Ow_F.ID
	left  join GoodsStates GS_F with (nolock) on F.GoodStateID = GS_F.ID
	left  join Partners Fix_Ow with (nolock) on C.FixedOwnerID = Fix_Ow.ID
	left  join GoodsStates Fix_GS with (nolock) on C.FixedGoodStateID = Fix_GS.ID
	left  join Packings Fix_P with (nolock) on C.FixedPackingID = Fix_P.ID 
	left  join Goods Fix_G with (nolock) on Fix_P.GoodID = Fix_G.ID 
	inner join Packings P with (nolock) on CC.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	inner join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	inner join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
	order by F.BarCode, G.Alias, CC.FrameID
return