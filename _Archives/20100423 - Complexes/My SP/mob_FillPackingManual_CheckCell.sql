SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mob_FillPackingManual_CheckCell]
	@nCellID	int
AS
-- Получение данных о ячейке пикинга для ручной подпитки

set nocount on

select	SZT.ForPicking, C.FixedOwnerID, C.FixedGoodStateID, C.FixedPackingID, 
		C.Address, C.Locked, C.Actual, C.Deleted, 
		IsNull(G.Alias + ' (' + ltrim(str(P.InBox)) + ')', '') as FixedPackingName 
	from Cells C with (nolock) 
	inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	left join Packings P with (nolock) on C.FixedPackingID = P.ID 
	left join Goods G with (nolock) on P.GoodID = G.ID 
	where C.ID = @nCellID
return