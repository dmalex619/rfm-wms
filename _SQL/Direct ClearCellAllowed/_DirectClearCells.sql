USE [WMS]
GO
/****** Object:  StoredProcedure [dbo].[_DirectClearCells]    Script Date: 10/31/2008 13:41:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[_DirectClearCells] 
	@cCellsList		varchar(max)
AS
-- Процедура прямой очистки содержимого ячеек высотной зоны.
-- Может применятся на дистрибуционных складах на первой стадии запуска WMS (только приход и размещение)
-- Так как в это время снятие паллет с высотной зоны происходит через старую программу (1C, Trading, etc.),
-- необходим максимально безопасный способ очистки ячеек.
--
-- Входной параметр содержит разделенный запятыми список адресов ячеек высотной зоны,
-- которые требуется очистить от содержимого (CellsContents) 
-- и перевести в актуальное состояние (Cells.Actual)
--
-- Пример вызова: execute _DirectClearCells '3A.01.1.1,3B.02.2.2'
--
-- Для бОльшей безопасности процедура проверяет наличие специальной установки в таблице _Settings

set nocount on

-- Проверка установки
declare @cClearCellsAllowed varchar(50)
select @cClearCellsAllowed = dbo._SettingsGetValue('bClearCellsAllowed')
if IsNull(@cClearCellsAllowed, '') <> 'True' begin
	RaisError(N'Отсутствует разрешительная установка!', 16, 1)
	return
end

-- Проверка параметра
if @cCellsList is Null begin
	RaisError(N'Неверный входной параметр!', 16, 1)
	return
end
set @cCellsList = dbo._NormalizeList(@cCellsList)

-- Формирование таблицы очищаемых ячеек
declare @cAddress varchar(20), @nPos int
create table #Cells (ID int, Address varchar(20), Actual bit, FrameID int)
while len(@cCellsList) > 0 begin
	set @nPos = charindex(',', @cCellsList)
	if @nPos = 0 begin
		set @cAddress = @cCellsList
		set @cCellsList = ''
	end
	else begin
		set @cAddress = substring(@cCellsList, 1, @nPos - 1)
		set @cCellsList = substring(@cCellsList, @nPos + 1, len(@cCellsList))
	end
	
	insert into #Cells (Address) values (@cAddress)
end

-- Проверка пустоты таблицы
if not exists (select top 1 * from #Cells) begin
	RaisError(N'Пустой список адресов ячеек!', 16, 1)
	return
end

-- Проверка уникальности адресов
if exists (select Address, count(*) from #Cells group by Address having count(*) > 1) begin
	RaisError(N'Список адресов ячеек не является уникальным!', 16, 1)
	return
end

-- Получение данных о ячейках
update #Cells set 
	ID			= X.ID, 
	Actual		= X.Actual, 
	FrameID		= X.FrameID 
	from (select C.ID, C.Address, C.Actual, CC.FrameID 
			from Cells C with (nolock) 
			inner join StoresZones SZ with (nolock) on C.StoreZoneID = SZ.ID 
			inner join StoresZonesTypes SZT with (nolock) on SZ.StoreZoneTypeID = SZT.ID 
			left join CellsContents CC with (nolock) on CC.CellID = C.ID 
			where SZT.ShortCode = 'STOR') X 
	where #Cells.Address = X.Address

-- Проверка корректности адресов ячеек
-- ID будет пустым либо при кривом адресе, либо при адресе не из зоны типа "Хранение"
if exists (select top 1 * from #Cells where ID is Null) begin
	RaisError(N'Неверный список адресов ячеек!', 16, 1)
	return
end

-- Дополнительная проверка
-- Ячейка должна быть:
--		либо актуальна и не пуста (находится под управлением WMS),
--		либо неактуальна и пуста (находится под управлением старого хоста)
set @cCellsList = ''
select @cCellsList = @cCellsList + Address + ',' 
	from	#Cells 
	where	Actual = 1 and FrameID is Null
if len(@cCellsList) > 0 begin
	set @cCellsList = left(@cCellsList, len(@cCellsList) - 1)
	RaisError(N'Попытка очистки уже пустых ячеек (%s)! Проверьте коррктность данных!', 16, 1, @cCellsList)
	return
end
select @cCellsList = @cCellsList + Address + ',' 
	from	#Cells 
	where	Actual = 0 and FrameID is not Null
if len(@cCellsList) > 0 begin
	set @cCellsList = left(@cCellsList, len(@cCellsList) - 1)
	RaisError(N'Попытка очистки неактуальных, но непустых ячеек (%s)! Проверьте коррктность данных!', 16, 1, @cCellsList)
	return
end

-- Все проверки пройдены, начинаем очистку и актуализацию ячеек
begin tran
	-- журнал
	insert into CellsChanges (CellID, FrameID, OwnerID, GoodStateID, PackingID, Qnt, DateValid, 
		DateEdit, Note, NoteManual, UserID, DeviceID, ParentID, ERPCode) 
		select X.ID, X.FrameID, CC.OwnerID, CC.GoodStateID, CC.PackingID, -CC.Qnt, CC.DateValid, 
			GetDate(), 'Прямая очистка ячейки', '', Null, Null, Null, Null 
			from #Cells X 
			inner join CellsContents CC with (nolock) on X.ID = CC.CellID and X.FrameID = CC.FrameID 
			where X.FrameID is not Null
	if @@Error <> 0 goto Tr_Error

	-- содержимое ячеек
	delete CellsContents 
		from	#Cells X 
		where	CellsContents.CellID = X.ID
	if @@Error <> 0 goto Tr_Error
	
	-- актуальность ячеек
	update Cells set Actual = 1 
		from	#Cells X 
		where	Cells.ID = X.ID
	if @@Error <> 0 goto Tr_Error
	
	-- удаление контейнеров
	update Frames set Actual = 0, State = 'D' 
		from	#Cells X 
		where	X.FrameID is not Null and Frames.ID = X.FrameID
	if @@Error <> 0 goto Tr_Error

commit tran
return

Tr_Error:
rollback
RaisError(N'Ошибка SQL при очистке ячеек!', 16, 1)
return