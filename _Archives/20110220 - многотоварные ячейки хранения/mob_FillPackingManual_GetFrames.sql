SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mob_FillPackingManual_GetFrames]
	@nPackingID		int, 
	@nGoodStateID	int, 
	@nOwnerID		int
AS
-- Получение всех контейнеров в высотной зоне с заданным товаром, состоянием и владельцем

set nocount on

select	C.ID as CellSourceID, CC.FrameID, F.BarCode as FrameBarCode, 
		convert(varchar(10), CC.DateValid, 4) + ' (' + cast(cast(CC.Qnt / P.InBox as int) as varchar(10)) + ') ' + C.Address as CellAlias, 
		CC.DateValid, cast(CC.Qnt / P.InBox as int) as Boxes, C.Address as CellAddress  
	from Cells C with (nolock) 
	inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	inner join CellsContents CC with (nolock) on CC.CellID = C.ID 
	inner join Frames F with (nolock) on CC.FrameID = F.ID 
	inner join Packings P with (nolock) on CC.PackingID = P.ID 
	where	SZT.ShortCode = 'STOR' and F.Locked = 0 and 
			C.Deleted = 0 and C.Actual = 1 and C.Locked = 0 and 
			CC.PackingID = @nPackingID and CC.GoodStateID = @nGoodStateID and 
			((@nOwnerID is Null and CC.OwnerID is Null) or (IsNull(CC.OwnerID, -1) = IsNull(@nOwnerID, -1))) and 
			CC.Qnt > 0 and CC.FrameID not in 
				(select distinct FrameID 
					from TrafficsFrames with (nolock) where DateConfirm is Null) 
	order by CC.DateValid, CC.Qnt, C.Address
return