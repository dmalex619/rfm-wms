set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[ws_CellsConvertWMS]
as 
-- 1. Выгрузки данных о ячейках, подъеме контейнеров, исправлении ошибок
-- (из БД Wms) 
-- Выполняется в БД Trading
-- Последние изменения: Александров 23.10.2007

set nocount on

-- ID и Uniq организации
-- Внимание!
declare @nWeID int, @cERPWe varchar(50)
select	@nWeID = WMS.dbo._SettingsGetValue('gnWe') -- код владельца
select	@cERPWe = ERPCode
	from	WMS.dbo.Partners 
	where	ID = @nWeID
if @nWeID is Null or @cERPWe is Null begin
	raiserror(N'Не найден код владельца склада!', 16, 1)
	return
end

-- Ячейка Lost&Found
declare @nLostFoundCellID int, @cLostFoundAddress varchar(20), 
		@cLostFoundCellID varchar(20)
select	@cLostFoundAddress = WMS.dbo._SettingsGetValue('sLostFoundAddress')
if isNull(@cLostFoundAddress, '') = '' begin
	raiserror ('Не задан адрес виртуальной ячейки Lost&Found...', 11, 1)
	return 
end 
select	@nLostFoundCellID = ID, 
		@cLostFoundCellID = ltrim(str(ID)) 
	from	WMS.dbo.Cells with (nolock) 
	where	Address = @cLostFoundAddress
if isNull(@nLostFoundCellID, 0) = 0 begin
	raiserror ('Не найдена виртуальная ячейка (Lost&Found)...', 11, 1)
	return
end

declare @nError int, @nCount int

-- Набор ячеек
-- все ячейки 
-- Cells.ERPCode содержит адрес из таблицы Trading.dbo.WHStorage
select	C.ID, C.ERPCode, SZT.ShortCode 
	into	#AllCells
	from	WMS.dbo.Cells C
	inner join WMS.dbo.StoresZones SZ on C.StoreZoneID = SZ.ID
	inner join WMS.dbo.StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT.ID
if @@Error <> 0 begin
	raiserror(N'Неудачная выборка из WMS (AllCells)!', 16, 1)
	return
end
begin try
	create index IX_AllCellsID on #AllCells (ID)
	create index IX_AllCellsERPCode on #AllCells (ERPCode)
end try
begin catch
	raiserror(N'Обнаружены неуникальные адреса ячеек в БД WMS!', 16, 1)
	return
end catch

-- Создание временной таблицы для поиска кодов упаковок
select Good, InBox, BoxInPal, Actual, Uniq 
	into #_Packings 
	from Packings 
	order by Good, InBox, BoxInPal, ~Actual, Uniq desc
if @@Error <> 0 begin
	raiserror(N'Неудачная выборка из Packings!', 16, 1)
	return
end

-- таблица ячеек высотной зоны только
select	* 
	into	#StorCellsList 
	from	#AllCells 
	where	ShortCode = 'STOR'
create index IX_CellsListID on #StorCellsList (ID)
create index IX_CellsListERPCode on #StorCellsList (ERPCode)

-- Геометрия, актуальность, блокировка
select	C.ID, 
		C.ERPCode as Address, 
		C.CellHeight, 
		C.CellWidth, 
		C.MaxWeight, 
		C.Locked, 
		C.Actual, 
		CBuilding + CLine + CRack + CLevel + CPLace as CompoundAddress 
	into	#Cells 
	from	WMS.dbo.Cells C
	inner join #StorCellsList TC on C.ID = TC.ID
if @@Error <> 0 begin
	raiserror(N'Неудачная выборка из WMS (Cells)!', 16, 1)
	return
end
create index IX_CellsID on #Cells (ID)
create index IX_CellsAddress on #Cells (Address)

-- Подъем контейнеров
select	T.ID, T.DateConfirm 
	into	#TrafficsList 
	from	WMS.dbo.TrafficsFrames T 
	inner join #StorCellsList TC on T.CellTargetID = TC.ID 
	where	T.ERPCode is Null and -- не переданы
			T.DateConfirm is not Null
select	T.ID, 
		T.ERPCode as ERPTraffic, 
		T.DateBirth, 
		T.DateConfirm, 
		T.FrameID as FrameID, 
		F.ERPCode as ERPFrame, 
		F.GoodStateID, 
		GS.Basic as GoodStateBasic, 
		GS.ERPCode as ERPGoodState, 
		isNull(F.OwnerID, @nWeID) as OwnerID, 
		isNull(P.ERPCode, @cERPWe) as ERPOwner, 
		T.CellSourceID, 
		CS.ERPCode as ERPCellSource, 
		CS.ERPCode as CellSourceAddress, 
		T.CellTargetID, 
		CT.ERPCode as ERPCellTarget, 
		CT.ERPCode as CellTargetAddress, 
		CC.Qnt, 
		CC.PackingID, 
		Ps.ERPCode as ERPPacking, 
		Ps.GoodID, 
		G.ERPCode as ERPGood, 
		Ps.InBox, Ps.BoxInPal, 
		CC.DateValid 
	into	#Traffics 
	from	WMS.dbo.TrafficsFrames T 
	inner join #TrafficsList TT on T.ID = TT.ID 
	inner join #StorCellsList TC on T.CellTargetID = TC.ID 
	left  join WMS.dbo.Frames F on T.FrameID = F.ID 
	left  join WMS.dbo.GoodsStates GS on F.GoodStateID = GS.ID 
	left  join WMS.dbo.Partners P on F.OwnerID = P.ID 
	left  join #AllCells CS on T.CellSourceID = CS.ID 
	left  join #AllCells CT on T.CellTargetID = CT.ID 
	left  join WMS.dbo.CellsContents CC on F.ID = CC.FrameID 
	left  join WMS.dbo.Packings Ps on CC.PackingID = Ps.ID 
	left  join WMS.dbo.Goods G on Ps.GoodID = G.ID 
	order by T.DateConfirm
if @@Error <> 0 begin
	raiserror(N'Неудачная выборка из WMS (TrafficsFrames)!', 16, 1)
	return
end

if exists (select * from #Traffics) begin
	-- На всякий случай перезаполняем код упаковки
	update #Traffics set ERPPacking = '^' + IsNull(ERPPacking, '')
	update #Traffics set ERPPacking = X.Uniq 
		from #_Packings X 
		where left(#Traffics.ERPPacking, 1) = '^' and 
			#Traffics.ERPGood = X.Good and #Traffics.InBox = X.InBox and 
			#Traffics.BoxInPal = X.BoxInPal and X.Actual = 1
	update #Traffics set ERPPacking = X.Uniq 
		from #_Packings X 
		where left(#Traffics.ERPPacking, 1) = '^' and 
			#Traffics.ERPGood = X.Good and #Traffics.InBox = X.InBox and 
			#Traffics.BoxInPal = X.BoxInPal
	update #Traffics set ERPPacking = X.Uniq 
		from #_Packings X 
		where left(#Traffics.ERPPacking, 1) = '^' and 
			#Traffics.ERPGood = X.Good and #Traffics.InBox = X.InBox
	if exists (select * from #Traffics where left(#Traffics.ERPPacking, 1) = '^') begin
		raiserror(N'Обнаружены неизвестные упаковки в #Traffics!', 16, 1)
		return
	end
end

-- Исправление ошибок (кроме ячейки LOST&FOUND)
select	H.ID, H.DateEdit 
	into	#ChangesList 
	from	WMS.dbo.CellsChanges H 
	inner join #StorCellsList TC on H.CellID = TC.ID 
	where	H.ERPCode is Null and -- не переданы
			H.DateEdit is not Null
select	H.ID, 
		H.ERPCode as ERPChange, 
		H.CellID, 
		H.ERPCode as ERPCellChange, 
		H.DateEdit, 
		C.ERPCode as ERPCell, 
		C.ERPCode as CellAddress, 
		H.GoodStateID, 
		GS.Basic as GoodStateBasic, 
		GS.ERPCode as ERPGoodState, 
		isNull(H.OwnerID, @nWeID) as OwnerID, 
		isNull(P.ERPCode, @cERPWe) as ERPOwner, 
		H.Qnt, 
		H.PackingID, 
		Ps.ERPCode as ERPPacking, 
		Ps.GoodID, 
		G.ERPCode as ERPGood, 
		Ps.InBox, Ps.BoxInPal, 
		H.DateValid 
	into	#Changes 
	from	WMS.dbo.CellsChanges H 
	inner join #ChangesList TCh on H.ID = TCh.ID 
	inner join #StorCellsList TC on H.CellID = TC.ID 
	left  join #AllCells C on H.CellID = C.ID 
	left  join WMS.dbo.Partners P on H.OwnerID = P.ID 
	left  join WMS.dbo.GoodsStates GS on H.GoodStateID = GS.ID 
	left  join WMS.dbo.Packings Ps on H.PackingID = Ps.ID 
	left  join WMS.dbo.Goods G on Ps.GoodID = G.ID 
	where H.CellID <> @nLostFoundCellID 
	order by H.DateEdit, ID
if @@Error <> 0 begin
	raiserror(N'Неудачная выборка из WMS (CellsChanges)!', 16, 1)
	return
end

if exists (select * from #Changes) begin
	-- На всякий случай перезаполняем код упаковки
	update #Changes set ERPPacking = '^' + IsNull(ERPPacking, '')
	update #Changes set ERPPacking = X.Uniq 
		from #_Packings X 
		where left(#Changes.ERPPacking, 1) = '^' and 
			#Changes.ERPGood = X.Good and #Changes.InBox = X.InBox and 
			#Changes.BoxInPal = X.BoxInPal and X.Actual = 1
	update #Changes set ERPPacking = X.Uniq 
		from #_Packings X 
		where left(#Changes.ERPPacking, 1) = '^' and 
			#Changes.ERPGood = X.Good and #Changes.InBox = X.InBox and 
			#Changes.BoxInPal = X.BoxInPal
	update #Changes set ERPPacking = X.Uniq 
		from #_Packings X 
		where left(#Changes.ERPPacking, 1) = '^' and 
			#Changes.ERPGood = X.Good and #Changes.InBox = X.InBox
	if exists (select * from #Changes where left(#Changes.ERPPacking, 1) = '^') begin
		raiserror(N'Обнаружены неизвестные упаковки в #Changes!', 16, 1)
		return
	end
end

-------------------------------------------------------------------------------
-- Получение данных о ячейках, размещении контейнеров, исправлении ошибок высотной зоны
-- (в БД Trd) 

begin tran
	declare @nWeUniq int 
	select	@nWeUniq = cast(Meaning as int)
		from	_General
		where	Variable = 'gnInco' 
	
	-- 1) Геометрия, актуальность, блокировка ячеек
	-- обновить существующие
	-- Блокировку в WMS не учитываем, иначе все занятые ячейки
	-- станут недоступны для снятия
	update	WHStorage 
		set		PalletWidth = C.CellWidth, 
				PalletHeight = C.CellHeight, 
				MaxWeight = C.MaxWeight, 
				--Locked = C.Locked, 
				Actual = C.Actual 
		from	#Cells C 
		where	C.Address = WHStorage.Address and (
			WHStorage.PalletWidth <> C.CellWidth or 
			WHStorage.PalletHeight <> C.CellHeight or 
			WHStorage.MaxWeight <> C.MaxWeight or 
			--WHStorage.Locked <> C.Locked or 
			WHStorage.Actual <> C.Actual
			)
	select @nError = @@Error, @nCount = @@RowCount
	if @nError <> 0 goto Tr_Error
	PRINT 'Update WHStorage: ' + ltrim(str(@nCount))
	
	-- удалить удаленные 
	if exists (select Uniq	
					from	WHStorage
					where	Address not in (select Address from #Cells) 
				) begin
		-- прямо сразу удалить? может, хотя бы снимем актуальность? 
		/*update	WHStorage 
			set		Actual = 0 
			from	#Cells 
			where	WHStorage.Address not in (select Address from #Cells)
		select @nError = @@Error, @nCount = @@RowCount
		if @nError <> 0 goto Tr_Error*/
		
		delete	WHStorage 
			where	Address not in (select Address from #Cells)
		select @nError = @@Error, @nCount = @@RowCount
		if @nError <> 0 goto Tr_Error
		PRINT 'Delete WHStorage: ' + ltrim(str(@nCount))
	end 
	
	-- добавить новые 
	if exists (select ID 	
					from	#Cells 
					where	CompoundAddress not in (select Address from WHStorage)
				) begin
		insert	WHStorage
			(Address, WHZone, PalletWidth, PalletHeight, MaxWeight, Depot, State, Packing, Qnt, DateValid, Locked, Actual)
			select CompoundAddress, 
				0 as WHZone, 
				CellWidth, CellHeight, MaxWeight, 
				Null as Depot, 
				Null as State, 
				Null as Packing, Null as Qnt, Null as DateValid, 
				C.Locked, C.Actual
			from	#Cells C 
			where	C.CompoundAddress not in (select Address from WHStorage)
		select @nError = @@Error, @nCount = @@RowCount
		if @nError <> 0 goto Tr_Error
		PRINT 'Insert WHStorage: ' + ltrim(str(@nCount))
		
		update	#Cells 
			set		Address = S.Address 
			from	WHStorage S 
			where	isNull(#Cells.Address, '') = '' and 
					#Cells.CompoundAddress = S.Address
		if @@Error <> 0 goto Tr_Error
	end 
	-- Закончили с ячейками
	
	-- 2) Начинаем работу с перемещениями
	-- для перекодировки
	declare @nOwnerID int, @nGoodStateID int, @bGoodStateBasic bit--, @nPackingID int
	declare @nOwnerUniq int, @nGoodStateUniq int--, @nPackingUniq int  
	declare @cERPCode varchar(50), @nERPError int
	set @nERPError = 0
	set @nCount = 0
	
	-- для подъема контейнеров и исправления ошибок
	declare @nOwner int, @nWMSGoodState int, @bWMSGoodStateBasic bit, 
			@nDepotUniq int, @cDepotName varchar(100), 
			@nCellUniq int,  @cCellAddress varchar(20) 
	
	-- Подъем контейнеров
	declare @nTrafficID int, @dDateConfirm datetime
	declare @nDraftUniq int
	
	-- Дата-время задания
	declare @dExchangeDateTime smalldatetime
	set @dExchangeDateTime = getdate()
	
	if exists (select ID from #Traffics) begin
		-- идем по выполненным операциям подъема контейнеров
		declare T_Cursor cursor for 
			select	ID, DateConfirm, ERPOwner, ERPGoodState, GoodStateBasic 
				from	#Traffics 
				order by DateConfirm
		open T_cursor
		fetch next from T_cursor into @nTrafficID, @dDateConfirm, 
									  @nOwner, @nWMSGoodState, @bWMSGoodStateBasic 
		while @@fetch_status = 0 begin
			-- 2.1. создаем задание на подъем, если такого нет
			
			-- определяем виртуальный склад
			set @nDepotUniq = Null 
			select top 1 @nDepotUniq = Uniq
				from	Depots 
				where	Owner = @nOwner and
						WMSGoodState = @nWMSGoodState and 
						Actual = 1
			if @nDepotUniq is Null 
				select top 1 @nDepotUniq = Uniq
					from	Depots 
					where	Owner = @nOwner and
							WMSGoodState = @nWMSGoodState and 
							Actual = 0
			if @nDepotUniq is Null begin
				-- так и не нашелся склад
				-- ДОБАВЛЯЕМ СКЛАД!
				select	@cDepotName = P.Alias
					from	Partners P
					where	P.Uniq = @nOwner
				select	@cDepotName = isNull(@cDepotName, '') + ' ' + GS.Alias
					from	WMSGoodsStates GS
					where	GS.Uniq = @nWMSGoodState
				select	@cDepotName = isNull(@cDepotName, '') + ' (WMS)'
				
				insert	Depots 
					(Alias, Name, Owner, Basic, NoControl, Actual, Deposit, WMSGoodState)
					select	left(@cDepotName, 25) as Alias,  
						left(@cDepotName, 50) as Name, 
						@nOwner as Owner, 
						@bWMSGoodStateBasic, 
						case when @nOwner = @nWeUniq then 1 else 0 end as NoControl, 
						1 as Actual, 
						case when @nOwnerUniq = @nWeUniq then 0 else 1 end as Deposit, 
						@nWMSGoodState as WMSGoodState
				select	@nDepotUniq = @@Identity, @nERPError = @@Error
				if @nERPError <> 0 break
			end
			
			-- определяем ячейку
			set	@nCellUniq = Null
			select	@nCellUniq = S.Uniq, @cCellAddress = T.CellTargetAddress
				from	WHStorage S, #Traffics T
				where	S.Address = T.CellTargetAddress and	
						T.ID = @nTrafficID
			if @nCellUniq is Null begin 
				set	@nERPError = -1	-- не найдена ячейка с адресом
				break
			end 
			
			-- нет ли уже созданного задания?
			-- Создаем одно задание на каждый обмен и каждый склад
			set @nDraftUniq = Null
			select @nDraftUniq = Uniq
				from	WHDrafts
				where	DraftType = 'U' and 
						--datediff(day, DateConfirm, @dDateConfirm) = 0 and 
						DateDraft = @dExchangeDateTime and 
						Depot = @nDepotUniq and 
						Note = 'WMS'
			if @nDraftUniq is Null begin
				-- не нашлось задания. добавляем новое
				insert	WHDrafts
					(DateDraft, DraftType, Depot, 
					IndentPerson, DateArrange, DatePrint, 
					DateConfirm, ConfirmPerson, FullConfirm, BrigadeStore, CoefficientStore, 
					Note)
					select	@dExchangeDateTime, 'U', @nDepotUniq, 
						0 as IndentPerson, T.DateBirth as DateArrange, Null as DatePrint, 
						T.DateConfirm, 0 as ConfirmPerson, 1 as FullConfirm, 
						Null as BrigadeStore, 0 as CoefficientStore, 
						'WMS' as Note
					from	#Traffics T
					where	T.ID = @nTrafficID
				select	@nDraftUniq = @@Identity, @nERPError = @@Error
				if @nERPError <> 0 break
			end
			
			-- 2.2. добавляем расшифровку задания - на подъем контейнера
			insert	WHDraftsGoods
				(WHDraft, Cell, CellAddress, 
				Packing, QntWished, QntConfirmed, DateValid)
				select	@nDraftUniq, @nCellUniq, @cCellAddress, 
						T.ERPPacking, T.Qnt, T.Qnt, T.DateValid
					from	#Traffics T 
					inner join Packings Ps on T.ERPPacking = Ps.Uniq -- !!!
					where	T.ID = @nTrafficID
			select	@cERPCode = @@Identity, @nERPError = @@Error
			if @nERPError <> 0 break
			
			-- 2.3. исправляем наполнение ячейки
			update	WHStorage
				set		Depot = @nDepotUniq, 
						Packing = T.ERPPacking, Qnt = T.Qnt, DateValid = T.DateValid, 
						State = 'S' 
				from	#Traffics T 
				inner join Packings Ps on T.ERPPacking = Ps.Uniq -- !!!
				where	WHStorage.Uniq = @nCellUniq and T.ID = @nTrafficID
			select @nERPError = @@Error
			if @nERPError <> 0 break
			
			-- 2.4. поднимаем признак успешной передачи записи в Trd
			update	#Traffics
				set		ERPTraffic = @cERPCode
				where	ID = @nTrafficID
			select @nERPError = @@Error
			if @nERPError <> 0 break
			
			-- Увеличиваем счетчик записей
			set @nCount = @nCount + 1
			
			fetch next from T_cursor into @nTrafficID, @dDateConfirm, 
										  @nOwner, @nWMSGoodState, @bWMSGoodStateBasic 
		end
		
		close T_cursor
		deallocate T_cursor
		
		if @nERPError <> 0 goto Tr_Error
	end
	PRINT 'TrafficsFrames Sent: ' + ltrim(str(@nCount))
	-- Закончили работу с перемещениями
	
	-- 3) Начинаем работу с ошибками
	set @nCount = 0
	declare @nChangeID int, @dDateEdit smalldatetime
	
	-- Переменные для сохранения текущего состояния ячейки
	declare @nCurCellDepot int, 
			@nCurCellPacking int, 
			@nCurCellQnt decimal(18,3), 
			@dCurCellDateValid smalldatetime, 
			@cCurCellState char(1)
	
	if exists (select ID from #Changes) begin
		-- идем по выполненным операциям исправления ошибок в ячейках 
		declare H_cursor cursor for 
			select	ID, DateEdit, ERPOwner, ERPGoodState, GoodStateBasic  
				from	#Changes 
				order by DateEdit, ID
		open H_cursor
		fetch next from H_cursor into @nChangeID, @dDateEdit,  
									  @nOwner, @nWMSGoodState, @bWMSGoodStateBasic 
		while @@fetch_status = 0 begin
			-- 3.1. создаем новую запись - исправление ошибки 
			
			-- определяем виртуальный склад
			set	@nDepotUniq = Null 
			select top 1 @nDepotUniq = Uniq
				from	Depots 
				where	Owner = @nOwner and
						WMSGoodState = @nWMSGoodState and 
						Actual = 1
			if @nDepotUniq is Null 
				select top 1 @nDepotUniq = Uniq
					from	Depots 
					where	Owner = @nOwner and
							WMSGoodState = @nWMSGoodState and 
							Actual = 0
			if @nDepotUniq is Null begin
				-- так и не нашелся склад
				-- ДОБАВЛЯЕМ СКЛАД!
				select	@cDepotName = P.Alias
					from	Partners P
					where	P.Uniq = @nOwner
				select	@cDepotName = isNull(@cDepotName, '') + ' ' + GS.Alias
					from	WMSGoodsStates GS
					where	GS.Uniq = @nWMSGoodState
				select	@cDepotName = isNull(@cDepotName, '') + ' (WMS)'
				
				insert	Depots 
					(Alias, Name, Owner, Basic, NoControl, Actual, Deposit, WMSGoodState)
					select	left(@cDepotName, 25) as Alias,  
						left(@cDepotName, 25) as Name, 
						@nOwner as Owner, 
						@bWMSGoodStateBasic, 
						case when @nOwner = @nWeUniq then 1 else 0 end as NoControl, 
						1 as Actual, 
						case when @nOwnerUniq = @nWeUniq then 0 else 1 end as Deposit, 
						@nWMSGoodState as WMSGoodState
				select	@nDepotUniq = @@Identity, @nERPError = @@Error
				if @nERPError <> 0 break
			end
			
			-- определяем ячейку
			set	@nCellUniq = Null
			select	@nCellUniq = S.Uniq, @cCellAddress = H.CellAddress
				from	WHStorage S, #Changes H
				where	S.Address = H.CellAddress and	
						H.ID = @nChangeID
			if @nCellUniq is Null begin 
				set	@nERPError = -2	-- не найдена ячейка с адресом
				break
			end
			
			-- Сохраняем текущее состояние ячейки
			select	@nCurCellDepot = Depot, 
					@nCurCellPacking = Packing, 
					@nCurCellQnt = Qnt, 
					@dCurCellDateValid = DateValid, 
					@cCurCellState = State 
				from WHStorage 
				where Uniq = @nCellUniq
			if @@Error <> 0 break
			
			insert	WHStorageErrors 
				(ErrorDate, Cell, Depot, 
				State_B, Qnt_B, Packing_B, DateValid_B, 
				State_E, Qnt_E, Packing_E, DateValid_E, 
				ActDate, Number, UserID)
				select	@dDateEdit, @nCellUniq, @nDepotUniq, 
						@cCurCellState, @nCurCellQnt, @nCurCellPacking, @dCurCellDateValid, 
						'S', @nCurCellQnt + H.Qnt, H.ERPPacking, H.DateValid, 
						@dDateEdit as ActDate, 'WMS' as Number, 0 as UserID
				from	#Changes H
				inner join Packings Ps on H.ERPPacking = Ps.Uniq -- !!! 
				where	H.ID = @nChangeID
			select	@cERPCode = @@Identity, @nERPError = @@Error
			if @nERPError <> 0 break
			
			-- 3.2. исправляем наполнение ячейки
			update	WHStorage 
				set		Depot = @nDepotUniq, 
						Packing = H.ERPPacking, 
						Qnt = @nCurCellQnt + H.Qnt, 
						DateValid = H.DateValid 
				from	#Changes H 
				inner join Packings Ps on H.ERPPacking = Ps.Uniq 
				where	WHStorage.Uniq = @nCellUniq and H.ID = @nChangeID
			select @nERPError = @@Error
			if @nERPError <> 0 break
			
			-- если получилось количество = 0 - очищаем ячейку
			update	WHStorage
				set		Depot = Null, 
						Packing = Null, Qnt = Null, DateValid = Null
				where	Uniq = @nCellUniq and Qnt = 0
			select @nERPError = @@Error
			if @nERPError <> 0 break
			
			-- 3.3. поднимаем признак успешной передачи записи в Trd
			update	#Changes 
				set		ERPChange = @cERPCode
				where	ID = @nChangeID
			select @nERPError = @@Error
			if @nERPError <> 0 break
			
			-- Увеличиваем счетчик записей
			set @nCount = @nCount + 1
			
			fetch next from H_cursor into @nChangeID, @dDateEdit, 
										  @nOwner, @nWMSGoodState, @bWMSGoodStateBasic 
		end
		
		close H_cursor
		deallocate H_cursor
		
		if @nERPError <> 0 goto Tr_Error
	end 
	PRINT 'Changes Sent: ' + ltrim(str(@nCount))
	-- Закончили работу с ошибками
	
	-- 4) Забираем полученные коды из БД Trd обратно в БД Wms
	update	WMS.dbo.Cells 
		set ERPCode = isNull(C.Address, '')
		from	#Cells C 
		where	WMS.dbo.Cells.ID = C.ID and 
				WMS.dbo.Cells.ERPCode is Null and 
				len(C.Address) > 0
	if @@Error <> 0 goto Tr_Error
	
	update	WMS.dbo.TrafficsFrames 
		set ERPCode = isNull(T.ERPTraffic, '') 
		from	#Traffics T 
		where	WMS.dbo.TrafficsFrames.ID = T.ID and 
				WMS.dbo.TrafficsFrames.ERPCode is Null and 
				len(T.ERPTraffic) > 0
	if @@Error <> 0 goto Tr_Error
	
	update	WMS.dbo.CellsChanges 
		set	ERPCode = isNull(ERPChange, '') 
		from	#Changes H 
		where	WMS.dbo.CellsChanges.ID = H.ID and 
				WMS.dbo.CellsChanges.ERPCode is Null and 
				len(H.ERPChange) > 0
	if @@Error <> 0 goto Tr_Error

commit tran
return

Tr_Error:
raiserror('Ошибка %d', 16, 1, @nERPError)
rollback
return