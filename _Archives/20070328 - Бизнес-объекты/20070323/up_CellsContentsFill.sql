set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_CellsContentsFill]
	@nCellContentID		int = Null, -- код записи о содержимом ячейки
	@nCellID			int = Null, -- код записи о ячейки
	@nGoodID			int = Null, -- код товара
	@nPackingID			int = Null  -- код упаковки
AS
BEGIN

select	CC.ID, CC.ID as CellContentID, 
		CC.CellID, C.BarCode, C.BarCode as CellBarCode, 
		CC.OwnerID, Ow.Name as OwnerName, 
		CC.GoodStateID, GS.Name as GoodStateName, 
		C.State as CellState, 
		G.ID as GoodID, P.ID as PackingID, 
		G.BarCode as GoodBarCode, P.BarCode as PackingBarCode,
		G.Name as GoodName, G.Alias as GoodAlias, 
		G.Name + ': ' + cast(P.InBox as varchar(30)) as PackingName, 
		G.Retention, G.Weighting, 
		G.Netto, G.Brutto, 
		G.GoodGroupID, GG.Name as GoodGroupName, 
		G.GoodBrandID, GB.Name as GoodBrandName, 
		P.InBox, P.BoxInPal
	from CellsContents CC
	inner join Cells C on CC.CellID = C.ID
	left join Partners Ow on CC.OwnerID = OW.ID
	left join GoodsStates GS on CC.GoodStateID = GS.ID
	left join Packings P on CC.PackingID = P.Id 
	left join Goods G on P.GoodID = G.Id 
	left join GoodsGroups GG on G.GoodGroupID = GG.Id 
	left join GoodsBrands GB on G.GoodBrandID = GB.Id 
	where	(
			(@nCellContentID is not Null or @nCellID is not Null 
			) and 
			(@nCellContentID is Null or 
				CC.ID = @nCellContentID) and
			(@nCellID is Null or 
				C.ID = @nCellID) 
			)
		or 
			(
			  @nCellContentID is Null and @nCellID is Null and 
			 (@nGoodID is Null or 
				G.ID = @nGoodID) and 
			 (@nPackingID is Null or 
				P.ID = @nPackingID) 
			)
	order by C.BarCode, G.Alias, CC.ID

END
