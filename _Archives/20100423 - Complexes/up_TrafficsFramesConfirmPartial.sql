set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go
ALTER PROCEDURE [dbo].[up_TrafficsFramesConfirmPartial]
	@nTrafficID			int,					-- код траффика
	@bSuccess			bit,					-- завершено успешно?
	@nCellFinishID		int,					-- код ячейки, в которую в итоге поставлен контейнер
	@nTrafficErrorID	int = Null,				-- код ошибки завершения (для НЕуспешного завершения)
	@nQnt				decimal(12, 3),			-- количество товара, перемещаемого в финишную ячейку 
	@nNewTrafficID		int = Null output,		-- код созданного трафика
	@nError				int = 0 output,			-- ошибка при подтверждении
	@cErrorStr			varchar(200) = '' output
AS
-- подтверждение выполнения операции транспортировки контейнера
-- если финишная ячейка является ячейкой пикинга, в нее перекладывается указанное кол-во товара из контейнера,
-- а для контейнера подбирается новое место и создается новый трафик

set nocount on

if @bSuccess = 1 and @nTrafficErrorID is not Null begin
	select	@nError = -10, 
			@cErrorStr = 'Задан код ошибки при успешном завершении операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + '...'
	raiserror(@cErrorStr, 16, 1)
	return
end

-- операция: существует? еще не подтверждена?
declare @dDateConfirm smalldatetime, 
		@nCellSourceID int, @nCellTargetID int, 
		@nFrameID int, 
		@nPriority int, @nByOrder int, @cERPCode varchar(max), 
		@nOutputID int, 
		@nOutputGoodID int, 
		@bCreateNewIfError bit, 
		@bIsFull bit, 
		@nComplexID int

select	@dDateConfirm = DateConfirm, 
		@nCellSourceID = CellSourceID, 
		@nCellTargetID = CellTargetID, 
		@nFrameID = FrameID, 
		@nPriority = Priority, 
		@nByOrder = ByOrder, 
		@cERPCode = ERPCode, 
		@nOutputID = OutputID, 
		@nOutputGoodID = OutputGoodID, 
		@bCreateNewIfError = CreateNewIfError
	from	TrafficsFrames with (nolock) 
	where	ID = @nTrafficID

if @@RowCount = 0 begin
	select	@nError = -1, 
			@cErrorStr = 'Не найдена операция транспортировки с кодом ' + ltrim(str(@nTrafficID)) + '...'
	raiserror(@cErrorStr, 16, 1)
	return
end

if @dDateConfirm is not Null begin
	select	@nError = -2, 
			@cErrorStr = 'Операция транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' уже подтверждена...'
	raiserror(@cErrorStr, 16, 1)
	return
end

declare @bForFrames bit, @bForStorage bit, @bForPicking bit,  
		@bLocked bit, @bActual bit, 
		@bDeleted bit, @bSpecial bit, @nMaxPalletQnt numeric(9, 2)

-- проверки ячеек для УДАЧНОГО подтверждения
if @bSuccess = 1 begin
	-- начальная ячейка: существует? актуальна? не блокирована? не удалена? предназначена для коробок/штук?
	select	@bForFrames = SZT.ForFrames, 
			@bLocked = C.Locked, @bActual = C.Actual, 
			@bDeleted = C.Deleted, @bSpecial = SZT.Special 
		from Cells C with (nolock) 
		inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
		inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
		where C.ID = @nCellSourceID
	if @@RowCount = 0 begin
		select	@nError = -11, 
				@cErrorStr = 'Начальная ячейка для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' не найдена...'
		raiserror(@cErrorStr, 16, 1)
		return
	end
	if @bActual = 0 begin
		select	@nError = -12, 
				@cErrorStr = 'Начальная ячейка для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' не актуальна...'
		raiserror(@cErrorStr, 16, 1)
		return
	end
	if @bLocked = 1 and @bSpecial = 0 begin
		select	@nError = -13, 
				@cErrorStr = 'Начальная ячейка для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' блокирована...'
		raiserror(@cErrorStr, 16, 1)
		return
	end
	if @bDeleted = 1 begin
		select	@nError = -14, 
				@cErrorStr = 'Начальная ячейка для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' удалена...'
		raiserror(@cErrorStr, 16, 1)
		return
	end
	if @bForFrames is not Null and @bForFrames = 0 begin
		-- ячейка - для контейнеров 
		select	@nError = -15, 
				@cErrorStr = 'Начальная ячейка для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' не предназначена для контейнеров...'
		raiserror(@cErrorStr, 16, 1)
		return
	end
	
	-- финишная ячейка: существует? актуальна? не блокирована? не удалена? предназначена для коробок/штук?
	select	@bForFrames = SZT.ForFrames, @bForStorage = SZT.ForStorage, 
			@bForPicking = SZT.ForPicking, 
			@bLocked = C.Locked, @bActual = C.Actual, @bDeleted = C.Deleted, @bIsFull = IsFull, 
			@nMaxPalletQnt = IsNull(IsNull(C.MaxPalletQnt, SZ.MaxPalletQnt), 999999) 
		from Cells C with (nolock) 
		inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
		inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
		where C.ID = @nCellFinishID
	if @@RowCount = 0 begin
		select	@nError = -21, 
				@cErrorStr = 'Финишная ячейка для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' не найдена...'
		raiserror(@cErrorStr, 16, 1)
		return
	end
	if @bActual = 0 begin
		select	@nError = -22, 
				@cErrorStr = 'Финишная ячейка для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' не актуальна...'
		raiserror(@cErrorStr, 16, 1)
		return
	end
	if @bLocked = 1 begin
		select	@nError = -23, 
				@cErrorStr = 'Финишная ячейка для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' блокирована...'
		raiserror(@cErrorStr, 16, 1)
		return
	end
	if @bDeleted = 1 begin
		select	@nError = -24, 
				@cErrorStr = 'Финишная ячейка для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' удалена...'
		raiserror(@cErrorStr, 16, 1)
		return
	end

	-- контейнер: существует? актуален? не блокирован? не удален? находится в ячейке-источнике?
	declare @bFrameActual bit, @bFrameLocked bit, @cFrameState varchar(1), 
			@nOwnerID int, @nGoodStateID int --, @nPackingID int 
	select  @nOwnerID = OwnerID, 
			@nGoodStateID = GoodStateID, 
			@bFrameActual = Actual, 
			@bFrameLocked = Locked, 
			@cFrameState = State 
		from	Frames with (nolock) 
		where	ID = @nFrameID
	if @@RowCount = 0 begin
		select	@nError = -31, 
				@cErrorStr = 'Контейнер для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' не найден...'
		raiserror(@cErrorStr, 16, 1)
		return
	end
	if @bFrameActual = 0 begin
		select	@nError = -32, 
				@cErrorStr = 'Контейнер для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' не актуален...'
		raiserror(@cErrorStr, 16, 1)
		return
	end
	if @bFrameLocked = 1 begin
		select	@nError = -33, 
				@cErrorStr = 'Контейнер для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' блокирован...'
		raiserror(@cErrorStr, 16, 1)
		return
	end
	if @cFrameState = 'D' begin
		select	@nError = -34, 
				@cErrorStr = 'Контейнер для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' удален...'
		raiserror(@cErrorStr, 16, 1)
		return
	end
	
	select	ID 
		from	CellsContents with (nolock) 
		where	CellID = @nCellSourceID and FrameID = @nFrameID
	if @@RowCount = 0 begin
		select	@nError = -33, 
				@cErrorStr = 'Контейнер для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' находится не в начальной ячейке...'
		raiserror(@cErrorStr, 16, 1)
		return
	end
	
	-- закрепление конечной ячейки?
	declare @nFixedOwnerID int, @nFixedGoodStateID int, @nFixedPackingID int
	select  @nFixedOwnerID = FixedOwnerID, 
			@nFixedGoodStateID = FixedGoodStateID, 
			@nFixedPackingID = FixedGoodStateID 
		from	Cells with (nolock) 
		where	ID = @nCellFinishID 
	if	@nFixedOwnerID is not Null		and IsNull(@nFixedOwnerID, -1) <> IsNull(@nOwnerID, -1) or 
		@nFixedGoodStateID is not Null	and IsNull(@nFixedGoodStateID, -1) <> IsNull(@nGoodStateID, -1) /*or 
		@nFixedPackingID is not Null	and IsNull(@nFixedPackingID, -1) <> IsNull(@nPackingID, -1) */ begin
		select	@nError = -34, 
				@cErrorStr = 'Финишная ячейка для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' закреплена за другим владельцем/состоянием...'
		raiserror(@cErrorStr, 16, 1)
		return
	end
	
	-- в ячейке лежит другой товар?
	if @bForStorage = 1 begin
		declare @nPackingID_ int
		select  top 1 @nPackingID_ = PackingID 
			from	CellsContents with (nolock) 
			where	FrameID = @nFrameID
		if exists (select ID 
					from CellsContents 
					where CellID = @nCellFinishID and PackingID <> @nPackingID_) begin
			select	@nError = -35, 
					@cErrorStr = 'Финишная ячейка для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' содержит другой товар...'
			raiserror(@cErrorStr, 11, 1)
			return
		end 
	end 
	
	-- в контейнере нет указанного количества товара
	if @nQnt > 0 begin
		if (select count(ID) from CellsContents with (nolock) where FrameID = @nFrameID) > 1 begin
			select	@nError = -41, 
					@cErrorStr = 'Контейнер в операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' содержит несколько товаров...'
			raiserror(@cErrorStr, 11, 1)
			return
		end
		if (select count(ID) from CellsContents with (nolock) where FrameID = @nFrameID) < 1 begin
			select	@nError = -42, 
					@cErrorStr = 'Контейнер в операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' не содержит товар...'
			raiserror(@cErrorStr, 11, 1)
			return
		end 
		
		if (select top 1 Qnt from CellsContents (nolock) where FrameID = @nFrameID) < @nQnt begin
			select	@nError = -43, 
					@cErrorStr = 'Контейнер в операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' не содержит указанного количества товара...'
			raiserror(@cErrorStr, 11, 1)
			return
		end
		
		if @bForPicking = 0 begin
			select	@nError = -44, 
					@cErrorStr = 'Финишная ячейка для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' (с указанием перемещаемого количества) не является ячейкой пикинга...'
			raiserror(@cErrorStr, 16, 1)
			return
		end
		
		-- думается, следующая проверка не нужна. Какая разница, вмещает конечная ячейка палетту или больше или меньше - 
		-- мы просто хотим переложить в нее сколько-то товара и запихать контейнер обратно. 
		/*
		if @nMaxPalletQnt >= 1 begin
			select	@nError = -45, 
					@cErrorStr = 'Финишная ячейка для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' (с указанием перемещаемого количества) вмещает более одной паллеты...'
			raiserror(@cErrorStr, 16, 1)
			return
		end
		*/
	end
	else begin
		-- @nQnt = 0 
		if dbo.GetFramesQntInCell(@nCellFinishID) + 1 > @nMaxPalletQnt begin
			-- еще один контейнер не влезет 
			select	@nError = -51, 
					@cErrorStr = 'Контейнер не может быть размещен в финишной ячейке для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' (ограничение по количеству контейнеров)...'
			raiserror(@cErrorStr, 16, 1)
			return
		end
		if @bIsFull = 1 begin
			select	@nError = -52, 
					@cErrorStr = 'Финишная ячейка для операции транспортировки с кодом ' + ltrim(str(@nTrafficID)) + ' заполнена...'
			raiserror(@cErrorStr, 16, 1)
			return
		end
	end
end
else begin
	select  @nOwnerID = OwnerID, 
			@nGoodStateID = GoodStateID, 
			@bFrameActual = Actual 
		from	Frames with (nolock) 
		where	ID = @nFrameID
end -- все проверки выполнены 

-- ячейка Lost&Found
declare @nLostFoundCellID int, @cLostFoundAddress varchar(20), 
		@cLostFoundCellID varchar(20)
select	@cLostFoundAddress = .dbo._SettingsGetValue('sLostFoundAddress')
if IsNull(@cLostFoundAddress, '') = '' begin
	select	@nError = -101, 
			@cErrorStr = 'Не задан адрес виртуальной ячейки Lost&Found...'
	goto Tr_Error
end 
select	@nLostFoundCellID = ID, 
		@cLostFoundCellID = ltrim(str(ID)) 
	from Cells 
	where	Address = @cLostFoundAddress
if IsNull(@nLostFoundCellID, 0) = 0 begin
	select	@nError = -102, 
			@cErrorStr = 'Не найдена виртуальная ячейка (Lost&Found) с адресом ' + @cLostFoundAddress + '...'
	goto Tr_Error
end

-- Выполнять ли подбор ячейки для размещения контейнера
declare @bNewFrameArrange bit 
set @bNewFrameArrange = 0

declare @bForInputs bit, @bForOutputs bit
begin transaction
	if @bSuccess = 0 begin
		-- НЕудачное завершение. 
		-- дата подтверждения в операции и "-"статус в операции
		-- Ничего никуда не перемещается, кроме случая TrafficsFramesErrors.Severity < 0 (в Lost&Found)
		-- Если в таблице ошибок TrafficsFramesErrors: 
			-- LockCellTarget = true, то блокируем ячейку назначения
			-- LockCellSource = true, то блокируем ячейку исходную
			-- LockFrame = true, то блокируем контейнер
		update	TrafficsFrames 
			set		DateConfirm = GetDate(), 
					Success = 0, 
					ErrorID = @nTrafficErrorID 
			where	ID = @nTrafficID
		set @nError = @@Error
		if @nError <> 0 goto Tr_Error
		
		declare @nFrameStartID int, @nCellStartID int
		select  @nFrameStartID = @nFrameID, @nCellStartID = @nCellSourceID
		
		-- проверяем специальный код ошибки (TrafficsFramesErrors.Severity < 0)
		-- и признак блокировки
		declare @nSeverity int, @bLockFrame bit, 
				@bLockCellSource bit, @bLockCellTarget bit
		select @nSeverity = Severity, 
				@bLockFrame	= LockFrame, 
				@bLockCellSource = LockCellSource, 
				@bLockCellTarget = LockCellTarget 
			from TrafficsFramesErrors with (nolock) 
			where ID = @nTrafficErrorID
		
		if @nSeverity < 0 begin
			-- специальный код ошибки:
			-- "перемещаем" контейнер в ячейку Lost&Found
			
			-- добавляем записи об изменении состояния ячеек
			declare @cNote1 varchar(2000), @cNote2 varchar(2000), 
					@cTrafficErrorName varchar(200), @nParentID int
			select	@cTrafficErrorName = Name 
				from TrafficsFramesErrors 
				where ID = @nTrafficErrorID
			select	@cNote1 = 'подтверждение транспортировки (ID ' + ltrim(str(@nTrafficID)) + ') с ошибкой "' + @cTrafficErrorName + '": ' + 
							'контейнер ' + ltrim(str(@nFrameID)) + ' "удален" из ячейки ' + C.Address + ' (ID ' + ltrim(str(@nCellSourceID)) + ') ' +
							'для "перемещения" в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ')',  
					@cNote2 = 'подтверждение транспортировки (ID ' + ltrim(str(@nTrafficID)) + ') с ошибкой "' + @cTrafficErrorName + '": ' + 
							'контейнер ' + ltrim(str(@nFrameID)) + ' "перемещен" из ячейки ' + C.Address + ' (ID ' + ltrim(str(@nCellSourceID)) + ') ' +
							'в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ')' 
				from Cells C 
				where C.ID = @nCellSourceID
			insert CellsChanges 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
					DateEdit, Note, UserID, DeviceID, ParentID) 
				select	@nCellSourceID, @nFrameID, 
						CC.OwnerID, CC.GoodStateID, CC.PackingID, -CC.Qnt, CC.DateValid, 
						GetDate(), @cNote1, 
						T.UserID, T.DeviceID, 
						@nParentID 
					from TrafficsFrames T 
					inner join CellsContents CC on CC.CellID = @nCellSourceID and CC.FrameID = @nFrameID 
					where T.ID = @nTrafficID
			select	@nParentID = @@Identity
			insert CellsChanges 
					(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
					DateEdit, Note, UserID, DeviceID, ParentID) 
				select	@nLostFoundCellID, @nFrameID, 
						CC.OwnerID, CC.GoodStateID, CC.PackingID, CC.Qnt, CC.DateValid, 
						GetDate(), @cNote2, 
						T.UserID, T.DeviceID, 
						@nParentID 
					from TrafficsFrames T 
					inner join CellsContents CC on CC.CellID = @nCellSourceID and CC.FrameID = @nFrameID 
					where T.ID = @nTrafficID
			
			-- переписываем весь контейнер из текущей ячейки в ячейку Lost&Found
			update  CellsContents 
				set		CellID = @nLostFoundCellID, DateLastOperation = GetDate() 
				where	CellID = @nCellSourceID and FrameID = @nFrameID
			
			-- очищаем статус контейнера
			update Frames 
				set	State = '', HasTraffic = 0, DateLastOperation = GetDate() 
				where ID = @nFrameID
			set @nError = @@Error
			if @nError <> 0 goto Tr_Error
			-- end: специальный код ошибки
		end
		else begin
			-- подтверждение с обычной ошибкой
			
			-- если это трафик для расхода или требующий генерации повторной транспортировки, 
			-- генерируется повторный(ные) трафик на паллету + 
			-- возможно, перемещение недостающих коробок/штук (Critical) - для расхода
			if @nOutputGoodID is not Null or @bCreateNewIfError = 1 begin
				declare @nPackingID int, @nCnt int, @dDateValid smalldatetime, 
						@nQntOld decimal(15, 3), @nQntNew decimal(15, 3), @nQntFound decimal(15, 3)
				select @nCnt = count(distinct PackingID) 
					from CellsContents 
					where FrameID = @nFrameID
				if @nCnt = 1 begin
					-- только для моноконтейнеров
					select @nPackingID = max(PackingID), @nQntOld = sum(Qnt), @nQntNew = 0 
						from CellsContents 
						where FrameID = @nFrameID
					
					if @nOutputGoodID is not Null begin
						-- уменьшить подобранное количество в расходе
						update OutputsGoods 
							set QntSelected = QntSelected - @nQntOld 
							where ID = @nOutputGoodID
						set @nError = @@Error
						if @nError <> 0 goto Tr_Error
					end
					
					declare @nCellTempID int
					set @nCellTempID = (case when @bLockCellSource = 1 then @nCellSourceID else @nCellTargetID end) 
					select @nComplexID = SZ.ComplexID 
						from Cells C with (nolock) 
						inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
						where C.ID = @nCellTempID
					
					declare @nFrameNewID int, @nCellSourceNewID int
					while @nQntNew < @nQntOld begin
						-- подбираем новый контейнер (на замену старому)
						select @nFrameNewID = Null, @nCellSourceNewID = Null
						exec up_CellOneSelection @nPackingID, @nCellSourceNewID output, @nOwnerID, @nGoodStateID, 
							Null, Null, @nComplexID
						set @nError = @@Error
						if @nError <> 0 goto Tr_Error
						
						if (@nCellSourceNewID is not Null and @nCellSourceNewID > 0) begin
							-- нашли новый контейнер на замену
								select top 1 @nFrameNewID = CC.FrameID, @dDateValid = DateValid, 
									@nQntFound = CC.Qnt, @nQntNew = @nQntNew + CC.Qnt 
								from CellsContents CC 
								inner join Frames F on F.ID = CC.FrameID 
								where	CC.CellID = @nCellSourceNewID and 
										CC.PackingID = @nPackingID and 
										F.HasTraffic = 0 
								order by ByOrder 
							
							declare @cNoteX varchar (200)
							set @cNoteX = 'Операция добавлена при подтверждении с ошибкой транспортировки с кодом ' + ltrim(str(@nTrafficID))
							exec up_TrafficsFramesOneCreate 
								@nFrameNewID, @nCellSourceNewID, @nCellTargetID, @nPriority, 
								Null, @nOutputID, @nOutputGoodID, 1, 
								@cNoteX, 
								@nError output, 
								@nTrafficID output
							if @nError <> 0 begin
								set @nError = @nError - 100
								goto Tr_Error
							end
							
							if @nOutputGoodID is not Null begin
								-- увеличить подобранное количество в расходе
								update OutputsGoods 
									set QntSelected = QntSelected + @nQntFound 
									where ID = @nOutputGoodID 
								set @nError = @@Error
								if @nError <> 0 goto Tr_Error
							end
						end
						else begin
							-- не нашли никакого контейнера на замену
							break
						end
					end
				end
				
				if @nQntNew < @nQntOld and @nOutputGoodID is not Null begin
					-- нашли меньше чем было в старом контейнере. добавляем перемещение на остаток коробок из пикинга
					-- ищем ячейку пикинга
					declare @nCellPickingID int
					set @nCellPickingID = Null
					select @nCellPickingID = C.ID 
						from Cells C 
						inner join StoresZones  SZ  on SZ.ID = C.StoreZoneID 
						inner join StoresZonesTypes SZT on SZT.ID = SZ.StoreZoneTypeID 
						where SZT.ForPicking = 1 and C.Deleted = 0 and 
							C.FixedPackingID = @nPackingID and C.FixedGoodStateID = @nGoodStateID and 
							IsNull(C.FixedOwnerID, -1) = IsNull(@nOwnerID, -1)
					if @nCellPickingID is Null begin
						-- не нашли жестко закрепленной за товаром ячейки пикинга, ищем динамически закрепленную
						select top 1 @nCellPickingID = CellID 
								from CellsContents CC 
								inner join Cells C on C.ID = CC.CellID 
								inner join StoresZones SZ on SZ.ID = C.StoreZoneID 
								inner join StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT.ID 
								where SZT.ForPicking = 1 and C.Deleted = 0 and 
									CC.PackingID = @nPackingID and C.Deleted = 0 and 
									CC.GoodStateID = @nGoodStateID and 
									IsNull(CC.OwnerID, -1) = IsNull(@nOwnerID, -1)
								order by C.Address
					end
					if @nCellPickingID is not Null begin
						declare @nQntInPicking decimal(15, 3), @nQntGot decimal(15, 3)
						set @nQntInPicking = IsNull(dbo.GetPickingCellGoodQnt(@nCellPickingID, @nPackingID, @nOwnerID, @nGoodStateID), 0)
						if @nQntInPicking > (@nQntOld - @nQntNew)
							-- в пикинге достаточно товара. возьмем сколько у нас не хватило
							set @nQntGot = @nQntOld - @nQntNew
						else
							-- в пикинге недостаточно товара. возьмем все, сколько там есть
							set @nQntGot = @nQntInPicking
						declare @cNoteY varchar (200)
						set @cNoteY = 'Операция добавлена при подтверждении с ошибкой транспортировки КОНТЕЙНЕРА с кодом ' + ltrim(str(@nTrafficID))
						exec up_TrafficsGoodsOneCreate @nOwnerID, @nGoodStateID, @nPackingID, @nQntGot, Null, 
							@nCellPickingID, @nCellTargetID, Null, @nOutputID, @nOutputGoodID, NoteY, 
							@nError output, @nTrafficID output
						if @nError <> 0 goto Tr_Error
						update TrafficsGoods set Critical = 1 where ID = @nTrafficID		
						update OutputsGoods 
							set QntSelected = QntSelected + @nQntGot 
							where ID = @nOutputGoodID
						if @nError > 0 goto Tr_Error
					end
				end
			end
			-- статус контейнера - хранение, приход, расход, ... - в зависимости от ячейки, в которой остался контейнер 
			select	@bForFrames  = SZT.ForFrames, 
					@bForStorage = SZT.ForStorage, 
					@bForInputs  = SZT.ForInputs, 
					@bForOutputs = SZT.ForOutputs 
				from Cells C 
				inner join StoresZones SZ on C.StoreZoneID = SZ.ID 
				inner join StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT.ID 
				where C.ID = @nCellStartID
			update Frames 
				set	State = case when @bForStorage = 1 then 'S' 
								 when @bForInputs  = 1 then 'I' 
								 when @bForOutputs = 1 then 'O' 
								 else '' 
							end, 
					HasTraffic = 0, 
					DateLastOperation = GetDate() 
				where ID = @nFrameStartID
			set @nError = @@Error
			if @nError <> 0 goto Tr_Error
		end
		
		-- Блокировка ячейки (если задано типом ошибки и ячейка заданного типа)
		declare @cCellType varchar(10)
		if @bLockCellSource > 0 begin
			select @cCellType = SZT.ShortCode 
				from Cells C with (nolock) 
				inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
				inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
				where C.ID = @nCellStartID
			if @cCellType in ('STOR', 'RILL') begin
				update Cells set Locked = 1 
					where ID = @nCellStartID
				set @nError = @@Error
				if @nError <> 0 goto Tr_Error
			end
		end
		if @bLockCellTarget > 0 begin
			select @cCellType = SZT.ShortCode 
				from Cells C with (nolock) 
				inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
				inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
				where C.ID = @nCellFinishID
			if @cCellType in ('STOR', 'RILL') begin
				update Cells set Locked = 1 
					where ID = @nCellFinishID
				set @nError = @@Error
				if @nError <> 0 goto Tr_Error
			end
		end
		if @bLockFrame > 0 begin
			update Frames set Locked = 1 
				where ID = @nFrameStartID
			set @nError = @@Error
			if @nError <> 0 goto Tr_Error
		end
		-- end: подтверждение с ошибкой
	end
	else begin
		-- подтверждение успешное
		
		-- если финишная ячейка предназначена для контейнера - просто переложить его содержимое в эту ячейку
		-- если финишная ячейка не предназначена для контейнера - 
			-- если не задано количество - раздербанить контейнер и добавить его содержимое к этой ячейке
			-- если задано количество - переложить это количество в эту ячейку, 
									--  переложить контейнер в Lost&Found,
									--  подобрать для него новое место
									--  создать трафик для перемещения его в новое место
		--- PARTIAL ---
		select	@bForFrames  = SZT.ForFrames, 
				@bForStorage = SZT.ForStorage, 
				@bForInputs  = SZT.ForInputs, 
				@bForOutputs = SZT.ForOutputs, 
				@bForPicking = SZT.ForPicking, 
				@nComplexID = SZ.ComplexID 
			from Cells C 
			inner join StoresZones SZ on C.StoreZoneID = SZ.ID 
			inner join StoresZonesTypes SZT on SZ.StoreZoneTypeID = SZT.ID 
			where C.ID = @nCellFinishID
		set @nError = @@Error
		if @nError <> 0 goto Tr_Error
		
		-- (att) добавлено для нормального сохранения OutputsItems
		-- текущее наполнение контейнера
		select	CC.GoodStateID, CC.PackingID, CC.Qnt, CC.DateValid 
			into #CellsContents_Cur 
			from CellsContents CC 
			where CC.FrameID = @nFrameID
		-- (att end)
		
		if @bForFrames is not Null and @bForFrames = 0 begin
			-- ячейка - для товаров россыпью
			
			if @nQnt = 0 or @bForPicking = 0 begin
				-- содержимое контейнера 
				select	* 
					into	#FramesContents 
					from	CellsContents 
					where	FrameID = @nFrameID
				set @nError = @@Error
				if @nError <> 0 goto Tr_Error
				
				declare @nCCPackingID int, @nCCQnt numeric(18, 3), @dCCDateValid smalldatetime, @nFinishCellContentID int
				declare CC_cursor cursor for 
					select	PackingID, Qnt, DateValid 
						from	#FramesContents
				open CC_cursor
				
				fetch next from CC_cursor into @nCCPackingID, @nCCQnt, @dCCDateValid
				while @@fetch_status = 0 begin
					set @nFinishCellContentID = Null
					-- кладем товар в конечную ячейку 
					select	top 1 @nFinishCellContentID = ID 
						from	CellsContents 
						where	CellID = @nCellFinishID and 
								IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1) and 
								GoodStateID = @nGoodStateID and 
								PackingID = @nCCPackingID
					if @nFinishCellContentID is Null begin
						-- в конечной ячейке не было такого содержимого
						insert CellsContents 
							(CellID, FrameID, OwnerID, GoodStateID, 
							PackingID, Qnt, DateValid, DateLastOperation) 
							select	@nCellFinishID, Null, @nOwnerID, @nGoodStateID, 
									@nCCPackingID, @nCCQnt, Null, GetDate()
						set @nError = @@Error
						if @nError <> 0 begin
							close CC_cursor
							deallocate CC_cursor
							goto Tr_Error
						end
					end
					else begin
						-- в конечной ячейке уже есть такое содержимое
						update	CellsContents 
							set		Qnt = Qnt + @nCCQnt, 
									DateLastOperation = GetDate() 
							where	ID = @nFinishCellContentID
						set @nError = @@Error
						if @nError <> 0 begin
							close CC_cursor
							deallocate CC_cursor
							goto Tr_Error
						end
					end
					
					fetch next from CC_cursor into @nCCPackingID, @nCCQnt, @dCCDateValid
				end
				
				close CC_cursor
				deallocate CC_cursor
				
				-- очищаем старые записи содержимого контейнера
				delete CellsContents 
					where	FrameID = @nFrameID
				set @nError = @@Error
				if @nError <> 0 goto Tr_Error
				
				-- и делаем сам контейнер неактуальным
				update	Frames set 
					OwnerID = Null, 
					GoodStateID = Null, 
					PalletTypeID = Null, 
					FrameHeight = 0.0, 
					Actual = 0, 
					State = 'D', 
					HasTraffic = 0, 
					DateLastOperation = GetDate() 
					where	ID = @nFrameID
				set @nError = @@Error
				if @nError <> 0 goto Tr_Error
			end -- @nQnt = 0 or @bForPicking = 0
			else begin
				-- @nQnt > 0 and @bForPicking = 1
				
				-- 1) перекладываем указанное количество товара в конечную ячейку 
				declare @nFrameCellContentID_Partial int, 
						@nPackingID_Partial int, @bWeighting_Partial bit, 
						@nFinishCellContentID_Partial int
				select top 1 @nFrameCellContentID_Partial = ID, @nPackingID_Partial = PackingID 
					from CellsContents with (nolock) 
					where FrameID = @nFrameID
				select @bWeighting_Partial = G.Weighting 
					from Packings P with (nolock) 
					inner join Goods G with (nolock) on P.GoodID = G.ID 
					where P.ID = @nPackingID_Partial
				
				-- есть такой товар в конечной ячейке? 
				set @nFinishCellContentID_Partial = Null
				select @nFinishCellContentID_Partial = ID 
						from	CellsContents 
						where	CellID = @nCellFinishID and 
								FrameID is Null and 
								IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1) and 
								GoodStateID = @nGoodStateID and 
								PackingID = @nPackingID_Partial 
				
				if @nFinishCellContentID_Partial is Null begin
					-- в конечной ячейке не было такого содержимого
					insert CellsContents 
						(CellID, FrameID, OwnerID, GoodStateID, 
						PackingID, Qnt, DateValid, DateLastOperation) 
						select	@nCellFinishID, Null, @nOwnerID, @nGoodStateID, 
								@nPackingID_Partial, @nQnt, Null, GetDate()
					set @nError = @@Error
					if @nError <> 0 goto Tr_Error
				end
				else begin
					-- в конечной ячейке уже есть такое содержимое
					update	CellsContents 
						set		Qnt = Qnt + @nQnt, 
								DateLastOperation = GetDate() 
						where	ID = @nFinishCellContentID_Partial
					set @nError = @@Error
					if @nError <> 0 goto Tr_Error
				end
				
				-- 2) убираем указанное количество товара из контейнера
				update CellsContents 
					set Qnt = Qnt - @nQnt 
					where ID = @nFrameCellContentID_Partial
				set @nError = @@Error
				if @nError <> 0 goto Tr_Error
				
				-- 3) если в контейнере ничего не осталось - разбираем его 
				--    если осталось - перекладываем его в Lost&Found и подбираем новое место 
				if (select Qnt from CellsContents where ID = @nFrameCellContentID_Partial) = 0 begin
					-- контейнер пуст: 
					
					-- удаляем старое содержимое контейнера
					delete CellsContents 
						where ID = @nFrameCellContentID_Partial
					set @nError = @@Error
					if @nError <> 0 goto Tr_Error
					-- и делаем сам контейнер неактуальным
					update	Frames set 
						OwnerID = Null, 
						GoodStateID = Null, 
						PalletTypeID = Null, 
						FrameHeight = 0.0, 
						Actual = 0, 
						State = 'D', 
						HasTraffic = 0, 
						DateLastOperation = GetDate() 
						where	ID = @nFrameID
					set @nError = @@Error
					if @nError <> 0 goto Tr_Error
				end
				else begin
					-- в контейнере остался товар:
					
					-- изменим высоту контейнера
					-- положим его пока в Lost&Found (надо иметь ввиду, что сейчас он должен находиться как будто бы в ячейке пикинга) 
					-- и подберем для него новое место 
					
					-- высота контейнера должна уменьшиться, поскольку с него убрали часть товара
					-- 
					-- Изменения от 17.03.2009
					-- Высота контейнера вводится руками и сохраняется с терминала
					/*
					declare @nFrameHeightOld decimal(12, 3), @nFrameHeightNew decimal(12, 3)
					select @nFrameHeightOld = F.FrameHeight, -- старая высота 
							@nFrameHeightNew = PT.PalletHeight -- высота поддона-деревяшки
						from Frames F with (nolock)
						left join PalletsTypes PT with (nolock) on F.PalletTypeID = PT.ID 
						where F.ID = @nFrameID
					select @nFrameHeightNew = @nFrameHeightNew + -- рядов * высоту коробки
								(select sum(ceiling(CC.Qnt / P.InBox / P.BoxInRow) * P.BoxHeight)
									from CellsContents CC with (nolock)
									inner join Packings P with (nolock) on CC.PackingID = P.ID
									where CC.FrameID = @nFrameID) 
					if IsNull(@nFrameHeightNew, @nFrameHeightOld) < @nFrameHeightOld begin
						update Frames
							set FrameHeight = @nFrameHeightNew
							where ID = @nFrameID
					end
					*/
					
					-- начинаем песню с перекладыванием контейнера в Lost&Found
					
					-- добавляем записи об изменении состояния ячеек
					declare @cNote_Partial varchar(2000), @nParentID_Partial int
					select	@cNote_Partial = 'подтверждение транспортировки (ID ' + ltrim(str(@nTrafficID)) + ': ' + 
									'контейнер ' + ltrim(str(@nFrameID)) + ' "перемещен" из ячейки пикинга ' + C.Address + ' (ID ' + ltrim(str(@nCellSourceID)) + ') ' +
									'в вирт.ячейку ' + @cLostFoundAddress + ' (ID ' + @cLostFoundCellID + ')' 
						from Cells C 
						where C.ID = @nCellFinishID
					insert CellsChanges 
							(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
							DateEdit, Note, UserID, DeviceID, ParentID) 
						select	@nCellFinishID, @nFrameID, 
								CC.OwnerID, CC.GoodStateID, CC.PackingID, -CC.Qnt, CC.DateValid, 
								GetDate(), @cNote_Partial, 
								Null as UserID, Null as DeviceID, 
								@nParentID_Partial 
							from CellsContents CC 
							where CC.FrameID = @nFrameID 
					select	@nParentID = @@Identity
					insert CellsChanges 
							(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
							DateEdit, Note, UserID, DeviceID, ParentID) 
						select	@nLostFoundCellID, @nFrameID, 
								CC.OwnerID, CC.GoodStateID, CC.PackingID, CC.Qnt, CC.DateValid, 
								GetDate(), @cNote_Partial, 
								Null as UserID, Null as DeviceID, 
								@nParentID 
							from CellsContents CC 
							where CC.FrameID = @nFrameID
					
					-- переписываем весь контейнер из текущей ячейки в ячейку Lost&Found
					update  CellsContents 
						set		CellID = @nLostFoundCellID, DateLastOperation = GetDate() 
						where	FrameID = @nFrameID
					
					-- очищаем статус контейнера
					update Frames 
						set	State = '', HasTraffic = 0, DateLastOperation = GetDate() 
						where ID = @nFrameID
					set @nError = @@Error
					if @nError <> 0 goto Tr_Error
					
					-- и подбираем для него новое место
					-- и создаем трафик 
					set @bNewFrameArrange = 1
					
					-- закончили работу с контейнером, в котором еще что-то остается
				end
				-- закончили работу с контейнером
			end
			-- @bForFrames = 0, конечная ячейка НЕ для контейнеров
		end
		else begin
			-- конечная ячейка для контейнеров
			
			-- номер контейнера в ячейке
			declare @nCCByOrder int
			select	@nCCByOrder = max(ByOrder) 
				from	CellsContents 
				where	CellID = @nCellFinishID
			if @nCCByOrder is Null set @nCCByOrder = 0
			
			-- содержимое из ячейки-источника -> в финишную ячейку
			update	CellsContents 
				set		CellID = @nCellFinishID 
				where	FrameID = @nFrameID
			set @nError = @@Error
			if @nError <> 0 goto Tr_Error
			
			-- статус контейнера - в зависимости от зоны
			update Frames 
				set	State = case when @bForStorage = 1 then 'S' 
								 when @bForInputs  = 1 then 'I' 
								 when @bForOutputs = 1 then 'O' 
								 else '' 
							end, 
					HasTraffic = 0, 
					DateLastOperation = GetDate() 
				where ID = @nFrameID
			set @nError = @@Error
			if @nError <> 0 goto Tr_Error
			
			-- заполняем ByOrder
			update	CellsContents 
				set ByOrder = @nCCByOrder + 1, 
					DateLastOperation = GetDate() 
				where CellID = @nCellFinishID and FrameID = @nFrameID
			set @nError = @@Error
			if @nError <> 0 goto Tr_Error
			
			-- В случае перемещения В РУЧЕЙ взводим при необходимости флаг заполненности ручья
			if exists (select C.ID 
						from Cells C 
						inner join StoresZones ST on C.StoreZoneID = ST.ID 
						inner join StoresZonesTypes STZ on STZ.ID = ST.StoreZoneTypeID 
						where C.ID = @nCellFinishID and STZ.ShortCode = 'RILL') begin
		        declare @nMaxPalQnt int
				select @nMaxPalQnt = IsNull(C.MaxPalletQnt, IsNull(SZ.MaxPalletQnt, 0)) 
					from Cells C with (nolock) 
					inner join StoresZones SZ with (nolock) on SZ.ID = C.StoreZoneID 
					where C.ID = @nCellFinishID
				if @nMaxPalQnt > 0 and @nMaxPalQnt <= dbo.GetFramesQntInCell(@nCellFinishID)
					update Cells set IsFull = 1 
						where ID = @nCellFinishID
				set @nError = @@Error
				if @nError <> 0 goto Tr_Error
			end
			
			-- В случае перемещения ИЗ РУЧЬЯ сбрасываем при необходимости флаг заполненности ручья
			if exists (select C.ID 
						from Cells C 
						inner join StoresZones ST on C.StoreZoneID = ST.ID 
						inner join StoresZonesTypes STZ on STZ.ID = ST.StoreZoneTypeID 
						where C.ID = @nCellSourceID and STZ.ShortCode = 'RILL') begin
				if dbo.GetFramesQntInCell(@nCellSourceID) = 0
					update Cells set IsFull = 0 
						where ID = @nCellSourceID
				set @nError = @@Error
				if @nError <> 0 goto Tr_Error
			end
		end
		
		-- все получилось.
		-- дата подтверждения в операции 
		update	TrafficsFrames 
			set		DateConfirm = GetDate(), Success = 1 
			where	ID = @nTrafficID
		set @nError = @@Error
		if @nError <> 0 goto Tr_Error
		
		declare @nTmpCellID int
		if @nOutputGoodID is not Null begin
			-- это перемещение было создано для расхода
			set @nTmpCellID = Null
			select @nTmpCellID = CellID from OutputsItems with (nolock) 
				where OutputGoodID = @nOutputGoodID and FrameID = @nFrameID
			if @nTmpCellID is null begin
				-- (att) 
				insert OutputsItems (OutputID, OutputGoodID, FrameID, CellID, 
							GoodStateID, PackingID, Qnt, DateValid, 
							UserID, DateConfirm) 
					select	@nOutputID, @nOutputGoodID, @nFrameID, T.CellTargetID, 
							CC.GoodStateID, CC.PackingID, CC.Qnt, CC.DateValid, 
							T.UserID, GetDate() 
						from	TrafficsFrames T 
						inner join #CellsContents_Cur CC on 1 = 1 
						where T.ID = @nTrafficID
				-- (att end)
				select @nError = @@Error
				if @nError > 0 goto Tr_Error
			end
			else begin
				if @nCellTargetID <> @nTmpCellID begin
					update OutputsItems set CellID = @nCellTargetID 
						 where OutputGoodID = @nOutputGoodID and FrameID = @nFrameID
					select @nError = @@Error
					if @nError > 0 goto Tr_Error
				end
			end	
			-- проверка всех связанных трафиков для заполнения Outputs.DateSelect
		end
		
		-- Если финишная ячейка отличается от конечной,
		-- то порождаем новую операцию и изменяем старую
		if @nCellTargetID <> @nCellFinishID begin
			insert TrafficsFrames (PreviousTrafficID, FrameID, CellSourceID, CellTargetID, 
					Priority, CreateNewIfError, InputID, OutputID, OutputGoodID, DateBirth, DateConfirm, Note) 
				select @nTrafficID, FrameID, @nCellFinishID, CellTargetID, 
					Priority, CreateNewIfError, InputID, OutputID, OutputGoodID, getdate(), Null, Note /*'Добавлено при подтверждении буфера'*/ 
			from TrafficsFrames	
			where ID = @nTrafficID
			set @nError = @@Error
			if @nError <> 0 goto Tr_Error
			
			update	TrafficsFrames 
				set		CellTargetID = @nCellFinishID 
				where	ID = @nTrafficID
			set @nError = @@Error
			if @nError <> 0 goto Tr_Error
			
			-- статус контейнера - перемещение
			update Frames 
				set	State = 'T', HasTraffic = 1, DateLastOperation = GetDate() 
				where ID = @nFrameID
			set @nError = @@Error
			if @nError <> 0 goto Tr_Error
		end
		
		if 	@bNewFrameArrange = 1 begin
			-- выполняем подбор ячейки и создаем трафик
			declare @nError_Arrange int, @cErrorText_Arrange varchar(200)
			select @nError_Arrange = 0, @cErrorText_Arrange = ''
			exec up_FramesArrange @nFrameID, Null, @nError_Arrange output, @cErrorText_Arrange output, 1, @nComplexID
			if @nError_Arrange <> 0 begin
				select @nError = @nError - 100, @cErrorStr = @cErrorText_Arrange
				-- но, даже если есть ошибка, операцию не прерываем! 
				-- контейнер останется в Lost&Found!
				
				-- запишем в примечание трафика 
				update TrafficsFrames
					set Note = ltrim(Note + ' ! перемещен товар (' + 
						(case when @bWeighting_Partial = 0 
							then ltrim(str(@nQnt)) + ' шт.' 
							else ltrim(str(@nQnt, 12, 3)) + ' кг' 
						end) + 
						'); подбор места для контейнера НЕ ВЫПОЛНЕН (' + @cErrorStr + ')')
					where ID = @nTrafficID
			end
			else begin
				select top 1 @nNewTrafficID = ID 
					from TrafficsFrames 
					where FrameID = @nFrameID and DateConfirm is Null 
					order by ID desc
				-- запишем в примечание трафика 
				update TrafficsFrames 
					set Note = ltrim(Note + ' ! перемещен товар (' + 
						(case when @bWeighting_Partial = 0 
							then ltrim(str(@nQnt)) + ' шт.' 
							else ltrim(str(@nQnt, 12, 3)) + ' кг' 
						end) + 
						') и выполнен подбор места для контейнера')
					where ID = @nTrafficID
			end
		end
	end
	
	if @nOutputID is not Null
		exec up_OutputsTrafficsCheck @nOutputID

commit transaction
return

Tr_Error:
rollback transaction
return