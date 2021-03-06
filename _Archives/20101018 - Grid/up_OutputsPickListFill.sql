SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_OutputsPickListFill]
	@nOutputID		int				= Null, 
	@cOutputIDList	varchar(max)	= Null, 
	@bPrinted		bit				= Null -- напечатано?
AS

set nocount on

declare @cSelect varchar(max), @cWhere varchar(max)

select  TG.ID * 1 as ID, TG.OutputID, TG.OutputGoodID, 
		TG.OwnerID, TG.GoodStateID, 
		TG.PackingID, TG.QntWished, TG.QntConfirmed, 
		TG.CellSourceID, TG.CellTargetID,  
		TG.DateConfirm, 
		TG.Note, 
		OG.ERPNote, 
		cast('' as varchar(100)) as ZeroQntNote
	into #TrafficsGoods
	from TrafficsGoods TG with (nolock)
	inner join OutputsGoods OG with (nolock) on TG.OutputGoodID = OG.ID 
	where 1 = 2
select  TF.ID * 1 as ID, TF.OutputID, TF.OutputGoodID, TF.FrameID, 
		cast(Null as int) as OwnerID, cast(0 as int) as GoodStateID, 
		cast(0 as int) as PackingID, cast(0 as decimal(15, 3)) as Qnt, 
		TF.CellSourceID, TF.CellTargetID, 
		TF.DateConfirm, 
		TF.Note, 
		OG.ERPNote 
	into #TrafficsFrames
	from TrafficsFrames TF with (nolock)
	inner join OutputsGoods OG with (nolock) on TF.OutputGoodID = OG.ID 
	where 1 = 2

set @cWhere = ' where 1 = 1 '
if @nOutputID is not Null 
	set @cWhere = ' where TG.OutputID = ' + ltrim(str(@nOutputID)) + ' ' 
if @cOutputIDList is not Null 
	set @cWhere = ' where TG.OutputID in (' + dbo._NormalizeList(@cOutputIDList) + ') ' 
set @cSelect = '
insert #TrafficsGoods (ID, OutputID, OutputGoodID,  
		OwnerID, GoodStateID, 
		PackingID, QntWished, QntConfirmed, 
		CellSourceID, CellTargetID,  
		DateConfirm, 
		Note, 
		ERPNote, 
		ZeroQntNote)
	select  TG.ID, TG.OutputID, TG.OutputGoodID, 
			TG.OwnerID, TG.GoodStateID, 
			TG.PackingID, TG.QntWished, TG.QntConfirmed, 
			TG.CellSourceID, TG.CellTargetID,  
			TG.DateConfirm, 
			TG.Note, 
			OG.ERPNote, 
			'''' 
		from TrafficsGoods TG with (nolock) 
		left join OutputsGoods OG with (nolock) on TG.OutputGoodID = OG.ID ' +
	@cWhere 
if @bPrinted is not Null
	set @cSelect = @cSelect + ' and TG.DatePrint is ' + 
			case when @bPrinted = 1 then 'not' else '' end + ' Null '
exec (@cSelect)

set @cWhere = ' where 1 = 1 '
if @nOutputID is not Null 
	set @cWhere = ' where TF.OutputID = ' + ltrim(str(@nOutputID)) + ' ' 
if @cOutputIDList is not Null 
	set @cWhere = ' where TF.OutputID in (' + dbo._NormalizeList(@cOutputIDList) + ') ' 
set @cSelect = '
insert #TrafficsFrames (ID, OutputID, OutputGoodID, FrameID, 
		OwnerID, GoodStateID, 
		PackingID, Qnt, 
		CellSourceID, CellTargetID,  
		DateConfirm, 
		Note, 
		ERPNote)
	select  TF.ID, TF.OutputID, TF.OutputGoodID, TF.FrameID, 
			Null as OwnerID, 0 as GoodStateID, 
			0 as PackingID, 0 as Qnt, 
			TF.CellSourceID, TF.CellTargetID,  
			TF.DateConfirm, 
			TF.Note, 
			OG.ERPNote 
		from TrafficsFrames TF with (nolock) 
		inner join Outputs O with (nolock) on TF.OutputID = O.ID 
		left join OutputsGoods OG with (nolock) on TF.OutputGoodID = OG.ID ' +
		@cWhere + ' and TF.ErrorID is Null 
					and (TF.DateConfirm is Null or TF.CellTargetID = O.CellID) ' 
exec (@cSelect)

update #TrafficsFrames 
	set GoodStateID = OI.GoodStateID, OwnerID = O.OwnerID, PackingID = OI.PackingID, Qnt = OI.Qnt 
	from OutputsItems OI with (nolock) 
	inner join Outputs O with (nolock) on OI.OutputID = O.ID 
	where #TrafficsFrames.OutputID = OI.OutputID and #TrafficsFrames.FrameID = OI.FrameID
update #TrafficsFrames 
	set GoodStateID = CC.GoodStateID, OwnerID = CC.OwnerID, PackingID = CC.PackingID, Qnt = CC.Qnt 
	from CellsContents CC with (nolock) 
	where #TrafficsFrames.PackingID = 0 and #TrafficsFrames.FrameID = CC.FrameID

-- добавляем к списку перемещений нулевые - для тех трафиков контейнеров, для которых нет соотв.перемещений
if exists (select ID from #TrafficsFrames 
			where OutputGoodID not in (select OutputGoodID from #TrafficsGoods)) begin
	declare @nOwnerID int
	select @nOwnerID = OwnerID 
		from Outputs with (nolock) 
		where ID = @nOutputID
	
	insert #TrafficsGoods 
			(ID, OutputID, OutputGoodID, 
			OwnerID, GoodStateID, 
			PackingID, QntWished, QntConfirmed, 
			CellSourceID, CellTargetID, 
			DateConfirm, 
			Note, 
			ERPNote, 
			ZeroQntNote) 
		select distinct 0, OutputID, OutputGoodID, 
				@nOwnerID, GoodStateID, 
				PackingID, 0 as QntWished, 0 as QntConfirmed, 
				0 as CellSourceID, 0 as CellTargetID, 
				Null as DateConfirm, 
				'' as Note, 
				ERPNote, 
				'---' as ZeroQntNote 
			from #TrafficsFrames 
			where OutputGoodID not in (select OutputGoodID from #TrafficsGoods)
end 

-- OwnerID - в зависимости от SeparatePicking
update #TrafficsGoods 
	set OwnerID = Null 
	from Partners P with (nolock) 
	where #TrafficsGoods.OwnerID = P.ID and P.SeparatePicking = 0

-- списки складов
select distinct OutputID, 
		cast('' as varchar(2000)) as  StoresZonesNamesText 
	into #StoresZonesTexts 
	from #TrafficsGoods
update #StoresZonesTexts 
	set StoresZonesNamesText = .dbo.GetOutputStoresZonesNamesText(OutputID)

-- имитриуем привязку нулевых перемещений к соотв. ячейкам пикинга
if exists (select ID from #TrafficsGoods where CellSourceID = 0) begin
	-- ячейки в добавленных нулевых трафиках
	
	-- есть привязка
	update #TrafficsGoods set CellSourceID = C.ID 
		from Cells C with (nolock) 
		inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
		inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
		where #TrafficsGoods.CellSourceID = 0 and 
				#TrafficsGoods.PackingID = C.FixedPackingID and 
				#TrafficsGoods.GoodStateID = C.FixedGoodStateID and 
				IsNull(#TrafficsGoods.OwnerID, -1) = IsNull(C.FixedOwnerID, -1) and 
				C.Deleted = 0 and 
				SZT.ForPicking = 1
	
	if exists (select ID from #TrafficsGoods where CellSourceID = 0) begin
		-- нет привязки. значит, из Lost&Found
		
		-- ячейка Lost&Found
		declare @nLostFoundCellID int, @cLostFoundAddress varchar(20)
		select	@cLostFoundAddress = .dbo._SettingsGetValue('sLostFoundAddress')
		if IsNull(@cLostFoundAddress, '') <> '' begin
			select	@nLostFoundCellID = ID 
				from Cells with (nolock) 
				where Address = @cLostFoundAddress
		end
		
		if IsNull(@nLostFoundCellID, 0) <> 0 begin 
			update #TrafficsGoods 
				set CellSourceID = @nLostFoundCellID 
				where CellSourceID = 0
		end
	end
	
	-- ячейка-приемник - из расходной накладной
	update #TrafficsGoods set CellTargetID = O.CellID 
		from Outputs O with (nolock) 
		where #TrafficsGoods.CellTargetID = 0 and #TrafficsGoods.OutputID = O.ID
end 

-- дополнительно паллет к коробкам NEW
select distinct OutputGoodID, 
		IsNull(dbo.GetOutputGoodTrafficsFramesAddInfo(OutputGoodID), '') as TrafficsFramesAddInfo, 
		IsNull(dbo.GetOutputGoodTrafficsFramesAddQnt(OutputGoodID), 0) as TrafficsFramesAddQnt 
	into #TrafficsGoodsFramesAdd 
	from #TrafficsGoods

-- итоговая выборка
select	T.ID, T.ID as TrafficID, 
		T.OutputID, T.OutputGoodID, 
		
		T.CellSourceID, C_S.Address as CellSourceAddress, 
		C_S.CLine as CellSourceCLine, 
		C_S.BarCode as CellSourceBarCode, 
		C_S.StoreZoneID as StoreZoneSourceID, SZ_S.Name as StoreZoneSourceName, 
		SZ_S.StoreZoneTypeID as StoreZoneTypeSourceID, SZT_S.Name as StoreZoneTypeSourceName, SZT_S.ShortCode as StoreZoneTypeSourceShortCode, 
		C_S.BufferCellID as BufferCellSourceID, C_S_B.Address as BufferCellSourceAddress, 
		
		T.CellTargetID, C_T.Address as CellTargetAddress, 
		C_T.CLine as CellTargetCLine, 
		C_T.BarCode as CellTargetBarCode, 
		C_T.StoreZoneID as StoreZoneTargetID, SZ_T.Name as StoreZoneTargetName, 
		SZ_T.StoreZoneTypeID as StoreZoneTypeTargetID, SZT_T.Name as StoreZoneTypeTargetName, SZT_T.ShortCode as StoreZoneTypeTargetShortCode, 
		C_T.BufferCellID as BufferCellTargetID, C_T_B.Address as BufferCellTargetAddress, 
		C_S.Rank as CellSourceRank, 
		
		O.ErpBarCode as OutputBarCode, O.ErpCode as OutputErpCode, 
		O.DateOutput, O.DateConfirm as OutputDateConfirm, 
		OP.Name as OutputPartnerName, O.Note as OutputNote, 
		
		TG.Note, 
		
		TG.Critical, TG.Priority, TG.ByOrder, 
		TG.DateBirth, TG.DateSend, TG.DateAccept, TG.DatePrint, 
		T.DateConfirm, 
		cast(case when T.DateConfirm is null then 0 else 1 end as bit) as IsConfirmed, 
		TG.Success, 
		TG.UserID, U.Name as UserName, 
		TG.DeviceID, D.Name as DeviceName, 
		TG.ErrorID, TE.Name as TrafficGoodErrorName, TE.Severity as TrafficGoodErrorSeverity, 
		T.OwnerID, Ow.Name as OwnerName, 
		T.GoodStateID, GS.Name as GoodStateName, 
		
		T.PackingID, P.InBox, P.BoxHeight, 
		T.QntWished, 
		T.QntWished / P.InBox as BoxWished, 
		T.QntConfirmed, 
		T.QntConfirmed / P.InBox as BoxConfirmed, 
		(case when G.Weighting = 1 then 0 else floor(T.QntWished / P.InBox) end) as RestBoxWished, 
		(case when G.Weighting = 1 then T.QntWished * G.Netto else T.QntWished - floor(T.QntWished / P.InBox) * P.InBox end) as RestQntWished, 
		(case when G.Weighting = 1 then 0 else floor(T.QntConfirmed / P.InBox) end) as RestBoxConfirmed, 
		(case when G.Weighting = 1 then T.QntConfirmed * G.Netto else T.QntConfirmed - floor(T.QntConfirmed / P.InBox) * P.InBox end) as RestQntConfirmed, 
		
		T.ERPNote, 
		T.ZeroQntNote, 
		TG.DateValid, 
		
		dbo.GetCellsContentsQnt(T.PackingID, T.GoodStateID, T.OwnerID, 1, 1) as CCQnt, 
		
		TAdd.TrafficsFramesAddInfo, 
		TAdd.TrafficsFramesAddQnt, 
		(case when G.Weighting = 1 then 0 else floor(TAdd.TrafficsFramesAddQnt / P.InBox) end) as TrafficsFramesAddBox, 
		(case when G.Weighting = 1 then TAdd.TrafficsFramesAddQnt * G.Netto else TAdd.TrafficsFramesAddQnt - floor(TAdd.TrafficsFramesAddQnt / P.InBox) * P.InBox end) as TrafficsFramesAddRestQnt, 
		
		G.Alias as GoodAlias, G.Name as GoodName, 
		G.Alias + ' (' + ltrim(str(P.InBox, 12, (case when G.Weighting = 1 then 3 else 0 end))) + ')' as PackingAlias, 
		G.BarCode as GoodBarCode, 
		G.Articul, 
		G.Weighting, G.Retention, 
		GG.Name as GoodGroupName, GB.Name as GoodBrandName, 
		
		cast((case when G.Weighting = 1 or floor(1.00 * P.InBox) != (1.00 * P.InBox) then 1 else 0 end) as bit) as PrintDecimals, 
		
 		SZA.StoresZonesNamesText, 
		
		cast(case when T.DateConfirm is not null then T.QntConfirmed / P.InBox 
			 else case when IsNull(TG.Critical, 0) = 1 then 0 else T.QntWished / P.InBox end end as Decimal(12,3)) as ForBoxConfirmed, 
		case when T.DateConfirm is not null then T.QntConfirmed 
			 else case when IsNull(TG.Critical, 0) = 1 then 0 else T.QntWished end end as ForQntConfirmed, 
		cast(case when IsNull(TG.Critical, 0) = 1 then 0 else 1 end as bit) as Checked 
		
	from #TrafficsGoods T with (nolock) 
	
	left  join #TrafficsGoodsFramesAdd TAdd with (nolock) on T.OutputGoodID = TAdd.OutputGoodID 
	left  join TrafficsGoods TG with (nolock) on T.ID = TG.ID 
	
	inner join Cells C_S with (nolock) on T.CellSourceID = C_S.ID 
	left  join Cells C_S_B with (nolock) on C_S.BufferCellID = C_S_B.ID 
	inner join Cells C_T with (nolock) on T.CellTargetID = C_T.ID 
	left  join Cells C_T_B with (nolock) on C_T.BufferCellID = C_T_B.ID 
	
	inner join StoresZones SZ_S with (nolock) on C_S.StoreZoneID = SZ_S.ID 
	inner join StoresZones SZ_T with (nolock) on C_T.StoreZoneID = SZ_T.ID 
	inner join StoresZonesTypes SZT_S with (nolock) on SZ_S.StoreZoneTypeID = SZT_S.ID 
	inner join StoresZonesTypes SZT_T with (nolock) on SZ_T.StoreZoneTypeID = SZT_T.ID 
	
	left join #StoresZonesTexts SZA on T.OutputID = SZA.OutputID 
	
	left join TrafficsGoodsErrors TE with (nolock) on TG.ErrorID = TE.ID 
	
	left join _Users U with (nolock) on U.ID  = TG.UserID 
	left join Devices D with (nolock) on D.ID  = TG.DeviceID 
	
	left join Partners Ow with (nolock) on T.OwnerID = Ow.ID 
	left join GoodsStates GS with (nolock) on T.GoodStateID = GS.ID 
	left join Packings P with (nolock) on T.PackingID = P.ID 
	left join Goods G with (nolock) on P.GoodID = G.ID 
	left join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
	left join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
	
	left join Outputs O with (nolock) on T.OutputID = O.ID 
	left join Partners OP on O.PartnerID = OP.ID 
	
	order by T.OutputID 
return