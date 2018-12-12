set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_OutputsItemsFill]
	@nOutputID	int, 
	@nError		int = 0 output, 
	@cErrorText	varchar(200) = '' output 
AS

set nocount on

if	@nOutputID <> 0 and 
		not exists (select ID from Outputs where ID = IsNull(@nOutputID, 0)) begin 
	select	@nError = -1, 
			@cErrorText = 'Не найден расход с кодом ' + ltrim(str(@nOutputID)) + '...'
	RaisError(@cErrorText, 11, 1)
	return
end

-- для получения ячейки-источника (по соотв. перемещениям товаров)
select ID, PackingID, cast(Null as int) as CellSourceID
	into #OutputsItems 
	from OutputsItems with (nolock) 
	where OutputID = IsNull(@nOutputID, 0) and FrameID is Null
update #OutputsItems 
	set CellSourceID = T.CellSourceID
	from TrafficsGoods T with (nolock) 
	where	T.OutputID = IsNull(@nOutputID, 0) and
			#OutputsItems.PackingID = T.PackingID  

select	OI.ID as OutputItemID, 
		OI.OutputID,
		OI.DateConfirm as DateConfirmItem, 
		O.DateConfirm as OutputDateConfirm, 
		cast((case when OI.DateConfirm is Null then 0 else 1 end) as bit)as IsConfirmed, 
		OI.PackingID, 
		OI.Qnt, 
		OI.Qnt / P.InBox as Boxes, 
		cast(OI.Qnt / P.InBox / P.BoxInPal as decimal(12, 4)) as Pallets, 
		floor(OI.Qnt / P.InBox) as RestBoxes, 
		OI.Qnt - floor(OI.Qnt / P.InBox) * P.InBox as RestQnt, 
		OI.DateValid, 
		P.InBox, P.BoxHeight, 
		P.BoxInPal, P.BoxInRow, 
		OI.FrameID, F.BarCode as FrameBarCode, 
		
		OI.CellID, C.Address as CellAddress, C.BarCode as CellBarCode, 
		C.StoreZoneID, SZ.StoreZoneTypeID, 
		SZ.Name as StoreZoneName, SZT.Name as StoreZoneTypeName, 
		OI_Temp.CellSourceID, C_S.Address as CellSourceID, C_S.BarCode as CellBarCode, 
		C_S.StoreZoneID as StoreZoneSourceID, SZ_S.StoreZoneTypeID as StoreZoneTypeSourceID, 
		SZ_S.Name as StoreZoneSourceName, SZT_S.Name as StoreZoneTypeSourceName, 

		F.FrameHeight, .dbo.GetFrameWeight(F.ID) as FrameWeight, 
		GS.ID as GoodStateID, GS.Name as GoodStateName, 
		
		G.Alias as GoodAlias, G.Name as GoodName, 
		G.BarCode as GoodBarCode, 
		G.Articul, 
		G.Weighting, G.Retention, 
		GG.Name as GoodGroupName, 
		GB.Name as GoodBrandName, 
		OI.UserID, U.Name as UserName, 
		OI.DeviceID, D.Name as DeviceName, 
		cast(case when OI.FrameID is Null then 0 else 1 end as bit) as IsFrame
	from OutputsItems OI with (nolock) 
	inner join Outputs O on OI.OutputID = O.ID
	left join Packings P with (nolock) on OI.PackingID = P.ID 
	inner join Goods G with (nolock) on G.ID = P.GoodID 
	inner join GoodsStates GS with (nolock) on GS.ID = OI.GoodStateID 
	left join Frames F with (nolock) on OI.FrameID = F.ID 
	left join Cells C with (nolock) on OI.CellID  = C.ID 
	left join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	left join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 

	left join #OutputsItems OI_Temp on OI.ID = OI_Temp.ID
	left join Cells C_S with (nolock) on OI_Temp.CellSourceID  = C_S.ID 
	left join StoresZones SZ_S with (nolock) on C_S.StoreZoneID = SZ_S.ID 
	left join StoresZonesTypes SZT_S with (nolock) on SZ_S.StoreZoneTypeID = SZT_S.ID 
 
	left join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	left join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 

	left join _Users U with (nolock) on OI.UserID = U.ID 
	left join Devices D	with (nolock) on OI.DeviceID = D.ID 
	where OI.OutputID = IsNull(@nOutputID, 0) 
	order by OI.ID, G.Alias
return