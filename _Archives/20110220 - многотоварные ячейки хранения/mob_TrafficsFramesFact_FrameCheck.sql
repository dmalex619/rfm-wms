SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mob_TrafficsFramesFact_FrameCheck]
	@nFrameID		int, 
	@nCellTargetID	int = Null
AS
-- Процедура проверки возможности ручного пемещения контейнера
-- Возвращает строку с описанием причины невозможности перемещения,
-- или пустую строку в случае успеха
-- Процедура разделена на две части:
--		при первом вызове @nCellTargetID не передается,
--		поэтому проверяем только контейнер
--		при втором вызове @nCellTargetID not Null, 
--		поэтому проверяем только целевую ячейку
--		(считаем, что контейнер уже проверен)

set nocount on

-- Переменная для возврата значения
declare @cError varchar(max)
set @cError = ''

-- Данные о контейнере
declare @nID int, @bFrameActual bit
select @nID = ID, @bFrameActual = Actual 
	from Frames with (nolock) 
	where ID = IsNull(@nFrameID, 0)

-- Данные о текущем местоположении контейнера
declare @nCellSourceID int
select top 1 @nCellSourceID = CellID 
	from CellsContents with (nolock) 
	where FrameID = IsNull(@nFrameID, 0) and Qnt <> 0

if @nCellTargetID is Null begin
	-- Первый вызов - проверка контейнера
	
	-- Проверка наличия контейнера
	if len(@cError) = 0 and @nID is Null begin
		set @cError = 'Неизвестный контейнер!'
		goto Tr_Error
	end
	
	-- Проверка состояния контейнера
	if len(@cError) = 0 and @bFrameActual = 0 begin
		set @cError = 'Контейнер уже удален!'
		goto Tr_Error
	end
	
	-- Проверка незавершенных трафиков для контейнера
	if len(@cError) = 0 and 
		exists (select ID 
				from TrafficsFrames with (nolock) 
				where FrameID = IsNull(@nFrameID, 0) and 
					DateConfirm is Null) begin
		set @cError = 'Контейнер участвует в незавершенных перемещениях!'
		goto Tr_Error
	end
	
	-- Проверка того, что контейнер не пуст
	if len(@cError) = 0 and 
		(@nCellSourceID is Null) begin
		set @cError = 'Контейнер пуст!'
		goto Tr_Error
	end
end
else begin
	-- Второй вызов - проверка целевой ячейки
	
	-- Получение данных о целевой ячейке
	declare @bForFrame bit, @bForStorage bit, @bLocked bit, @bDeleted bit, 
			@bCellTargetActual bit, @nMaxPalletQnt decimal(12, 3), @bGoodsMono bit
	select	@bForFrame  = SZT.ForFrames, 
			@bForStorage = SZT.ForStorage, 
			@bLocked  = C.Locked, 
			@bDeleted = C.Deleted, 
			@bCellTargetActual = C.Actual, 
			@nMaxPalletQnt = IsNull(IsNull(C.MaxPalletQnt, SZ.MaxPalletQnt), 999999), 
			@bGoodsMono = C.GoodsMono 
		from Cells C with (nolock) 
		inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
		inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
		where C.ID = @nCellTargetID
	
	-- Простые проверки
	if len(@cError) = 0 and @bCellTargetActual = 0 begin
		set @cError = 'Целевая ячейка не актуальна!'
		goto Tr_Error
	end
	if len(@cError) = 0 and @bLocked = 1 begin
		set @cError = 'Целевая ячейка заблокирована!'
		goto Tr_Error
	end
	if len(@cError) = 0 and @bDeleted = 1 begin
		set @cError = 'Целевая ячейка удалена!'
		goto Tr_Error
	end
	/*if len(@cError) = 0 and @bForFrame = 0 begin
		set @cError = 'Целевая ячейка не предназначена для контейнеров!'
	end*/
	
	-- Проверки на соблюдение монотоварности
	-- Только для строго контейнерных ячеек
	if len(@cError) = 0 and @bForFrame = 1 and @bForStorage = 1 begin
		-- Получение сочетания признаков через исходную ячейку
		declare @nOwnerID int, @nGoodStateID int, @nPackingID int
		select	top 1 
				@nOwnerID = OwnerID, 
				@nGoodStateID = GoodStateID, 
				@nPackingID = PackingID 
			from CellsContents with (nolock) 
			where CellID = @nCellSourceID
		
		-- Проверка наличия других сочетаний признаков в целевой ячейке
		-- Только для моноячеек
		if @bGoodsMono = 1 and exists (select distinct ID 
					from CellsContents with (nolock) 
					where CellID = @nCellTargetID and (
						IsNull(@nOwnerID, 0) <> IsNull(OwnerID, 0) or 
						@nGoodStateID <> GoodStateID or 
						@nPackingID <> PackingID)) begin
			set @cError = 'Целевая ячейка не может принять данный контейнер (другой товар или владелец или состояние)!'
			goto Tr_Error
		end
		
		-- Если ячейку подбирали автоматом, то уже существует трафик
		-- Его не надо учитывать в общем кол-ве паллет в ячейке,
		-- которое получается из UDF dbo.GetFramesQntInCell() & dbo.GetFramesQntToCell()
		declare @nThisFrameCellTrafficsCount int
		if exists (select ID from TrafficsFrames 
					where	FrameID = IsNull(@nFrameID, 0) and 
							CellTargetID = @nCellTargetID and 
							DateConfirm is Null)
			set @nThisFrameCellTrafficsCount = 1
		else
			set @nThisFrameCellTrafficsCount = 0
		
		-- поместится ли еще один контейнер?
		if	.dbo.GetFramesQntInCell(@nCellTargetID) + 
			.dbo.GetFramesQntToCell(@nCellTargetID) + 
			1 - @nThisFrameCellTrafficsCount > @nMaxPalletQnt begin
			set @cError = 'Целевая ячейка не может принять данный контейнер (ограничение вместимости ячейки по количеству паллет)!'
			goto Tr_Error
		end
	end
end

-- Дополнение ошибки
Tr_Error:
if len(@cError) > 0 
	set @cError = 'Перемещение невозможно!' + char(13) + char(10) + @cError

-- Проблем не обнаружено
select @cError as ErrorText
return