SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_OutputsTrafficsFill]
	@nOutputID	int, 
	@bFrameMode bit -- 1 TrafficsFrames, 0 TrafficsGoods
AS

set nocount on

if @bFrameMode = 1 begin
	-- контейнеры
	select	T.ID, T.ID as TrafficID, 
			T.PreviousTrafficID, 
			T.FrameID, F.BarCode as FrameBarCode, F.FrameHeight, dbo.GetFrameWeight(F.ID) as FrameWeight, 
			
			T.CellSourceID, C_S.Address as CellSourceAddress, C_S.BarCode as CellSourceBarCode, 
			C_S.StoreZoneID as StoreZoneSourceID, SZ_S.Name as StoreZoneSourceName, 
			SZ_S.StoreZoneTypeID as StoreZoneTypeSourceID, SZT_S.Name as StoreZoneTypeSourceName, SZT_S.ShortCode as StoreZoneTypeSourceShortCode, 
			C_S.BufferCellID as BufferCellSourceID, C_S_B.Address as BufferCellSourceAddress, 
			
			T.CellTargetID, C_T.Address as CellTargetAddress, C_T.BarCode as CellTargetBarCode, 
			C_T.StoreZoneID as StoreZoneTargetID, SZ_T.Name as StoreZoneTargetName, 
			SZ_T.StoreZoneTypeID as StoreZoneTypeTargetID, SZT_T.Name as StoreZoneTypeTargetName, SZT_T.ShortCode as StoreZoneTypeTargetShortCode, 
			C_T.BufferCellID as BufferCellTargetID, C_T_B.Address as BufferCellTargetAddress, 
			
			T.InputID, I.ERPBarCode as InputBarCode, 
			T.OutputID, T.OutputGoodID, O.ERPBarCode as OutputBarCode, 
			
			T.Priority, T.ByOrder, 
			T.DateBirth, T.DateSend, T.DateAccept, 
			T.DateConfirm, 
			cast(case when T.DateConfirm is null then 0 else 1 end as bit) as IsConfirmed, 
			T.Success, 
			T.UserID, U.Name as UserName, 
			T.DeviceID, D.Name as DeviceName, 
			T.ErrorID, TE.Name as TrafficFrameErrorName, TE.Severity as TrafficFrameErrorSeverity, 
			
			F.OwnerID, Ow.Name as FrameOwnerName, 
			F.GoodStateID, GS.Name as FrameGoodStateName, 
			cast(case when T.DateConfirm is not null then 0 else 1 end as bit) as IsChecked 
		
		from TrafficsFrames T with (nolock) 
		
		inner join Frames F with (nolock) on T.FrameID = F.ID 
		inner join Cells C_S with (nolock) on T.CellSourceID = C_S.ID 
		left  join Cells C_S_B with (nolock) on C_S.BufferCellID = C_S_B.ID 
		inner join Cells C_T with (nolock) on T.CellTargetID = C_T.ID 
		left  join Cells C_T_B with (nolock) on C_T.BufferCellID = C_T_B.ID 
		inner join StoresZones SZ_S with (nolock) on C_S.StoreZoneID = SZ_S.ID 
		inner join StoresZones SZ_T with (nolock) on C_T.StoreZoneID = SZ_T.ID 
		inner join StoresZonesTypes SZT_S with (nolock) on SZ_S.StoreZoneTypeID = SZT_S.ID 
		inner join StoresZonesTypes SZT_T with (nolock) on SZ_T.StoreZoneTypeID = SZT_T.ID 
		
		left join TrafficsFramesErrors TE with (nolock) on TE.ID = T.ErrorID 
		left join _Users U with (nolock) on U.ID  = T.UserID 
		left join Devices D with (nolock) on D.ID  = T.DeviceID 
		left join Partners Ow with (nolock) on F.OwnerID = Ow.ID 
		left join GoodsStates GS with (nolock) on F.GoodStateID = GS.ID 
		
		left join Inputs I with (nolock) on T.InputID = I.ID 
		left join Outputs O with (nolock) on T.OutputID = O.ID 
		
		where	T.OutputID = IsNull(@nOutputID, 0)
		
		order by F.ID
end
else begin
	-- перемещения
	select	T.ID, T.ID as TrafficID, 
			T.CellSourceID, C_S.Address as CellSourceAddress, C_S.BarCode as CellSourceBarCode, 
			C_S.StoreZoneID as StoreZoneSourceID, SZ_S.Name as StoreZoneSourceName, 
			SZ_S.StoreZoneTypeID as StoreZoneTypeSourceID, SZT_S.Name as StoreZoneTypeSourceName, SZT_S.ShortCode as StoreZoneTypeSourceShortCode, 
			C_S.BufferCellID as BufferCellSourceID, C_S_B.Address as BufferCellSourceAddress, 
			C_S.Rank as CellSourceRank, 
			
			T.CellTargetID, C_T.Address as CellTargetAddress, C_T.BarCode as CellTargetBarCode, 
			C_T.StoreZoneID as StoreZoneTargetID, SZ_T.Name as StoreZoneTargetName, 
			SZ_T.StoreZoneTypeID as StoreZoneTypeTargetID, SZT_T.Name as StoreZoneTypeTargetName, SZT_T.ShortCode as StoreZoneTypeTargetShortCode, 
			C_T.BufferCellID as BufferCellTargetID, C_T_B.Address as BufferCellTargetAddress, 
			
			T.InputID, 
			I.ERPBarCode as InputBarCode, 
			T.OutputID, T.OutputGoodID, 
			O.ERPBarCode as OutputBarCode, 
			O.DateOutput, O.DateConfirm as OutputDateConfirm, 
			OP.Name as OutputPartnerName, 
			
			T.Critical, T.Priority, T.ByOrder, 
			T.DateBirth, T.DateSend, T.DateAccept, 
			T.DateConfirm, 
			cast(case when T.DateConfirm is null then 0 else 1 end as bit) as IsConfirmed, 
			T.Success, 
			T.UserID, U.Name as UserName, 
			T.DeviceID, D.Name as DeviceName, 
			T.ErrorID, TE.Name as TrafficGoodErrorName, TE.Severity as TrafficGoodErrorSeverity, 
			
			T.OwnerID, Ow.Name as OwnerName, 
			T.GoodStateID, GS.Name as GoodStateName, 
			
			T.PackingID, P.InBox, 
			T.QntWished, T.QntWished / P.InBox as BoxWished, 
			T.QntConfirmed, T.QntConfirmed / P.InBox as BoxConfirmed, 
			
			T.FrameID, 
			
			floor(T.QntWished / P.InBox) as RestBoxWished, 
			T.QntWished - floor(T.QntWished / P.InBox) * P.InBox as RestQntWished, 
			floor(T.QntConfirmed / P.InBox) as RestBoxConfirmed, 
			T.QntConfirmed - floor(T.QntConfirmed / P.InBox) * P.InBox as RestQntConfirmed, 
			T.DateValid, 
			
			G.Alias as GoodAlias, 
			G.Name as GoodName, 
			G.BarCode as GoodBarCode, 
			G.Articul, 
			G.Weighting, G.Retention, 
			GG.Name as GoodGroupName, GB.Name as GoodBrandName, 
			P.BoxHeight, 
			OG.ERPNote, 
			
			case when T.DateConfirm is not null then T.QntConfirmed 
				 else case when T.Critical = 1 then 0 else case when G.Weighting = 1 
					then 0 else T.QntWished end end end as ForQntConfirmed, 
			
			cast(case when T.DateConfirm is not null then T.QntConfirmed / P.InBox 
				 else case when T.Critical = 1 then 0 else case when G.Weighting = 1 
					then 0 else T.QntWished / P.InBox end end end as Decimal(12,3)) 
					as ForBoxConfirmed, 
			
			cast(case when T.Critical = 1 then 0 else case when G.Weighting = 1 then 0 
					else 1 end end as bit) as IsChecked 
		
		from TrafficsGoods T with (nolock) 
		
		inner join Cells C_S with (nolock) on T.CellSourceID = C_S.ID 
		inner join OutputsGoods OG on OG.ID = T.OutputGoodID 
		left  join Cells C_S_B with (nolock) on C_S.BufferCellID = C_S_B.ID 
		inner join Cells C_T with (nolock) on T.CellTargetID = C_T.ID 
		left  join Cells C_T_B with (nolock) on C_T.BufferCellID = C_T_B.ID 
		
		inner join StoresZones SZ_S with (nolock) on C_S.StoreZoneID = SZ_S.ID 
		inner join StoresZones SZ_T with (nolock) on C_T.StoreZoneID = SZ_T.ID 
		inner join StoresZonesTypes SZT_S with (nolock) on SZ_S.StoreZoneTypeID = SZT_S.ID 
		inner join StoresZonesTypes SZT_T with (nolock) on SZ_T.StoreZoneTypeID = SZT_T.ID 
		
		left join TrafficsGoodsErrors TE with (nolock) on TE.ID = T.ErrorID 
		
		left join _Users U with (nolock) on U.ID  = T.UserID 
		left join Devices D with (nolock) on D.ID  = T.DeviceID 
		
		left join Partners Ow with (nolock) on T.OwnerID = Ow.ID 
		left join GoodsStates GS with (nolock) on T.GoodStateID = GS.ID 
		
		left join Packings P with (nolock) on T.PackingID = P.ID 
		left join Goods G with (nolock) on P.GoodID = G.ID 
		left join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
		left join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
		
		left join Inputs I with (nolock) on T.InputID = I.ID 
		left join Outputs O with (nolock) on T.OutputID = O.ID 
		left join Partners OP on O.PartnerID = OP.ID 
		
		where	T.OutputID = IsNull(@nOutputID, 0) 
		
		order by C_T.Address, -- в какой ячейке собираем товар (OUT)
				 SZ_S.Name, SZ_S.ID, C_S.Rank, C_S.Address, -- из каких ячеек собираем товар (с учетом последовательности обхода)
				 G.Alias
end
return