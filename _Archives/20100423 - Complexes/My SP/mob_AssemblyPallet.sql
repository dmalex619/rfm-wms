SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mob_AssemblyPallet]
	@nCellIDSource	int, 
	@nCellIDTarget	int, 
	@nPackingID		int, 
	@nGoodStateID	int, 
	@dDateValid		smalldatetime, 
	@nQnt			decimal(18,3), 
	@nFrameID		int, 
	@nPalletTypeID	int, 
	@nFrameHeight	decimal(10,3), 
	@nUserID		int, 
	@nDeviceID		int
-- Сохранение данные о сборке контейнера из отдельных коробок (мешков)
-- с автоматической генерацией трафика для собранной паллеты
AS

-- Проверки параметров (на всякий случай)
if @nCellIDSource is Null or 
	not exists (select ID from Cells where ID = @nCellIDSource) begin
	raiserror(N'Отсутствует исходная ячейка!', 16, 1)
	return
end
if @nCellIDTarget is Null or 
	not exists (select ID from Cells where ID = @nCellIDTarget) begin
	raiserror(N'Отсутствует целевая ячейка!', 16, 1)
	return
end
if @nFrameID is Null or 
	not exists (select ID from Frames 
				where ID = @nFrameID and Actual = 1 and 
					LTrim(IsNull(State, '')) = '') begin
	raiserror(N'Неизвестный или непригодный контейнер!', 16, 1)
	return
end

-- Изменение от 24.04.2010
-- Проверка принадлежности исходной и целевой ячеек к одному комплексу
select distinct SZ.ComplexID 
	into #Complexes 
	from Cells C with (nolock) 
	inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	where C.ID in (@nCellIDSource, @nCellIDTarget)
if @@RowCount > 1 begin
	raiserror(N'Исходная и целевая ячейки принадлежат к разным комплексам!', 16, 1)
	return
end

-- Изменение от 11.03.2008
-- Перцы на ШОКе засунули паллет в ручей и смешали товары
declare @cSZTShortCode varchar(10), @bForStorage bit
select @cSZTShortCode = SZT.ShortCode, @bForStorage = SZT.ForStorage 
	from Cells C with (nolock) 
	inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
	inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
	where C.ID = @nCellIDTarget
if @cSZTShortCode = 'RILL' begin
	raiserror(N'Целевая ячейка не может быть ручьем!', 16, 1)
	return
end

-- Переменная для расчета уже обработанного остатка
declare @nQntRest decimal(18,3)
set @nQntRest = @nQnt

declare @nCellIDCur int, @dDateValidCur smalldatetime, @nQntCur decimal(18,3), @dNow smalldatetime

set @dNow = GetDate()

begin tran Tr_AssemblyPallet
	while @nQntRest > 0 begin
		-- Получаем CellsContents.ID с минимальной датой
		-- По идее для бесконтейнерной ячейки 
		-- должна быть только одна запись с DateValid is Null
		set @nCellIDCur = Null
		select top 1 @nCellIDCur = ID, @nQntCur = Qnt 
			from CellsContents 
			where CellID = @nCellIDSource and 
				PackingID = @nPackingID and 
				GoodStateID = @nGoodStateID and 
				FrameID is Null and Qnt > 0 
			order by IsNull(DateValid, '20000101')
		if @@Error <> 0 goto Tr_Error
		
		-- Если такой ячейки нет (Qnt > 0) - выходим с ошибкой
		-- Может возникнуть, например, при подтверждении расхода,
		-- когда за время сбора поддона товар списали из OUT
		-- С отрицательными остатками, а также с LOST&FOUND не работаем
		if @nCellIDCur is Null goto Tr_Error
		
		-- Списываем очередную порцию
		if @nQntCur > @nQntRest begin
			-- Уменьшаем количество
			update CellsContents 
				set Qnt = Qnt - @nQntRest, DateLastOperation = @dNow 
				where ID = @nCellIDCur
			if @@Error <> 0 goto Tr_Error
			set @nQntRest = 0
		end
		else begin
			-- Кол-во стало 0 - удаляем строку
			delete CellsContents 
				where ID = @nCellIDCur
			if @@Error <> 0 goto Tr_Error
			set @nQntRest = @nQntRest - @nQntCur
		end
	end
	
	-- Списали все количество из бесконтейнерной ячейки
	-- Теперь добавляем данные о приходе
	insert into CellsContents (CellID, FrameID, OwnerID, 
		GoodStateID, PackingID, DateValid, Qnt, 
		ByOrder, DateLastOperation) 
		values (@nCellIDTarget, @nFrameID, Null, 
			@nGoodStateID, @nPackingID, @dDateValid, @nQnt, 
			.dbo.GetFrameByOrderInCell(@nFrameID, @nCellIDTarget),  @dNow)
	if @@Error <> 0 goto Tr_Error
	
	-- Обновляем данные о контейнере
	update Frames set 
		OwnerID				= Null, 
		GoodStateID			= @nGoodStateID, 
		DateLastOperation	= @dNow, 
		PalletTypeID		= @nPalletTypeID, 
		FrameHeight			= @nFrameHeight, 
		State				= case when @bForStorage = 1 then 'S' else 'I' end, 
		HasTraffic			= case when @bForStorage = 1 then 0 else 1 end 
		where ID = @nFrameID
	if @@Error <> 0 goto Tr_Error

commit tran Tr_AssemblyPallet

-- Добавляем запись в CellsChanges
declare @cNote1 varchar(2000), @cNote2 varchar(2000), @nParentID int
select	@cNote1 = 'Сборка контейнера вручную: товар "удален" из ячейки ' + C.Address + ' (ID ' + ltrim(str(@nCellIDSource)) + '), ' +
			'контейнер ' + ltrim(str(@nFrameID))   
	from Cells C with (nolock) 
	where C.ID = @nCellIDSource
select	@cNote2 = 'Сборка контейнера вручную: товар "перемещен" в ячейку ' + C.Address + ' (ID ' + ltrim(str(@nCellIDTarget)) + '), ' +
			'контейнер ' + ltrim(str(@nFrameID))   
	from Cells C with (nolock) 
	where C.ID = @nCellIDTarget
insert CellsChanges 
		(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
		DateEdit, Note, UserID, DeviceID, ParentID) 
	values (@nCellIDSource, @nFrameID, 
			Null, @nGoodStateID, @nPackingID, -@nQnt, @dDateValid, 
			@dNow, @cNote1, @nUserID, @nDeviceID, @nParentID)
select	@nParentID = @@Identity
insert CellsChanges 
		(CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
		DateEdit, Note, UserID, DeviceID, ParentID) 
	values (@nCellIDTarget, @nFrameID, 
			Null, @nGoodStateID, @nPackingID, @nQnt, @dDateValid, 
			@dNow, @cNote2, @nUserID, @nDeviceID, @nParentID)

-- Создаем траффик (только в случае, если конечная ячейка не предназначена для хранения)
if @bForStorage = 0 begin
	declare @nCellArrange int, @nError int, @cErrorText varchar(max)
	select @nError = 0, @cErrorText = ''
	exec up_FramesArrange @nFrameID, @nCellArrange output, @nError output, @cErrorText output
end
return

Tr_Error:
raiserror(N'Ошибка при сохранении данных...', 16, 1)
rollback tran Tr_AssemblyPallet
return