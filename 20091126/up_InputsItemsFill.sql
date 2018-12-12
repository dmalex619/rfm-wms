set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_InputsItemsFill]
	@nInputID	int, 
	@nError		int = 0 output, 
	@cErrorText	varchar(200) = '' output 
AS

set nocount on

if	@nInputID <> 0 and 
		not exists (select ID from Inputs where ID = IsNull(@nInputID, 0)) begin
	select	@nError = -1, 
			@cErrorText = 'Не найден приход с кодом ' + ltrim(str(@nInputID)) + '...'
	raiserror(@cErrorText, 11, 1);
	return
end

declare @nOwnerID int, @bSeparatePicking bit
select @nOwnerID = OwnerID 
	from Inputs with (nolock) 
	where ID = IsNull(@nInputID, 0)
select @bSeparatePicking = SeparatePicking 
	from Partners with (nolock) 
	where ID = IsNull(@nOwnerID, 0)
if @bSeparatePicking = 0 set @nOwnerID = Null

-- соотв. ячейки пикинга
select	ID as InputItemID, 
		.dbo.GetPackingPickingCellID(PackingID, @nOwnerID, GoodStateID) as CellID 
	into #TableCells 
	from InputsItems with (nolock) 
	where InputID = IsNull(@nInputID, 0)

-- итоговая выборка
select	II.ID as InputItemID, 
		II.DateConfirm, 
		cast((case when II.DateConfirm is Null then 0 else 1 end) as bit)as IsConfirmed, 
		II.PackingID, 
		II.Qnt, 
		II.Qnt / P.InBox as Boxes, 
		cast(II.Qnt / P.InBox / P.BoxInPal as decimal(12, 4)) as Pallets, 
		II.DateValid, 
		P.InBox, P.BoxHeight, 
		P.BoxInPal, P.BoxInRow, 
		
		II.FrameID, F.BarCode as FrameBarCode, 
		II.CellID, C.Address as CellAddress, C.BarCode as CellBarCode, 
		SZ.Name as StoreZoneName, SZT.Name as StoreZoneTypeName, 
		F.FrameHeight, .dbo.GetFrameWeight(F.ID) as FrameWeight, 
		GS.ID as GoodStateID, GS.Name as GoodStateName, 
		
		G.Alias as GoodAlias, G.Name as GoodName, 
		G.BarCode as GoodBarCode, 
		G.Articul, 
		G.Weighting, G.Retention, 
		GG.Name as GoodGroupName, 
		GB.Name as GoodBrandName, 
		
		C_P.ID as PickingCellID, C_P.Address as PickingCellAddress, 
		C_P.StoreZoneID as PickingStoreZoneID, SZ_P.Name as PickingStoreZoneName, 
		
		II.UserID, U.Name as UserName, 
		II.DeviceID, D.Name as DeviceName 
		
	from InputsItems II with (nolock) 
	left join Packings P with (nolock) on II.PackingID = P.ID 
	inner join Goods G with (nolock) on G.ID = P.GoodID 
	inner join GoodsStates GS with (nolock) on GS.ID = II.GoodStateID 
	left join Frames F with (nolock) on II.FrameID = F.ID 
	left join Cells C with (nolock) on II.CellID  = C.ID 
	left join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	left join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	left join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	left join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
	left join _Users U with (nolock) on II.UserID = U.ID 
	left join Devices D	with (nolock) on II.DeviceID = D.ID 
	
	left join #TableCells TX on II.ID = TX.InputItemID 
	left join Cells C_P with (nolock) on TX.CellID = C_P.ID
	left join StoresZones SZ_P with (nolock) on C_P.StoreZoneID = SZ_P.ID 
	
	where II.InputID = IsNull(@nInputID, 0) 
	order by II.ID, G.Alias
return