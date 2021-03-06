SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mob_InputSaveItem]
	@nInputID		int, 
	@nGoodStateID	int, 
	@nPackingID		int, 
	@nQnt			decimal(12,3), 
	@dDateValid		smalldatetime, 
	
	@nCellID		int, 
	@nFrameID		int, 
	@nFrameHeight	decimal(10,3), 
	@nPalletTypeID	int, 
	
	@nOwnerID		int, 
	@nUserID		int, 
	@nDeviceID		int,
	@nCellArrange	int = null output,
	@nError			int = 0 output
AS
-- Сохранение одного элемента прихода
-- Изменяются таблицы InputsItems, CellsContents, Frames

set nocount on

-- Проверки прихода
if @nInputID is Null begin
	raiserror(N'Не задан код прихода!', 16, 1)
	return
end
if not exists (select ID from Inputs where ID = IsNull(@nInputID, 0)) begin
	raiserror(N'Неправильный код прихода!', 16, 1)
	return
end
if not exists (select ID from Inputs where ID = IsNull(@nInputID, 0) and DateConfirm is Null) begin
	raiserror(N'Приход уже подтвержден!', 16, 1)
	return
end

-- Проверки контейнера
if @nFrameID is not Null and 
	not exists (select ID from Frames where ID = IsNull(@nFrameID, 0) and Actual = 1 and 
					LTrim(IsNull(State, '')) = '') begin
	raiserror(N'Неизвестный контейнер!', 16, 1)
	return
end

-- Владелец-пофигист?
declare @bSeparatePicking bit
set @bSeparatePicking = 0
select	@bSeparatePicking = SeparatePicking
	from	Partners with (nolock) 
	where	ID = @nOwnerID

-- Владелец для CellsContents
declare @nCellsContentsOwnerID int
set @nCellsContentsOwnerID = case when @bSeparatePicking = 1 
	then @nOwnerID else Null end

-- Получить дату-время операции
declare @dNow smalldatetime
select @dNow = GetDate()

declare @nInputItemID int

-- Начинаем запись данных
begin tran Tr_InputSaveItem
	/*
	-- НЕПРАВИЛЬНЫЙ КОД!!!
	insert into InputsItems (InputID, CellID, GoodStateID, 
		PackingID, Qnt, DateValid, FrameID, 
		UserID, DeviceID, DateConfirm) 
		values (@nInputID, @nCellID, @nGoodStateID, 
			@nPackingID, @nQnt, @dDateValid, @nFrameID, 
			@nUserID, @nDeviceID, @dNow)
	if @@Error <> 0 goto tr_Error
	*/
	
	-- Изменение от 10.07.2009 Александров
	-- В случае, если товар принимается без контейнеров,
	-- процедура создавала несколько строк в InputsItems.
	-- Это приводило к увеличению количества принятого товара в случае
	-- последующего редактирования прихода на десктопе!!!
	-- Данные из всех строк складывались и умножались на количество строк!!!
	-- Теперь запись создается всегда при приемке контейнерами,
	-- и только в случае отсутствия аналогичного товара при приемке без контейнера.
	
	-- Поддон существует?
	if @nFrameID is not Null begin
		-- Сам элемент прихода
		-- Изменение от 10.07.2009 Александров
		-- При приемке контейнерами новую запись создаем всегда
		insert into InputsItems (InputID, CellID, GoodStateID, 
			PackingID, Qnt, DateValid, FrameID, 
			UserID, DeviceID, DateConfirm) 
			values (@nInputID, @nCellID, @nGoodStateID, 
				@nPackingID, @nQnt, @dDateValid, @nFrameID, 
				@nUserID, @nDeviceID, @dNow)
		if @@Error <> 0 goto tr_Error
		-- Изменение от 10.07.2009 Александров END
		
		-- Добавляем строку в содержимое ячеек
		insert into CellsContents (CellID, FrameID, OwnerID, 
			GoodStateID, PackingID, DateValid, Qnt, DateLastOperation) 
			values (@nCellID, @nFrameID, @nCellsContentsOwnerID, 
				@nGoodStateID, @nPackingID, @dDateValid, @nQnt, @dNow)
		if @@Error <> 0 goto tr_Error
		
		-- Заполняем данные о контейнере
		-- Учитываем пофигистичность владельца
		update Frames set 
			OwnerID				= @nCellsContentsOwnerID, 
			GoodStateID			= @nGoodStateID, 
			DateLastOperation	= @dNow, 
			PalletTypeID		= @nPalletTypeID, 
			FrameHeight			= @nFrameHeight, 
			State				= 'I' 
			where ID = IsNull(@nFrameID, 0)
		if @@Error <> 0 goto tr_Error
	end
	else begin
		-- Сам элемент прихода
		-- Изменение от 10.07.2009 Александров
		-- Поиск аналогичной строки в InputsItems
		set @nInputItemID = Null
		select top 1 @nInputItemID = ID 
			from InputsItems 
			where	InputID		= @nInputID and 
					GoodStateID	= @nGoodStateID and 
					PackingID	= @nPackingID and 
					FrameID is Null
		if @nInputItemID is not Null begin
			-- Нашли строку в приходе - просто добавляем количество
			update InputsItems set Qnt = Qnt + @nQnt 
				where ID = @nInputItemID
			if @@Error <> 0 goto tr_Error
		end
		else begin
			-- Создаем новую строку
			insert into InputsItems (InputID, CellID, GoodStateID, 
				PackingID, Qnt, DateValid, FrameID, 
				UserID, DeviceID, DateConfirm) 
				values (@nInputID, @nCellID, @nGoodStateID, 
					@nPackingID, @nQnt, @dDateValid, @nFrameID, 
					@nUserID, @nDeviceID, @dNow)
			if @@Error <> 0 goto tr_Error
		end
		-- Изменение от 10.07.2009 Александров END
		
		-- Ищем такой же товар в той же ячейке, лежащий без контейнера
		-- Исправление от 14.02.2008
		-- Срок годности товаров без контейнеров не учитываем!
		declare @nCellsContentsID int
		select top 1 @nCellsContentsID = ID 
			from CellsContents 
			where	CellID = @nCellID and 
					FrameID is Null and 
					IsNull(OwnerID, -1) = IsNull(@nCellsContentsOwnerID, -1) and 
					GoodStateID = @nGoodStateID and 
					PackingID = @nPackingID 
					-- and DateDiff(Day, IsNull(DateValid, '19000101'), IsNull(@dDateValid, '19000101')) = 0
		if @@Error <> 0 goto tr_Error
		
		-- В зависимости от успешности поиска добавляем или обновляем строку
		if @nCellsContentsID is not Null begin
			-- Изменение количества
			update CellsContents 
				set Qnt = Qnt + @nQnt, DateLastOperation = @dNow 
				where ID = @nCellsContentsID
			if @@Error <> 0 goto tr_Error
		end
		else begin
			-- Добавление новой строки
			-- Исправление от 14.02.2008
			-- Срок годности товаров без контейнеров не учитываем!
			insert into CellsContents (CellID, FrameID, OwnerID, 
				GoodStateID, PackingID, DateValid, Qnt, DateLastOperation)
				values (@nCellID, Null, @nCellsContentsOwnerID, 
					@nGoodStateID, @nPackingID, Null, @nQnt, @dNow) 
			if @@Error <> 0 goto tr_Error
		end
	end
	
commit tran Tr_InputSaveItem

-- Создаем траффик
if @nFrameID is not Null begin
	declare @cErrorText varchar(max)
	set @cErrorText = ''
	execute up_FramesArrange @nFrameID, @nCellArrange output, @nError output, @cErrorText output
end
return

tr_Error:
rollback tran Tr_InputSaveItem
return