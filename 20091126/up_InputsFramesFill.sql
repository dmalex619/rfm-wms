set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_InputsFramesFill]
	@nInputID	int, 
	@nError		int = 0 output, 
	@cErrorText	varchar(200) = '' output 
-- получение списка контейнеров в приходе
AS

set nocount on

if	@nInputID <> 0 and 
		not exists (select ID from Inputs where ID = IsNull(@nInputID, 0)) begin
	select	@nError = -1, 
			@cErrorText = 'Не найден приход с кодом ' + ltrim(str(@nInputID)) + '...'
	raiserror(@cErrorText, 16, 1)
	return
end

select	F.ID, F.ID as FrameID, F.BarCode, 
		F.OwnerID, Ow.Name as OwnerName, 
		F.GoodStateID, GS.Name as GoodStateName, 
		F.DateBirth, F.DateLastOperation, 
		dbo.IsFrameGoodsMono(F.ID) as GoodsMono, 
		F.State, 
		F.Actual, 
		F.FrameHeight, dbo.GetFrameWeight(F.ID) as FrameWeight, 
		F.PalletTypeID, PT.Name as PalletTypeName, 
		C.ID as CellID, C.Address as CellAddress, C.BarCode as CellBarCode, 
		C.StoreZoneID, SZ.Name as StoreZoneName, 
		SZ.StoreZoneTypeID, SZT.Name as StoreZoneTypeName, SZT.ShortCode, 
		CC.PackingID, P.GoodID, 
		P.InBox, P.BoxInPal, 
		G.Alias as GoodAlias, G.Name as GoodName, 
		G.BarCode as GoodBarCode, 
		G.Articul, 
		G.Weighting, G.Retention, 
		GG.Name as GoodGroupName, 
		GB.Name as GoodBrandName, 
		CC.Qnt, 
		CC.Qnt / P.InBox as BoxQnt, 
		cast(CC.Qnt / P.InBox / P.BoxInPal as decimal(12, 4)) as PalQnt, 
		CC.DateValid, 
		cast(case 
			when exists (select top 1 T.ID from TrafficsFrames T where T.FrameID = F.ID 
				and T.InputID = @nInputID) 
			then 1 
			else 0 end as bit) as HasTraffics, 
		cast(case 
			when exists (select top 1 TNC.ID from TrafficsFrames TNC where TNC.FrameID = F.ID 
				and TNC.InputID = @nInputID and TNC.DateConfirm is Null) 
			then 1 
			else 0 end as bit) as HasNotConfirmedTraffics 
 	from Frames F with (nolock) 
	inner join InputsItems II with (nolock) on II.FrameID = F.ID 
	left  join Partners Ow with (nolock) on F.OwnerID = OW.ID 
	inner join GoodsStates GS with (nolock) on F.GoodStateID = GS.ID 
	left  join PalletsTypes PT on F.PalletTypeID = PT.ID 
	inner join CellsContents CC with (nolock) on F.ID = CC.FrameID and CC.PAckingID = II.PackingID 
	inner join Cells C with (nolock) on CC.CellID = C.ID 
	inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	inner join Packings P with (nolock) on CC.PackingID = P.ID 
	inner join Goods G with (nolock) on P.GoodID = G.ID 
	inner join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	inner join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
	where II.InputID = IsNull(@nInputID, 0)
return