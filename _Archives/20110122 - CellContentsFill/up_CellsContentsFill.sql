SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_CellsContentsFill]
	@nCellID			int = Null,				-- код записи о ячейке
	@bGroup				bit = Null,				-- суммировать (ячейка, контейнер, товар, срок годности)
	@cOwnersList		varchar(MAX) = Null,	-- список владельцев (через ,)
	@cGoodsStatesList	varchar(MAX) = Null,	-- список состояний товара (через ,)
	@cPackingsList		varchar(MAX) = Null,	-- список упаковок (через ,)
	@cGoodsList			varchar(MAX) = Null,	-- список товаров (через ,)
	@cFramesList		varchar(MAX) = Null		-- список контейнеров (через ,)
AS

set nocount on

select	CC.ID, CC.CellID, CC.FrameID, CC.ByOrder, 
		CC.OwnerID, CC.GoodStateID, 
		CC.PackingID, P.GoodID, CC.Qnt, CC.DateValid, CC.DateLastOperation 
	into	#CellsContentsX 
	from	CellsContents CC with (nolock) 
	inner join Packings P with (nolock) on CC.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	where 1 = 2

declare @cSelect varchar(max), @cWhere varchar(max), @cOrderBy varchar(max)
set @cSelect = '
insert #CellsContentsX (ID, CellID, FrameID, ByOrder, 
		OwnerID, GoodStateID, PackingID, GoodID, Qnt, DateValid, DateLastOperation)  
	select	CC.ID, CC.CellID, CC.FrameID, CC.ByOrder, 
			CC.OwnerID, CC.GoodStateID, 
			CC.PackingID, P.GoodID, CC.Qnt, CC.DateValid, CC.DateLastOperation  
		from	CellsContents CC with (nolock) 
		inner join Packings P with (nolock) on CC.PackingID = P.ID 
		inner join Goods G with (nolock) on P.GoodID = G.ID '
if @nCellID is not Null 
	set @cWhere = ' where CC.CellID = ' + str(@nCellID)
else begin
	set @cWhere = ' where 1 = 1 '
	if @cOwnersList is not Null
		set @cWhere = @cWhere + ' and CC.OwnerID in (' + dbo._NormalizeList(@cOwnersList) + ') ' 
	if @cGoodsStatesList is not Null
		set @cWhere = @cWhere + ' and CC.GoodStateID in (' + dbo._NormalizeList(@cGoodsStatesList) + ') ' 
	if @cPackingsList is not Null
		set @cWhere = @cWhere + ' and CC.PackingID in (' + dbo._NormalizeList(@cPackingsList) + ') ' 
	if @cGoodsList is not Null
		set @cWhere = @cWhere + ' and P.GoodID in (' + dbo._NormalizeList(@cGoodsList) + ') ' 
	if @cFramesList is not Null
		set @cWhere = @cWhere + ' and CC.FrameID in (' + dbo._NormalizeList(@cFramesList) + ') ' 
end
set @cSelect = @cSelect + @cWhere
exec (@cSelect)

select	ID  + 1 - 1 as ID, CellID, FrameID, ByOrder, 
		OwnerID, GoodStateID, 
		PackingID, GoodID, DateValid, Qnt, DateLastOperation 
	into	#CellsContents 
	from	#CellsContentsX 
	where	1 = 2

if IsNull(@bGroup, 0) = 1 begin
	insert	#CellsContents 
			(ID, CellID, FrameID, ByOrder, 
			OwnerID, GoodStateID, 
			PackingID, GoodID, DateValid, 
			Qnt, DateLastOperation) 
		select  Null, CellID, FrameID, min(ByOrder), 
				OwnerID, GoodStateID, 
				PackingID, GoodID, DateValid, 
				sum(Qnt) as Qnt, Null
			from	#CellsContentsX 
			group by CellID, FrameID, 
					OwnerID, GoodStateID, 
					PackingID, GoodID, DateValid
end
else begin
	insert	#CellsContents 
			(ID, CellID, FrameID, ByOrder, 
			OwnerID, GoodStateID, 
			PackingID, GoodID, DateValid, 
			Qnt, DateLastOperation) 
		select  ID, CellID, FrameID, ByOrder, 
				OwnerID, GoodStateID, 
				PackingID, GoodID, DateValid, 
				Qnt, DateLastOperation 
			from	#CellsContentsX
end

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
		F.BarCode as FrameBarCode,  
		F.OwnerID as FrameOwnerID, Ow_F.Name as FrameOwnerName, 
		F.GoodStateID as FrameGoodStateID, GS_F.Name as FrameGoodStateName, 
		F.FrameHeight, 
		cast((case when CC.FrameID is Null then Null else .dbo.GetFrameWeight(CC.FrameID) end) as decimal(15, 3)) as FrameWeight, 
		CC.ByOrder, 
		CC.DateLastOperation,
		-- содержимое 
		CC.OwnerID, Ow.Name as OwnerName, 
		CC.GoodStateID, GS.Name as GoodStateName, 
		CC.Qnt, 
		CC.DateValid, 
		CC.PackingID, CC.GoodID, 
		
		G.ID as GoodID, P.ID as PackingID, 
		G.BarCode as GoodBarCode, P.BarCode as PackingBarCode, 
		G.Name as GoodName, G.Alias as GoodAlias, 
		G.Alias + ' (' + ltrim(str(P.InBox, 12, (case when G.Weighting = 1 then 3 else 0 end))) + ')' as PackingAlias, 
		cast(case	when G.Actual is Null or P.Actual is Null then Null 
					when G.Actual = 1 and P.Actual = 1 then 1 
					else 0 end as bit) as GoodAndPackingActual, 
		G.Articul, 
		G.Retention, G.Weighting, 
		G.Netto, G.Brutto, 
		G.GoodGroupID, GG.Name as GoodGroupName, 
		G.GoodBrandID, GB.Name as GoodBrandName, 
		P.InBox, P.BoxInPal, 
		CC.Qnt, CC.Qnt / P.InBox as BoxQnt, 
		cast(CC.Qnt / P.InBox / P.BoxInPal as decimal(12, 4)) as PalQnt, 
		(case when CC.DateValid is Null or G.Retention = 0 then Null 
			else datediff(day, getdate(), isNull(CC.DateValid, getdate())) * 100 / G.Retention 
			end) as DateValidPercent

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
	
	order by C.BarCode, G.Alias, CC.CellID
return