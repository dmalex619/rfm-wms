set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_CellsContentsSnapshotsDetailsFill]
	@nID				int,		-- код копии остатков
	@nGroupBy			int = 0,	-- 0 - только нач., 
									-- 1 - только кон.,
									-- 2 - группировать по ячейке (только для ячеек, где один товар) 
									-- 3 - группировать по состоянию/владельцу/товару (без ячеек и контейнеров), 
	@bExcludeLostFoundBeg bit = 0,	-- 0 - включить ячейку Lost&Found в нач., 1 искл.
	@bExcludeLostFoundEnd bit = 0,	-- 0 - включить ячейку Lost&Found в кон., 1 искл.
	@bDiffOnly			bit = 0,    -- выводить только строки с разночтениями
	@bInInventoryOnly	bit = 0,    -- выводить только строки в соотв.ревизиях
	@cCellsList			varchar(MAX) = Null,	-- список ячеек (через ,)
	@cOwnersList		varchar(MAX) = Null, 	-- список владельцев (через ,)
	@cGoodsStatesList	varchar(MAX) = Null, 	-- список состояний товара (через ,)
	@cPackingsList		varchar(MAX) = Null		-- список упаковок (через ,)
AS

/*
exec up_CellsContentsSnapshotsDetailsFill 8, 3, 0, 0, 0, 1
*/

set nocount on

declare @cErrorStr varchar(250)

-- ячейка Lost&Found
declare @nLostFoundCellID int, @cLostFoundAddress varchar(20), 
		@cLostFoundCellID varchar(20)
select	@cLostFoundAddress = .dbo._SettingsGetValue('sLostFoundAddress')
if IsNull(@cLostFoundAddress, '') = '' begin
	select	--@nError = -13, 
			@cErrorStr = 'Не задан адрес виртуальной ячейки Lost&Found...'
	RaisError (@cErrorStr, 11, 1)
	return
end
select	@nLostFoundCellID = ID, @cLostFoundCellID = ltrim(str(ID)) 
	from	Cells 
	where	Address = @cLostFoundAddress
if IsNull(@nLostFoundCellID, 0) = 0 begin
	select	--@nError = -14, 
			@cErrorStr = 'Не найдена виртуальная ячейка (Lost&Found) с адресом ' + @cLostFoundAddress + '...'
	RaisError (@cErrorStr, 11, 1)
	return
end

------------------------------

-- таблица привязанных ревизий
select ID * 1 as InventoryID 
	into #Inventories
	from Inventories with (nolock)
	where CellContentSnapshotID = IsNull(@nID, 0) 
	
create table #InventoryCells (CellID int)
create table #InventoryPackings (PackingID int)
if @bInInventoryOnly = 1 begin 
	-- только ячейки/товары в соотв.ревизиях 
	insert #InventoryCells (CellID)
		select distinct CellID 
			from InventoriesCells with (nolock)
			where InventoryID in (select InventoryID from #Inventories)
	insert #InventoryPackings (PackingID)
		select distinct PackingID 
			from InventoriesCells with (nolock)
			where InventoryID in (select InventoryID from #Inventories)
end

declare @cSelect varchar(max), @cWhere varchar(max), @cOrderBy varchar(max)

if @nGroupBy = 0 or @nGroupBy = 1 begin
	-- отдельно нач. или кон.
	select	ID * 1 as ID, 
			CellID, 
			cast(Null as bit) as Locked, 
			FrameID, 
			OwnerID, 
			GoodStateID + Null as GoodStateID, 
			PackingID + Null as PackingID, 
			Qnt + Null as Qnt, 
			DateValid, 
			DateLastOperation 
		into #CellsContentsX 
		from CellsContents with (nolock) 
		where 1 = 2
	
	set @cSelect = '
	insert #CellsContentsX (ID, CellID, Locked, FrameID, 
			OwnerID, GoodStateID, PackingID, Qnt, DateValid, DateLastOperation) 
		select	CC.ID, CC.CellID, CC.Locked, CC.FrameID, 
				CC.OwnerID, CC.GoodStateID, 
				CC.PackingID, CC.Qnt, CC.DateValid, CC.DateLastOperation 
			from CellsContentsSnapshots' + case when @nGroupBy = 1 then 'End' else 'Beg' end + ' CC with (nolock) '
	set @cWhere = ' where CC.CellContentSnapshotID = ' + str(@nID)
	if @cCellsList is not Null
		set @cWhere = @cWhere + ' and CC.CellID in (' + dbo._NormalizeList(@cCellsList) + ') '
	if @cOwnersList is not Null
		set @cWhere = @cWhere + ' and CC.OwnerID in (' + dbo._NormalizeList(@cOwnersList) + ') '
	if @cGoodsStatesList is not Null
		set @cWhere = @cWhere + ' and CC.GoodStateID in (' + dbo._NormalizeList(@cGoodsStatesList) + ') '
	if @cPackingsList is not Null
		set @cWhere = @cWhere + ' and CC.PackingID in (' + dbo._NormalizeList(@cPackingsList) + ') '
	if  @nGroupBy = 0 and @bExcludeLostFoundBeg = 1 or 
		@nGroupBy = 1 and @bExcludeLostFoundEnd = 1
		set @cWhere = @cWhere + ' and CC.CellID <> ' + ltrim(str(@nLostFoundCellID)) + ' '
	if @bInInventoryOnly = 1 
		set @cWhere = @cWhere + ' and ( CC.CellID in (select CellID from #InventoryCells) or CC.PackingID in (select PackingID from #InventoryPackings) ) '

	set @cSelect = @cSelect + @cWhere
	exec (@cSelect)
	
	select	CC.ID, 
			-- ячейка
			CC.CellID, CC.Locked, 
			C.Address, 
			C.BarCode as CellBarCode, 
			C.StoreZoneID, SZ.Name as StoreZoneName, 
			SZ.StoreZoneTypeID, SZT.Name as StoreZoneTypeName, 
			C.State as CellState, 
			C.FixedOwnerID as CellFixedOwnerID, Fix_Ow.Name as CellFixedOwnerName, 
			C.FixedGoodStateID as CellFixedGoodStateID, Fix_GS.Name as CellFixedGoodStateName, 
			C.FixedPackingID as CellFixedPackingID, 
			-- контейнер 
			CC.FrameID, 
			F.BarCode as FrameBarCode, 
			F.OwnerID as FrameOwnerID, Ow_F.Name as FrameOwnerName, 
			F.GoodStateID as FrameGoodStateID, GS_F.Name as FrameGoodStateName, 
			--F.FrameHeight, 
			--cast((case when F.ID is Null then Null else .dbo.GetFrameWeight(F.ID) end) as decimal(12, 3)) as FrameWeight, 
			
			-- содержимое
			CC.OwnerID, Ow.Name as OwnerName, 
			CC.GoodStateID, GS.Name as GoodStateName, 
			
			CC.PackingID, P.GoodID, 
			
			G.ID as GoodID, P.ID as PackingID, 
			G.BarCode as GoodBarCode, P.BarCode as PackingBarCode, 
			G.Name as GoodName, G.Alias as GoodAlias, 
			G.Alias + ' (' + ltrim(str(P.InBox, 12, (case when G.Weighting = 1 then 3 else 0 end))) + ')' as PackingAlias, 
			cast(case	when G.Actual is Null or P.Actual is Null then Null 
						when G.Actual = 1 and P.Actual = 1 then 1 
						else 0 end as bit) as GoodAndPackingActual, 
			G.Articul, 
			G.Retention, G.Weighting, 
			G.Netto, G.Brutto, 
			G.GoodGroupID, GG.Name as GoodGroupName, 
			G.GoodBrandID, GB.Name as GoodBrandName, 
			P.InBox, P.BoxInPal, 
			CC.Qnt, 
			CC.Qnt / P.InBox as BoxQnt, 
			cast(CC.Qnt / P.InBox / P.BoxInPal as decimal(12, 4)) as PalQnt, 
			CC.DateValid, 
			CC.DateLastOperation 
		
		from #CellsContentsX CC 
		
		inner join Cells C with (nolock) on CC.CellID = C.ID 
		inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
		inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
		
		left  join Partners Ow with (nolock) on CC.OwnerID = Ow.ID 
		left  join GoodsStates GS with (nolock) on CC.GoodStateID = GS.ID 
		
		left  join Frames F with (nolock) on CC.FrameID = F.ID 
		left  join Partners Ow_F with (nolock) on F.OwnerID = Ow_F.ID 
		left  join GoodsStates GS_F with (nolock) on F.GoodStateID = GS_F.ID 
		
		left  join Partners Fix_Ow with (nolock) on C.FixedOwnerID = Fix_Ow.ID 
		left  join GoodsStates Fix_GS with (nolock) on C.FixedGoodStateID = Fix_GS.ID 
		left  join Packings Fix_P with (nolock) on C.FixedPackingID = Fix_P.ID 
		left  join Goods Fix_G with (nolock) on Fix_P.GoodID = Fix_G.ID 
		
		left  join Packings P with (nolock) on CC.PackingID = P.ID 
		left  join Goods G with (nolock) on P.GoodID = G.ID 
		left  join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
		left  join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
		
		order by C.BarCode, G.Alias, CC.CellID
	-- отдельно нач. или кон., @nGroupBy = 0, 1
end

if @nGroupBy = 2 or @nGroupBy = 3 begin
	-- групп. по ячейке / по состоянию-владельцу-товару
	select	ID * 1 as ID, 
			CellID, 
			cast(Null as bit) as Locked, 
			FrameID, 
			OwnerID, 
			GoodStateID + Null as GoodStateID, 
			PackingID + Null as PackingID, 
			Qnt + Null as Qnt, 
			DateValid 
		into #CellsContentsBeg 
		from CellsContents with (nolock) 
		where 1 = 2
	select * 
		into #CellsContentsEnd 
		from #CellsContentsBeg 
		where 1 = 2
	
	declare @cSelectX varchar(max)
	set @cSelectX = '
	insert #CellsContents### (ID, CellID, Locked, FrameID, 
			OwnerID, GoodStateID, PackingID, Qnt, DateValid) 
		select	CC.ID, CC.CellID, CC.Locked, CC.FrameID, 
				CC.OwnerID, CC.GoodStateID, 
				CC.PackingID, CC.Qnt, CC.DateValid 
			from CellsContentsSnapshots### CC with (nolock) 
			left join Packings P with (nolock) on CC.PackingID = P.ID '
	set @cWhere = ' where CC.CellContentSnapshotID = ' + str(@nID)
	if @cCellsList is not Null
		set @cWhere = @cWhere + ' and CC.CellID in (' + dbo._NormalizeList(@cCellsList) + ') '
	if @cOwnersList is not Null
		set @cWhere = @cWhere + ' and CC.OwnerID in (' + dbo._NormalizeList(@cOwnersList) + ') '
	if @cGoodsStatesList is not Null
		set @cWhere = @cWhere + ' and CC.GoodStateID in (' + dbo._NormalizeList(@cGoodsStatesList) + ') '
	if @cPackingsList is not Null
		set @cWhere = @cWhere + ' and CC.PackingID in (' + dbo._NormalizeList(@cPackingsList) + ') '
	if @bInInventoryOnly = 1 
		set @cWhere = @cWhere + ' and ( CC.CellID in (select CellID from #InventoryCells) or CC.PackingID in (select PackingID from #InventoryPackings) ) '
	
	set @cSelect = replace(@cSelectX, '###', 'Beg') + @cWhere
	if @bExcludeLostFoundBeg = 1
		set @cSelect = @cSelect + ' and CC.CellID <> ' + ltrim(str(@nLostFoundCellID)) + ' '
	exec (@cSelect)
	
	set @cSelect = replace(@cSelectX, '###', 'End') + @cWhere
	if @bExcludeLostFoundEnd = 1
		set @cSelect = @cSelect + ' and CC.CellID <> ' + ltrim(str(@nLostFoundCellID)) + ' '
	exec (@cSelect)
	
	if @nGroupBy = 2 begin
		-- объединяем по ячейке
		select	CellID, 
				cast(Null as bit) as Locked_Beg, 
				FrameID as FrameID_Beg, 
				OwnerID as OwnerID_Beg, 
				GoodStateID + Null as GoodStateID_Beg, 
				PackingID + Null as PackingID_Beg, 
				Qnt + Null as Qnt_Beg, 
				DateValid as DateValid_Beg, 
				cast(Null as bit) as Locked_End, 
				FrameID as FrameID_End, 
				OwnerID as OwnerID_End, 
				GoodStateID + Null as GoodStateID_End, 
				PackingID + Null as PackingID_End, 
				Qnt + Null as Qnt_End, 
				DateValid as DateValid_End, 
				cast(0 as bit) as IsDiff 
			into #CellsContentsXX 
			from CellsContents with (nolock) 
			where 1 = 2
		create index CC_CellID on #CellsContentsXX (CellID)
		create index CC_CellID on #CellsContentsBeg (CellID)
		create index CC_CellID on #CellsContentsEnd (CellID)
		
		insert #CellsContentsXX (CellID, IsDiff) 
			select CellID, 0
				from #CellsContentsBeg 
				group by CellID 
				having count(*) = 1 
			union 
			select CellID, 0
				from #CellsContentsEnd 
				group by CellID 
				having count(*) = 1
		
		update #CellsContentsXX 
			set Locked_Beg = CC.Locked, 
				FrameID_Beg = CC.FrameID, 
				OwnerID_Beg = CC.OwnerID, GoodStateID_Beg = CC.GoodStateID, 
				PackingID_Beg = CC.PackingID, Qnt_Beg = CC.Qnt, DateValid_Beg = CC.DateValid 
			from #CellsContentsBeg CC 
			where #CellsContentsXX.CellID = CC.CellID
		update #CellsContentsXX 
			set Locked_End = CC.Locked, 
				FrameID_End = CC.FrameID, 
				OwnerID_End = CC.OwnerID, GoodStateID_End = CC.GoodStateID, 
				PackingID_End = CC.PackingID, Qnt_End = CC.Qnt, DateValid_End = CC.DateValid 
			from #CellsContentsEnd CC 
			where #CellsContentsXX.CellID = CC.CellID
		
		-- для массовых ячеек
		select distinct CellID 
			into #Cells1 
			from #CellsContentsXX
		insert #CellsContentsXX (CellID, IsDiff, 
					Locked_Beg, FrameID_Beg, OwnerID_Beg, GoodStateID_Beg, 
					PackingID_Beg, Qnt_Beg, DateValid_Beg, 
					Locked_End, FrameID_End, OwnerID_End, GoodStateID_End, 
					PackingID_End, Qnt_End, DateValid_End) 
			select CellID, 0, 
					Locked, FrameID, OwnerID, GoodStateID, 
					PackingID, Qnt, DateValid, 
					Null, Null, Null, Null,
					Null, Null, Null 
				from #CellsContentsBeg 
				where CellID not in (select CellID from #Cells1)
		select distinct CellID 
			into #Cells2 
			from #CellsContentsXX
		insert #CellsContentsXX (CellID, IsDiff, 
					Locked_Beg, FrameID_Beg, OwnerID_Beg, GoodStateID_Beg, 
					PackingID_Beg, Qnt_Beg, DateValid_Beg, 
					Locked_End, FrameID_End, OwnerID_End, GoodStateID_End, 
					PackingID_End, Qnt_End, DateValid_End) 
			select CellID, 0, 
					Null, Null, Null, Null, 
					Null, Null, Null, 
					Locked, FrameID, OwnerID, GoodStateID, 
					PackingID, Qnt, DateValid 
				from #CellsContentsEnd 
				where CellID not in (select CellID from #Cells2)
		
		-- конечные значения для товаров, которые уже были
		update #CellsContentsXX 
			set Locked_End = CC.Locked, FrameID_End = CC.FrameID, 
				OwnerID_End = CC.OwnerID, GoodStateID_End = CC.GoodStateID, 
				PackingID_End = CC.PackingID, Qnt_End = CC.Qnt, DateValid_End = CC.DateValid 
			from #CellsContentsEnd CC 
			where #CellsContentsXX.CellID = CC.CellID and 
				#CellsContentsXX.PackingID_Beg = CC.PackingID and 
				#CellsContentsXX.GoodStateID_Beg = CC.GoodStateID and 
				IsNull(#CellsContentsXX.OwnerID_Beg, -1) = IsNull(CC.OwnerID, -1) and 
				IsNull(#CellsContentsXX.FrameID_Beg, -1) = IsNull(CC.FrameID, -1)
		
		-- конечные значения для товаров, которых не было 
		select CellID, 
				FrameID_Beg as FrameID, 
				PackingID_Beg as PackingID, 
				GoodStateID_Beg as GoodStateID, OwnerID_Beg as OwnerID 
			into #CellsAll 
			from #CellsContentsXX
		insert #CellsAll (CellID, FrameID, PackingID, GoodStateID, OwnerID) 
			select CellID, 
					FrameID_End as FrameID, 
					PackingID_End as PackingID, 
					GoodStateID_End as GoodStateID, OwnerID_End as OwnerID 
				from #CellsContentsXX
		insert #CellsContentsXX (CellID, IsDiff, 
					Locked_Beg, FrameID_Beg, OwnerID_Beg, GoodStateID_Beg, 
					PackingID_Beg, Qnt_Beg, DateValid_Beg, 
					Locked_End, FrameID_End, OwnerID_End, GoodStateID_End, 
					PackingID_End, Qnt_End, DateValid_End) 
			select CellID, 0, 
					Null, Null, Null, Null,
					Null, Null, Null,
					Locked, FrameID, OwnerID, GoodStateID, 
					PackingID, Qnt, Null 
				from #CellsContentsEnd CC 
				where not exists (select CellID 
									from #CellsAll CA 
									where CA.CellID = CC.CellID and 
										CA.PackingID = CC.PackingID and 
										CA.GoodStateID = CC.GoodStateID and 
										IsNull(CA.OwnerID, -1) = IsNull(CC.OwnerID, -1) and
										IsNull(CA.FrameID, -1) = IsNull(CC.FrameID, -1)
									)
		-- расхождения
		update #CellsContentsXX 
			set IsDiff = 1 
			where IsNull(FrameID_Beg, -1) <> IsNull(FrameID_End, -1) or 
				IsNull(OwnerID_Beg, -1) <> IsNull(OwnerID_End, -1) or 
				IsNull(GoodStateID_Beg, -1) <> IsNull(GoodStateID_End, -1) or 
				IsNull(PackingID_Beg, -1) <> IsNull(PackingID_End, -1) or 
				IsNull(Qnt_Beg, -1) <> IsNull(Qnt_End, -1)
		
		select	-- ячейка 
				CC.CellID, 
				C.BarCode as CellBarCode, C.Address, 
				C.StoreZoneID, SZ.Name as StoreZoneName, 
				SZ.StoreZoneTypeID, SZT.Name as StoreZoneTypeName, 
				C.State as CellState, 
				C.FixedOwnerID as CellFixedOwnerID, Fix_Ow.Name as CellFixedOwnerName, 
				C.FixedGoodStateID as CellFixedGoodStateID, Fix_GS.Name as CellFixedGoodStateName, 
				C.FixedPackingID as CellFixedPackingID, 
				Fix_G.Alias + ' (' + ltrim(str(Fix_P.InBox, 12, (case when Fix_G.Weighting = 1 then 3 else 0 end))) + ')' as FixedPackingAlias, 
				
				CC.IsDiff, 
				CC.Locked_Beg, 
				CC.FrameID_Beg, F_Beg.BarCode as FrameBarCode_Beg, 
				CC.OwnerID_Beg, Ow_Beg.Name as OwnerName_Beg, 
				CC.GoodStateID_Beg, GS_Beg.Name as GoodStateName_Beg, 
				CC.PackingID_Beg, P_Beg.GoodID as GoodID_Beg, 
				G_Beg.BarCode as GoodBarCode_Beg, P_Beg.BarCode as PackingBarCode_Beg, 
				G_Beg.Name as GoodName_Beg, G_Beg.Alias as GoodAlias_Beg, 
				G_Beg.Alias + ' (' + ltrim(str(P_Beg.InBox, 12, (case when G_Beg.Weighting = 1 then 3 else 0 end))) + ')' as PackingAlias_Beg, 
				G_Beg.Actual as GoodActual_Beg, P_Beg.Actual as PackingActual_Beg, 
				G_Beg.Articul as Articul_Beg, 
				G_Beg.Retention as Retention_Beg, G_Beg.Weighting as Weighting_Beg, 
				G_Beg.Netto as Netto_Beg, G_Beg.Brutto as Brutto_Beg, 
				G_Beg.GoodGroupID as GoodGroupID_Beg, GG_Beg.Name as GoodGroupName_Beg, 
				G_Beg.GoodBrandID as GoodBrandID_Beg, GB_Beg.Name as GoodBrandName_Beg, 
				P_Beg.InBox as InBox_Beg, P_Beg.BoxInPal as BoxInPal_Beg, 
				CC.Qnt_Beg, 
				CC.Qnt_Beg / P_Beg.InBox as BoxQnt_Beg, 
				CC.Qnt_Beg / P_Beg.InBox / P_Beg.BoxInPal as PalQnt_Beg, 
				CC.DateValid_Beg, 
				
				CC.Locked_End, 
				CC.FrameID_End, F_End.BarCode as FrameBarCode_End, 
				CC.OwnerID_End, Ow_End.Name as OwnerName_End, 
				CC.GoodStateID_End, GS_End.Name as GoodStateName_End, 
				CC.PackingID_End, P_End.GoodID as GoodID_End, 
				G_End.BarCode as GoodBarCode_End, P_End.BarCode as PackingBarCode_End, 
				G_End.Name as GoodName_End, G_End.Alias as GoodAlias_End, 
				G_End.Alias + ' (' + ltrim(str(P_End.InBox, 12, (case when G_End.Weighting = 1 then 3 else 0 end))) + ')' as PackingAlias_End, 
				G_End.Actual as GoodActual_End, P_End.Actual as PackingActual_End, 
				G_End.Articul as Articul_End, 
				G_End.Retention as Retention_End, G_End.Weighting as Weighting_End, 
				G_End.Netto as Netto_End, G_End.Brutto as Brutto_End, 
				G_End.GoodGroupID as GoodGroupID_End, GG_End.Name as GoodGroupName_End, 
				G_End.GoodBrandID as GoodBrandID_End, GB_End.Name as GoodBrandName_End, 
				P_End.InBox as InBox_End, P_End.BoxInPal as BoxInPal_End, 
				CC.Qnt_End, 
				CC.Qnt_End / P_End.InBox as BoxQnt_End, 
				CC.Qnt_End / P_End.InBox / P_End.BoxInPal as PalQnt_End, 
				CC.DateValid_End 
			
			from #CellsContentsXX CC 
			
			inner join Cells C with (nolock) on CC.CellID = C.ID 
			inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
			inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
			
			left  join Partners Fix_Ow with (nolock) on C.FixedOwnerID = Fix_Ow.ID 
			left  join GoodsStates Fix_GS with (nolock) on C.FixedGoodStateID = Fix_GS.ID 
			left  join Packings Fix_P with (nolock) on C.FixedPackingID = Fix_P.ID 
			left  join Goods Fix_G with (nolock) on Fix_P.GoodID = Fix_G.ID 
			
			left  join Frames F_Beg with (nolock) on CC.FrameID_Beg = F_Beg.ID 
			left  join Partners Ow_Beg with (nolock) on CC.OwnerID_Beg = Ow_Beg.ID 
			left  join GoodsStates GS_Beg with (nolock) on CC.GoodStateID_Beg = GS_Beg.ID 
			left  join Packings P_Beg with (nolock) on CC.PackingID_Beg = P_Beg.ID 
			left  join Goods G_Beg with (nolock) on P_Beg.GoodID = G_Beg.ID 
			left  join GoodsGroups GG_Beg with (nolock) on G_Beg.GoodGroupID = GG_Beg.ID 
			left  join GoodsBrands GB_Beg with (nolock) on G_Beg.GoodBrandID = GB_Beg.ID 
			
			left  join Frames F_End with (nolock) on CC.FrameID_End = F_End.ID 
			left  join Partners Ow_End with (nolock) on CC.OwnerID_End = Ow_End.ID 
			left  join GoodsStates GS_End with (nolock) on CC.GoodStateID_End = GS_End.ID 
			left  join Packings P_End with (nolock) on CC.PackingID_End = P_End.ID 
			left  join Goods G_End with (nolock) on P_End.GoodID = G_End.ID 
			left  join GoodsGroups GG_End with (nolock) on G_End.GoodGroupID = GG_End.ID 
			left  join GoodsBrands GB_End with (nolock) on G_End.GoodBrandID = GB_End.ID 
			
			where (@bDiffOnly = 0 or IsDiff = 1)

			order by C.Address, C.BarCode
	end
	
	if @nGroupBy = 3 begin
		-- объединяем по состоянию/владельцу/товару (сумма, без ячеек, контейнеров и сроков годности)
		select	OwnerID, 
				GoodStateID + Null as GoodStateID,
				PackingID + Null as PackingID, 
				Qnt + Null as Qnt_Beg, 
				Qnt + Null as Qnt_End, 
				cast(0 as bit) as IsDiff 
			into #CellsContentsXXX 
			from CellsContents with (nolock) 
			where 1 = 2
		create index CC_ on #CellsContentsXXX (GoodStateID, OwnerID, PackingID)
		create index CC_ on #CellsContentsBeg (GoodStateID, OwnerID, PackingID)
		create index CC_ on #CellsContentsEnd (GoodStateID, OwnerID, PackingID)
		
		insert #CellsContentsXXX (GoodStateID, OwnerID, PackingID, IsDiff, Qnt_Beg, Qnt_End) 
			select distinct GoodStateID, OwnerID, PackingID, 0, 0, 0 
				from #CellsContentsBeg
		insert #CellsContentsXXX (GoodStateID, OwnerID, IsDiff, PackingID, Qnt_Beg, Qnt_End) 
			select distinct GoodStateID, OwnerID, PackingID, 0, 0, 0 
				from #CellsContentsEnd CC_End 
				where not exists (select ID from #CellsContentsBeg CC_Beg 
									where IsNull(CC_Beg.GoodStateID, -1) = IsNull(CC_End.GoodStateID, -1) and 
										IsNull(CC_Beg.OwnerID, -1) = IsNull(CC_End.OwnerID, -1) and 
										IsNull(CC_Beg.PackingID, -1) = IsNull(CC_End.PackingID, -1))
		
		update #CellsContentsXXX 
			set Qnt_Beg = CC.Qnt 
			from (select PackingID, GoodStateID, OwnerID, sum(Qnt) as Qnt 
					from #CellsContentsBeg 
					group by PackingID, GoodStateID, OwnerID) CC 
			where IsNull(#CellsContentsXXX.GoodStateID, -1) = IsNull(CC.GoodStateID, -1) and 
				IsNull(#CellsContentsXXX.OwnerID, -1) = IsNull(CC.OwnerID, -1) and 
				IsNull(#CellsContentsXXX.PackingID, -1) = IsNull(CC.PackingID, -1)
		update #CellsContentsXXX 
			set Qnt_End = CC.Qnt 
			from (select PackingID, GoodStateID, OwnerID, sum(Qnt) as Qnt 
					from #CellsContentsEnd 
					group by PackingID, GoodStateID, OwnerID)CC 
			where IsNull(#CellsContentsXXX.GoodStateID, -1) = IsNull(CC.GoodStateID, -1) and 
				IsNull(#CellsContentsXXX.OwnerID, -1) = IsNull(CC.OwnerID, -1) and 
				IsNull(#CellsContentsXXX.PackingID, -1) = IsNull(CC.PackingID, -1)
		
		-- расхождения
		update #CellsContentsXXX 
			set IsDiff = 1 
			where IsNull(Qnt_Beg, -1) <> IsNull(Qnt_End, -1)
		
		select	CC.OwnerID, Ow.Name as OwnerName, 
				CC.GoodStateID, GS.Name as GoodStateName, 
				CC.PackingID, P.GoodID, 
				G.BarCode as GoodBarCode, P.BarCode as PackingBarCode, 
				G.Name as GoodName, G.Alias as GoodAlias, 
				G.Alias + ' (' + ltrim(str(P.InBox, 12, (case when G.Weighting = 1 then 3 else 0 end))) + ')' as PackingAlias, 
				G.Actual as GoodActual, P.Actual as PackingActual, 
				G.Articul, 
				G.Retention, G.Weighting, 
				G.Netto, G.Brutto, 
				G.GoodGroupID, GG.Name as GoodGroupName, 
				G.GoodBrandID, GB.Name as GoodBrandName, 
				Ow.ERPCode as OwnerERPCode, GS.ERPCode as GoodStateERPCode, G.ERPCode as GoodERPCode, 
				P.InBox, P.BoxInPal, 
				CC.IsDiff, 
				CC.Qnt_Beg, 
				CC.Qnt_Beg / P.InBox as BoxQnt_Beg, 
				CC.Qnt_Beg / P.InBox / P.BoxInPal as PalQnt_Beg, 
				CC.Qnt_End, 
				CC.Qnt_End / P.InBox as BoxQnt_End, 
				CC.Qnt_End / P.InBox / P.BoxInPal as PalQnt_End 
			
			from #CellsContentsXXX CC 
			
			left  join Partners Ow with (nolock) on CC.OwnerID = Ow.ID 
			left  join GoodsStates GS with (nolock) on CC.GoodStateID = GS.ID 
			
			left  join Packings P with (nolock) on CC.PackingID = P.ID 
			left  join Goods G with (nolock) on P.GoodID = G.ID 
			left  join GoodsGroups GG with (nolock) on G.GoodGroupID = GG.ID 
			left  join GoodsBrands GB with (nolock) on G.GoodBrandID = GB.ID 
			
			where (@bDiffOnly = 0 or IsDiff = 1)
			order by G.Alias, G.BarCode
	end
end
return