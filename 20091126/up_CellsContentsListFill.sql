set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_CellsContentsListFill]
	@cCellsList varchar(MAX) = Null -- список ячеек (через ,)
AS

set nocount on

select ID * 1 as ID 
	into #Cells
	from Cells with (nolock)
	where 1 = 2
declare @cSelect varchar(max)
set @cSelect = '
insert #Cells (ID)
	select ID 
		from Cells with (nolock)
		where ID in (' + dbo._NormalizeList(@cCellsList) + ')'
exec (@cSelect)

select	IsNull(CC.ID, -C.ID) as ID, 
		-- ячейка 
		C.ID as CellID, 
		C.BarCode as CellBarCode, C.Address, C.Rank, 
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
		cast((case when F.ID is Null then Null else .dbo.GetFrameWeight(F.ID) end) as decimal(12, 3)) as FrameWeight, 
		CC.ByOrder, 
		CC.DateLastOperation,
		-- содержимое 
		CC.OwnerID, Ow.Name as OwnerName, 
		CC.GoodStateID, GS.Name as GoodStateName, 
		CC.Qnt, 
		CC.DateValid, convert(char(10), CC.DateValid, 104) as DateValidText, 
		CC.PackingID, P.GoodID, 
		
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
		cast(CC.Qnt / P.InBox / P.BoxInPal  as decimal(12, 4)) as PalQnt 
	
	from #Cells C_X
	inner join Cells C with (nolock) on C_X.ID = C.ID 
	
	left join CellsContents CC with (nolock) on C.ID = CC.CellID 
	left join Partners Ow with (nolock) on CC.OwnerID = Ow.ID 
	left join GoodsStates GS with (nolock) on CC.GoodStateID = GS.ID 
	
	left join Frames F with (nolock) on CC.FrameID = F.ID 
	left join Partners Ow_F with (nolock) on F.OwnerID = Ow_F.ID 
	left join GoodsStates GS_F with (nolock) on F.GoodStateID = GS_F.ID 
	
	left join Partners Fix_Ow with (nolock) on C.FixedOwnerID = Fix_Ow.ID 
	left join GoodsStates Fix_GS with (nolock) on C.FixedGoodStateID = Fix_GS.ID 
	left join Packings Fix_P with (nolock) on C.FixedPackingID = Fix_P.ID 
	left join Goods Fix_G with (nolock) on Fix_P.GoodID = Fix_G.ID 
	
	left join Packings P with (nolock) on CC.PackingID = P.ID 
	left join Goods G with (nolock) on P.GoodID = G.ID 
	left join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	left join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
	
	order by C.BarCode, G.Alias, CC.CellID
return