set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_OutputsFramesFill]
	@nOutputID	int, 
	@nError		int = 0 output, 
	@cErrorText	varchar(200) = '' output 
-- получение списка контейнеров в расходе
AS

set nocount on

if	@nOutputID <> 0 and 
		not exists (select ID from Outputs where ID = IsNull(@nOutputID, 0)) begin 
	select	@nError = -1, 
			@cErrorText = 'Не найден расход с кодом ' + ltrim(str(@nOutputID)) + '...'
	raiserror(@cErrorText, 16, 1)
	return
end

create table #Frames (FrameID int)
-- подтвержденные контейнеры из составляющих расхода 
insert #Frames (FrameID)
	select distinct FrameID 
		from	OutputsItems with (nolock) 
		where	OutputID = IsNull(@nOutputID, 0) and FrameID is not Null
-- и еще подборанные контейнеры
insert #Frames (FrameID) 
	select distinct FrameID 
		from	TrafficsFrames with (nolock) 
		where	OutputID = IsNull(@nOutputID, 0) and 
				FrameID not in (select FrameID from #Frames)

select	F.ID, F.ID as FrameID, F.BarCode, 
		F.OwnerID, Ow.Name as OwnerName, 
		F.GoodStateID, GS.Name as GoodStateName, 
		F.DateBirth, F.DateLastOperation, 
		dbo.IsFrameGoodsMono(F.ID), 
		F.State, 
		F.Actual, 
		F.FrameHeight, dbo.GetFrameWeight(F.ID) as FrameWeight, 
		C.ID as CellID, C.Address as CellAddress, C.BarCode as CellBarCode, 
		C.StoreZoneID, SZ.Name as StoreZoneName, 
		SZ.StoreZoneTypeID, SZT.Name as StoreZoneTypeName, SZT.ShortCode, 
		CC.PackingID, P.GoodID, 
		P.InBox, P.BoxInPal, 
		G.Name as GoodName, G.Alias as GoodAlias, 
		G.Articul, 
		G.Weighting, 
		CC.Qnt, 
		CC.Qnt / P.InBox as BoxQnt, 
		cast(CC.Qnt / P.InBox / P.BoxInPal as decimal(12, 4)) as PalQnt, 
		CC.DateValid, 
		cast(case when exists (select top 1 T.ID from TrafficsFrames T where T.FrameID = F.ID) then 1 else 0 end as bit) as HasTraffics, 
		cast(case when exists (select top 1 TNC.ID from TrafficsFrames TNC where TNC.FrameID = F.ID and TNC.DateConfirm is Null) then 1 else 0 end as bit) as HasNotConfirmedTraffics 
 	from #Frames FX 
	inner join Frames F with (nolock) on FX.FrameID = F.ID 
	left  join Partners Ow with (nolock) on F.OwnerID = OW.ID 
	left  join GoodsStates GS with (nolock) on F.GoodStateID = GS.ID 
	left  join CellsContents CC with (nolock) on F.ID = CC.FrameID 
	left  join Cells C with (nolock) on CC.CellID = C.ID 
	left  join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	left  join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	left  join Packings P with (nolock) on CC.PackingID = P.ID 
	left  join Goods G with (nolock) on P.GoodID = G.ID 
return