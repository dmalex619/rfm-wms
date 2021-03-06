SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[up_TrafficsGoodsConfirm]
	@nTrafficID			int,					-- код прихода
	@bSuccess			bit,					-- завершено успешно?
	@nQntConfirmed		decimal(18, 3),			-- фактическое количество		
	@bMinusAllowed		bit = Null,	-- не исп.	-- разрешено выполнять при получении "-" остатков или при отсутствии остатков
	@nTrafficErrorID	int = Null,				-- код ошибки завершения (для НЕуспешного завершения)
	@nError				int = 0 output,			-- ошибка при подтверждении
	@cErrorStr			varchar(200) = '' output
AS

-- подтверждение выполнения одной операции перемещения "неконтейнерного хвоста" (коробки/штуки) 
-- независимо от предназначения  перемещения
-- Все что касается перемещений для расхода обрабатывается в процедуре up_OutputsTrafficsConfirm

set nocount on

if @bSuccess = 1 and @nTrafficErrorID is not Null begin
	select	@nError = -10, 
			@cErrorStr = 'Задан код ошибки при успешном завершении операции перемещения коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + '...'
	raiserror(@cErrorStr, 16, 1)
	return
end

-- операция: существует? еще не подтверждена?
declare @dDateConfirm smalldatetime, 
		@nCellSourceID int, @nCellTargetID int, 
		@cCellSourceAddress varchar(20), @cCellTargetAddress varchar(20), 
		@bCellSourceForPicking bit, 
		@nOwnerID int, @nGoodStateID int, 
		@nPackingID int, 
		@nFromFrameID int, 
		@nPriority int, @nByOrder int, @cERPCode varchar(max)

select	@dDateConfirm = DateConfirm, 
		@nCellSourceID = CellSourceID, 
		@nCellTargetID = CellTargetID,
		@nOwnerID = OwnerID, 
		@nGoodStateID = GoodStateID, 
		@nPackingID = PackingID, 
		@nFromFrameID = FromFrameID, 
		@nPriority = Priority, 
		@nByOrder = ByOrder, 
		@cERPCode = ERPCode 
	from	TrafficsGoods with (nolock) 
	where	ID = @nTrafficID
if @@RowCount = 0 begin
	select	@nError = -1, 
			@cErrorStr = 'Не найдена операция перемещения коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + '...'
	raiserror(@cErrorStr, 16, 1)
	return
end
if @dDateConfirm is not null begin
	select	@nError = -2, 
			@cErrorStr = 'Операция перемещения коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + ' уже подтверждена...'
	raiserror(@cErrorStr, 16, 1)
	return
end

-- для перемещений из Lost&Found
declare @nLostFoundCellID int, @cLostFoundAddress varchar(20)
select	@cLostFoundAddress = .dbo._SettingsGetValue('sLostFoundAddress'), 
		@nLostFoundCellID = Null
if IsNull(@cLostFoundAddress, '') <> '' begin
	select	@nLostFoundCellID = ID
		from	Cells
		where	Address = @cLostFoundAddress
end
if @nLostFoundCellID is Null 
	set @nLostFoundCellID = 0

-- проверки ячеек для УДАЧНОГО подтверждения 
if @bSuccess = 1 begin 
	declare @bForFrames bit, @bLocked bit, @bActual bit, @bDeleted bit
	-- начальная ячейка: существует? актуальна? не блокирована? не удалена? предназначена для коробок/штук?
	select	@cCellSourceAddress = C.Address, 
			@bForFrames  = SZT.ForFrames, 
			@bLocked = C.Locked, @bActual = C.Actual, @bDeleted = C.Deleted,  
			@bCellSourceForPicking = SZT.ForPicking 
		from Cells C with (nolock) 
		inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID
		inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID
		where C.ID = @nCellSourceID
	if @@RowCount = 0 begin 
		select	@nError = -11, 
				@cErrorStr = 'Начальная ячейка ' + @cCellSourceAddress + ' для операции перемещения коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + ' не найдена...'
		raiserror(@cErrorStr, 16, 1)
		return 
	end
	if @bDeleted = 1 begin
		select	@nError = -14, 
				@cErrorStr = 'Начальная ячейка ' + @cCellSourceAddress + ' для операции перемещения коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + ' удалена...'
		raiserror(@cErrorStr, 16, 1)
		return 
	end
	if @nCellSourceID != @nLostFoundCellID begin
		if @bActual = 0 begin
			select	@nError = -12, 
					@cErrorStr = 'Начальная ячейка ' + @cCellSourceAddress + ' для операции перемещения коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + ' не актуальна...'
			raiserror(@cErrorStr, 16, 1)
			return 
		end
		if @bLocked = 1 begin
			select	@nError = -13, 
					@cErrorStr = 'Начальная ячейка ' + @cCellSourceAddress + ' для операции перемещения коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + ' блокирована...'
			raiserror(@cErrorStr, 16, 1)
			return 
		end
	end
	if @nFromFrameID is Null begin 
		if @bForFrames is not Null and @bForFrames = 1 begin
			-- ячейка - для контейнеров 
			select	@nError = -15, 
					@cErrorStr = 'Начальная ячейка ' + @cCellSourceAddress + ' для операции перемещения коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + ' предназначена только для контейнеров...'
			raiserror(@cErrorStr, 16, 1)
			return 
		end 
	end	
	else begin
		-- контейнер
		select ID 
			from CellsContents with (nolock)
			where CellID = @nCellSourceID and 
				FrameID = @nFromFrameID and 
				PackingID = @nPackingID 
		if @@RowCount = 0 begin
			select	@nError = -16, 
					@cErrorStr = 'Начальная ячейка ' + @cCellSourceAddress + ' не содержит контейнер с кодом ' + ltrim(str(@nFromFrameID)) + '...'
			raiserror(@cErrorStr, 16, 1)
			return 
		end 

		select ID 
			from Frames with (nolock)
			where ID = @nFromFrameID and 
				Actual = 1 and Locked = 0
		if @@RowCount = 0 begin
			select	@nError = -17, 
					@cErrorStr = 'Контейнер с кодом ' + ltrim(str(@nFromFrameID)) + ' не существует...'
			raiserror(@cErrorStr, 16, 1)
			return 
		end 
	end 
		
	-- конечная ячейка: существует? актуальна? не блокирована? не удалена? предназначена для коробок/штук?
	select	@cCellTargetAddress = C.Address, 
			@bForFrames  = SZT.ForFrames, 
			@bLocked = C.Locked, @bActual = C.Actual, @bDeleted = C.Deleted 
		from Cells C with (nolock) 
		inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID
		inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID
		where C.ID = @nCellTargetID
	if @@RowCount = 0 begin 
		select	@nError = -21, 
				@cErrorStr = 'Конечная ячейка ' + @cCellTargetAddress + ' для операции перемещения коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + ' не найдена...'
		raiserror(@cErrorStr, 16, 1)
		return 
	end
	if @bDeleted = 1 begin
		select	@nError = -24, 
				@cErrorStr = 'Конечная ячейка ' + @cCellTargetAddress + ' для операции перемещения коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + ' удалена...'
		raiserror(@cErrorStr, 16, 1)
		return 
	end
	if @bActual = 0 begin
		select	@nError = -22, 
				@cErrorStr = 'Конечная ячейка ' + @cCellTargetAddress + ' для операции перемещения коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + ' не актуальна...'
		raiserror(@cErrorStr, 16, 1)
		return 
	end
	if @bLocked = 1 begin
		select	@nError = -23, 
				@cErrorStr = 'Конечная ячейка ' + @cCellTargetAddress + ' для операции перемещения коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + ' блокирована...'
		raiserror(@cErrorStr, 16, 1)
		return 
	end
	if @bForFrames is not Null and @bForFrames = 1 begin
		-- ячейка - для контейнеров 
		select	@nError = -25, 
				@cErrorStr = 'Конечная ячейка ' + @cCellTargetAddress + ' для операции перемещения коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + ' предназначена только для контейнеров...'
		raiserror(@cErrorStr, 16, 1)
		return 
	end 
	
	if IsNull(@bMinusAllowed, 0) = 0 and @nCellSourceID != @nLostFoundCellID begin
		-- начальная ячейка: хватит товара? (иначе просто нечего будет переложить в CellsContents в другую ячейку)
		declare @nQntExist dec(15,3)
		select	@nQntExist = sum(Qnt) 
			from	CellsContents with (nolock) 
			where	CellID = @nCellSourceID and 
					isNull(@nFromFrameID, -1) = isNull(FrameID, -1) and -- FrameID is Null 
					PackingID = @nPackingID and 
					GoodStateID = @nGoodStateID and
					IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1)
		if IsNull(@nQntExist, 0) < @nQntConfirmed begin
			-- не хватит 
			declare @cGoodAlias varchar(1000)
			select	@cGoodAlias = G.Alias
				from Packings P 
				inner join Goods G on P.GoodID = G.ID
				where P.ID = @nPackingID
			select	@nError = -26, 
					@cErrorStr = 'Начальная ячейка ' + @cCellSourceAddress + ' для операции перемещения коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + ' не содержит необходимого количества товара "' + IsNull(@cGoodAlias, '') + '"...'
			raiserror(@cErrorStr, 16, 1)
			return 
		end 
	end
	
	-- закрепление конечной ячейки?
	declare @nFixedOwnerID int, @nFixedGoodStateID int, @nFixedPackingID int
	select  @nFixedOwnerID = FixedOwnerID, 
			@nFixedGoodStateID = FixedGoodStateID, 
			@nFixedPackingID = FixedPackingID 
		from	Cells with (nolock) 
		where	ID = @nCellTargetID 
	if	@nFixedOwnerID is not Null		and IsNull(@nFixedOwnerID, -1) <> IsNull(@nOwnerID, -1) or 
		@nFixedGoodStateID is not Null	and IsNull(@nFixedGoodStateID, -1) <> IsNull(@nGoodStateID, -1) or 
		@nFixedPackingID is not Null	and IsNull(@nFixedPackingID, -1) <> IsNull(@nPackingID, -1) begin
		select	@nError = -27, 
				@cErrorStr = 'Конечная ячейка ' + @cCellTargetAddress + ' для операции перемещения коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + ' закреплена за другим владельцем/состоянием/товаром...'
		raiserror(@cErrorStr, 16, 1)
		return 
	end
	
	-- текущее содержимое конечной ячейки 
	/*
	select	ID 
		from	CellsContents 
		where	IsNull(OwnerID, -1) <> IsNull(@nOwnerID, -1) or 
				IsNull(@nGoodStateID, -1) <> IsNull(@nGoodStateID, -1) or 
				IsNull(@nPackingID, -1) <> IsNull(@nPackingID, -1)
	if @@RowCount > 0 begin 
		select	@nError = -26, 
				@cErrorStr = 'Конечная ячейка для операции перемещения коробок/штук с кодом ' + ltrim(str(@nTrafficID)) + ' уже содержит товар другого владельца/состояния/наименования...'
		raiserror(@cErrorStr, 16, 1)
		return 
	end 
	
	-- проверить ли такое:
	-- в конечной ячейке уже лежит другой товар (того же владельца и состояния)? Cells.GoodsMono
	-- ?
	*/
end -- все проверки выполнены 

declare @nQntConfirmedBeg decimal(18, 3)
select	@nQntConfirmedBeg = @nQntConfirmed 

begin transaction
	if @bSuccess = 0 begin 
		-- НЕудачное завершение. Ничего никуда не перемещается
		-- дата подтверждения в операции и "-"статус в операции
		update	TrafficsGoods 
			set		DateConfirm = GetDate(), 
					Success = 0, 
					ErrorID = @nTrafficErrorID
			where	ID = @nTrafficID
		set @nError = @@Error
		if @nError <> 0 goto Tr_Error
	end
	else begin 
		-- @bSuccess = 1 
		
		-- перекладываем подтвержденное в конечную ячейку
		declare @nSourceCellContentID int, 
				@nTargetCellContentID int, 
				@dDateValid smalldatetime, 
				@nCellContentQnt decimal(18, 3), 
				@nUsedQnt decimal(18, 3)
		
		-- перекладываем из одной ячейки в другую
		while @nQntConfirmed > 0 begin 
			select	@nSourceCellContentID = Null, 
					@nCellContentQnt = 0, 
					@nUsedQnt = 0
		
			if 	@nCellSourceID = @nLostFoundCellID begin

				-- из Lost&Found перекладываем все кучей
				declare @nCellContentLFID int 
				set @nCellContentLFID = Null
				select	top 1 @nCellContentLFID = ID
					from	CellsContents
					where	CellID = @nCellSourceID and 
							isNull(@nFromFrameID, -1) = isNull(FrameID, -1) and -- FrameID is Null 
							PackingID = @nPackingID and 
							GoodStateID = @nGoodStateID and
							IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1)
				if @nCellContentLFID is Null begin 
					-- в ячейке Lost&Found не было такого содержимого
					insert CellsContents 
						(CellID, FrameID, OwnerID, GoodStateID, 
						PackingID, Qnt, DateValid, DateLastOperation)
						select	@nCellSourceID, Null, @nOwnerID, @nGoodStateID, 
								@nPackingID, -@nQntConfirmed, Null, GetDate()
					set @nError = @@Error 
					if @nError <> 0 goto Tr_Error
				end 
				else begin 
					-- в ячейке Lost&Found уже есть такое содержимое 
					update	CellsContents 
						set		Qnt = Qnt - @nQntConfirmed
						where	ID = @nCellContentLFID
					set @nError = @@Error
					if @nError <> 0 goto Tr_Error
				end 
				select  @nUsedQnt = @nQntConfirmed, 
						@nQntConfirmed = 0
			end 
			else begin 
				-- из обычной ячейки перекладываем, пока не кончится количество

				select	top 1 @nSourceCellContentID = ID, 
						@nCellContentQnt = Qnt, 
						@dDateValid = DateValid 
					from	CellsContents
					where	CellID = @nCellSourceID and 
							isNull(@nFromFrameID, -1) = isNull(FrameID, -1) and --FrameID is Null
							PackingID = @nPackingID and 
							GoodStateID = @nGoodStateID and
							IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1) and
							Qnt > 0
					order by DateValid -- ??IsNull(DateValid, '19900101') -- если в ячейке лежит товар и со сроком годности, и без - какой сначала выдавать?
				
				-- забираем товар из начальной ячейки
				if @nCellContentQnt >= @nQntConfirmed begin 
					-- хватит товара 
					select	@nUsedQnt = @nQntConfirmed, 
							@nQntConfirmed = 0 
				end 
				else begin
					-- не хватит
					select	@nUsedQnt = @nCellContentQnt, 
							@nQntConfirmed = @nQntConfirmed - @nCellContentQnt
				end
				
				update CellsContents 
					set		Qnt = Qnt - @nUsedQnt,
							DateLastOperation = GetDate()
					where	ID = @nSourceCellContentID 
				set @nError = @@Error	
				if @nError <> 0 goto Tr_Error
			end

			-- кладем товар в конечную ячейку 
			select	top 1 @nTargetCellContentID = ID
				from	CellsContents
				where	CellID = @nCellTargetID and 
						FrameID is Null and 
						IsNull(OwnerID, -1) = IsNull(@nOwnerID, -1) and 
						GoodStateID = @nGoodStateID and 
						PackingID = @nPackingID and 
						datediff(day, IsNull(DateValid, '19000101'), IsNull(@dDateValid, '19000101')) = 0 
			if @nTargetCellContentID is Null begin 
				-- в конечной ячейке не было такого содержимого
				insert CellsContents 
					(CellID, FrameID, OwnerID, GoodStateID, 
					PackingID, Qnt, DateValid, DateLastOperation)
					select	@nCellTargetID, Null, @nOwnerID, @nGoodStateID, 
							@nPackingID, @nUsedQnt, @dDateValid, GetDate()
				set @nError = @@Error	
				if @nError <> 0 goto Tr_Error
			end 
			else begin 
				-- в конечной ячейке уже есть такое содержимое 
				update	CellsContents 
					set		Qnt = Qnt + @nUsedQnt
					where	ID = @nTargetCellContentID
				set @nError = @@Error
				if @nError <> 0 goto Tr_Error
			end
		end
		
		-- в начальной ячейке - очистить строки содержимого с Qnt = 0
		if @bCellSourceForPicking = 0 or @nCellSourceID = @nLostFoundCellID begin
			delete 	CellsContents 
				where	CellID = @nCellSourceID and Qnt = 0 
		end 
		
		-- все получилось.
		-- дата подтверждения в операции 
		update	TrafficsGoods 
			set		DateConfirm = GetDate(), 
					Success = 1, 
					QntConfirmed = @nQntConfirmedBeg
			where	ID = @nTrafficID
		set @nError = @@Error
		if @nError <> 0 goto Tr_Error
		
		-- и в контейнере
		if @nFromFrameID is not Null begin 
			update Frames 
				set HasTraffic = 0, State = 'S', DateLastOperation = GetDate()
				where ID = isnull(@nFromFrameID, 0) 
		end
	end

if @@TranCount > 0 commit transaction 
return

Tr_Error:
if @@TranCount > 0 rollback transaction 
return