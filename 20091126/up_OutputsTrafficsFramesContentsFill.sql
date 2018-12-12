set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_OutputsTrafficsFramesContentsFill]
	@cOutputsList varchar(MAX) = Null
AS

set nocount on

select ID, OwnerID, GoodStateID, CellID 
	into #Outputs 
	from Outputs 
	where charindex(',' + ltrim(str(ID)) + ',', ',' + @cOutputsList + ',') > 0

select T.ID, T.FrameID 
	into #TrafficsFrames 
	from TrafficsFrames T 
	inner join #Outputs O on T.OutputID = O.ID and T.CellTargetID = O.CellID

select OI.FrameID, OI.CellID, O.OwnerID, O.GoodStateID, 
		OI.PackingID, OI.Qnt, OI.DateValid 
	into #OutputsItems 
	from OutputsItems OI 
	inner join #Outputs O on OI.OutputID = O.ID 
	where OI.FrameID is not Null

select CC.FrameID, CC.CellID, CC.OwnerID, CC.GoodStateID, 
		CC.PackingID, CC.Qnt, CC.DateValid, 
		.dbo.GetPackingPickingCellID(CC.PackingID, CC.OwnerID, CC.GoodStateID) as CellPickingID 
	into #CellsContents 
	from CellsContents CC 
	inner join (select distinct FrameID from #TrafficsFrames) F on CC.FrameID = F.FrameID
insert #CellsContents (FrameID, CellID, OwnerID, GoodStateID, PackingID, Qnt, DateValid) 
	select FrameID, CellID, OwnerID, GoodStateID, PackingID, Qnt, DateValid 
		from #OutputsItems 
		where FrameID not in (select FrameID from #CellsContents)

select	T.ID, T.ID as TrafficID, 
		T.PreviousTrafficID, 
		T.CellSourceID, C_S.Address as CellSourceAddress, C_S.BarCode as CellSourceBarCode, 
		C_S.StoreZoneID as StoreZoneSourceID, SZ_S.Name as StoreZoneSourceName, 
		SZ_S.StoreZoneTypeID as StoreZoneTypeSourceID, SZT_S.Name as StoreZoneTypeSourceName, SZT_S.ShortCode as StoreZoneTypeSourceShortCode, 
		C_S.BufferCellID as BufferCellSourceID, C_S_B.Address as BufferCellSourceAddress, 
		T.CellTargetID, C_T.Address as CellTargetAddress, C_T.BarCode as CellTargetBarCode, 
		C_T.StoreZoneID as StoreZoneTargetID, SZ_T.Name as StoreZoneTargetName, 
		SZ_T.StoreZoneTypeID as StoreZoneTypeTargetID, SZT_T.Name as StoreZoneTypeTargetName, SZT_T.ShortCode as StoreZoneTypeTargetShortCode, 
		C_T.BufferCellID as BufferCellTargetID, C_T_B.Address as BufferCellTargetAddress, 
		T.Priority, T.ByOrder, 
		T.DateBirth, T.DateSend, T.DateAccept, 
		T.DateConfirm, 
		cast(case when T.DateConfirm is null then 0 else 1 end as bit) as IsConfirmed, 
		T.Success, T.Note, 
		T.UserID, U.Name as UserName, 
		T.DeviceID, D.Name as DeviceName, 
		
		T.OutputID, 
		O.ErpBarCode as OutputBarCode, O.ErpCode as OutputErpCode, 
		O.DateOutput, O.DateConfirm as OutputDateConfirm, 
		OP.Name as OutputPartnerName, O.Note as OutputNote, 
		
		T.FrameID, F.BarCode as FrameBarCode, F.FrameHeight, dbo.GetFrameWeight(F.ID) as FrameWeight, 
		F.State as FrameState, 
		F.BarCode as FrameBarCode, 
		F.OwnerID, Ow.Name as FrameOwnerName, 
		F.GoodStateID, GS.Name as FrameGoodStateName, 
		
		-- ячейка
		CC.CellID, 
		C.BarCode as CellBarCode, C.Address, 
		C.State as CellState, 
		-- содержимое
		CC.OwnerID, Ow.Name as OwnerName, 
		CC.GoodStateID, GS.Name as GoodStateName, 
		CC.PackingID, P.GoodID, 
		G.BarCode as GoodBarCode, P.BarCode as PackingBarCode, 
		G.Name as GoodName, G.Alias as GoodAlias, 
		G.Articul, 
		G.Retention, G.Weighting, 
		G.Netto, G.Brutto, 
		G.GoodGroupID, GG.Name as GoodGroupName, 
		G.GoodBrandID, GB.Name as GoodBrandName, 
		P.InBox, P.BoxInPal, 
		CP.ID as CellPickingID, CP.StoreZoneID as StoreZonePickingID, 
		CC.Qnt, 
		CC.Qnt / P.InBox as Box, 
		cast(CC.Qnt / P.InBox / P.BoxInPal as decimal(12, 4)) as Pal, 
		CC.DateValid 
		
	from TrafficsFrames T with (nolock) 
	
	inner join #TrafficsFrames TT on T.ID = TT.ID 
	
	inner join Cells C_S with (nolock) on T.CellSourceID = C_S.ID 
	left  join Cells C_S_B with (nolock) on C_S.BufferCellID = C_S_B.ID 
	inner join Cells C_T with (nolock) on T.CellTargetID = C_T.ID 
	left  join Cells C_T_B with (nolock) on C_T.BufferCellID = C_T_B.ID 
	
	inner join StoresZones SZ_S with (nolock) on C_S.StoreZoneID = SZ_S.ID 
	inner join StoresZones SZ_T with (nolock) on C_T.StoreZoneID = SZ_T.ID 
	inner join StoresZonesTypes SZT_S with (nolock) on SZ_S.StoreZoneTypeID = SZT_S.ID 
	inner join StoresZonesTypes SZT_T with (nolock) on SZ_T.StoreZoneTypeID = SZT_T.ID 
	
	left join _Users U with (nolock) on U.ID  = T.UserID 
	left join Devices D with (nolock) on D.ID  = T.DeviceID 
	
	left join Outputs O with (nolock) on T.OutputID = O.ID 
	left join Partners OP with (nolock) on O.PartnerID = OP.ID 
	
	left join #CellsContents CC with (nolock) on T.FrameID = CC.FrameID 
	left join Cells C with (nolock) on CC.CellID = C.ID 
	left join Partners Ow with (nolock) on CC.OwnerID = Ow.ID 
	left join GoodsStates GS with (nolock) on CC.GoodStateID = GS.ID 
	left join Frames F with (nolock) on CC.FrameID = F.ID 
	left join Partners Ow_F with (nolock) on F.OwnerID = Ow_F.ID 
	left join GoodsStates GS_F with (nolock) on F.GoodStateID = GS_F.ID 
	
	left join Packings P with (nolock) on CC.PackingID = P.ID 
	left join Goods G with (nolock) on P.GoodID = G.ID 
	left join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	left join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
	
	left join Partners Ps with (nolock) on O.OwnerID = PS.ID 
	left join Cells CP with (nolock) on CC.CellPickingID = CP.ID 
	
	order by T.OutputID, G.Alias, CC.FrameID
return