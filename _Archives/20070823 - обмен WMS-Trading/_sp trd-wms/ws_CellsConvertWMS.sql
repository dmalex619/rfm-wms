USE [Trading]
GO
/****** Object:  StoredProcedure [dbo].[ws_CellsConvertWMS]    Script Date: 10/25/2007 14:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ws_CellsConvertWMS]
	@xCellsData		varchar(max), 
	@nError			int output, 
	@cReport		varchar(max) output
as 
-- Выгрузка данных о ячейках и исправлении ошибок (из БД WMS) 
-- Выполняется в БД Trading
-- Процедура делает следующее:
--		1. изменяет геометрию всех ячеек высотной зоны
--		2. заливает остатки по неблокированным ячейкам
-- Ячейки в WMS блокируются при начальной заливке данных,
-- и разблокируются в процессе работы при снятии паллет через Trading
-- Последние изменения: Александров 25.10.2007

set nocount on

if @xCellsData is Null or len(@xCellsData) = 0 begin
	set @nError = -99
	raiserror('XML-файл пуст...', 11, 1)
	return	
end

set @cReport   = ''
declare @nHandle int
execute sp_xml_preparedocument @nHandle output, @xCellsData

if @nHandle < 0 begin
	set @nError = -1
	raiserror('Ошибка чтения XML-файла...', 11, 1)
	return	
end

-- .NET WebService возвращает дату в формате "YYYY-MM-DDTHH:MM:SS+TS:MS"
-- где +TS:MS означает смещение часового пояса
-- SQL стандартно такую дату не воспринимает!
-- Для обхода ошибки все поля типа DateTime считываются как varchar(19)
select * 
	into #CellsStates 
	from openxml (@nHandle, '//CellsStates', 1) 
	with (	CellID int 'CellID', 
			CellERPCode varchar(10) 'CellERPCode', 
			CellBuilding varchar(2) 'CellBuilding', 
			CellLine varchar(2) 'CellLine', 
			CellRack varchar(2) 'CellRack', 
			CellLevel varchar(2) 'CellLevel', 
			CellPlace varchar(2) 'CellPlace', 
			CellWidth decimal(10,3) 'CellWidth', 
			CellHeight decimal(10,3) 'CellHeight', 
			CellMaxWeight decimal(10,3) 'CellMaxWeight', 
			CellLocked bit 'CellLocked', 
			CellActual bit 'CellActual', 
			ZoneTypeShortCode varchar(25) 'ZoneTypeShortCode', 
			ContentERPOwner int 'ContentERPOwner', 
			ContentERPGoodState int 'ContentERPGoodState', 
			ContentERPGood int 'ContentERPGood', 
			ContentInBox decimal(10,3) 'ContentInBox', 
			ContentBoxInPal int 'ContentBoxInPal', 
			ContentDateValid varchar(19) 'ContentDateValid', 
			ContentQnt decimal(18,3) 'ContentQnt')
if object_id('tempdb..#CellsStates') is Null begin
	set @nError = -2
	raiserror('XML-файл не содержит данных о ячейках...', 11, 1)
	return	
end

-- Удаление ячеек, не относящихся к высоткам
delete #CellsStates 
	where ZoneTypeShortCode <> 'STOR'
if not exists (select top 1 * from #CellsStates) begin
	set @nError = -3
	raiserror('Выборка не содержит данных о ячейках высотной зоны...', 11, 1)
	return	
end

-- Получение кодов упаковок
alter table #CellsStates add Packing int Null

-- Создание временной таблицы для определения кодов упаковок
select Good, InBox, BoxInPal, Actual, Uniq 
	into #_Packings 
	from Packings 
	order by Good, InBox, BoxInPal, ~Actual, Uniq desc
if @@Error <> 0 begin
	set @nError = -4
	raiserror(N'Неудачная выборка из Packings!', 16, 1)
	return
end

-- Заполняем код упаковки Trading
update #CellsStates set Packing = X.Uniq 
	from #_Packings X 
	where #CellsStates.Packing is Null and 
		#CellsStates.ContentERPGood = X.Good and 
		#CellsStates.ContentInBox = X.InBox and 
		#CellsStates.ContentBoxInPal = X.BoxInPal and 
		X.Actual = 1
update #CellsStates set Packing = X.Uniq 
	from #_Packings X 
	where #CellsStates.Packing is Null and 
		#CellsStates.ContentERPGood = X.Good and 
		#CellsStates.ContentInBox = X.InBox and 
		#CellsStates.ContentBoxInPal = X.BoxInPal
update #CellsStates set Packing = X.Uniq 
	from #_Packings X 
	where #CellsStates.Packing is Null and 
		#CellsStates.ContentERPGood = X.Good and 
		#CellsStates.ContentInBox = X.InBox
if exists(select * from #CellsStates where Packing is Null and IsNull(ContentQnt, 0) <> 0) begin
	set @nError = -5
	raiserror('XML-файл содержит неизвестный товар...', 11,1)
end

-- Добавляем в таблицу адреса ячеек по правилам Trading
alter table #CellsStates add CompoundAddress varchar(6) Null
update #CellsStates set CompoundAddress = 
	CellBuilding + CellLine + CellRack + CellLevel + CellPlace
if exists (select * from #CellsStates where CompoundAddress is Null) begin
	set @nError = -6
	raiserror('Ошибки в адресации ячеек...', 11,1)
end

begin try
	-- В случае, если #CellsStates содержит несколько строк для одной ячейки, 
	-- чего в высотке быть не должно, 
	-- создание уникального индекса лажанется и сгенерит ошибку
	create unique index IX_CellsID on #CellsStates (CellID)
	create unique index IX_CellsCompoundAddress on #CellsStates (CompoundAddress)
end try
begin catch
	set @nError = -7
	raiserror(N'Обнаружено неуникальное содержимое ячеек высотки в БД WMS!', 16, 1)
	return
end catch

-- Проверка таблицы складов на уникальность
if exists (select Owner, WMSGoodState, count(*) 
			from Depots 
			group by Owner, WMSGoodState 
			having count(*) > 1) begin
	set @nError = -8
	raiserror(N'Неуникальное сочетание владельца склада и состояния товара в таблице Depots!', 16, 1)
	return
end

-- Разбираемся с кодами складов
-- На таблицу Trd.Depots наложен уникальный индекс (Owner + WMSGoodState)
-- Получаем список уникальных сочетаний Owner + WMSGoodState в обрабатываемых приходах
-- и, при небходимости, автоматически создаем новые склады,
-- т.к. в WMS можно принять товар некоего владельца в состоянии, 
-- отсутствующем в справочнике складов!
select distinct C.ContentERPOwner, C.ContentERPGoodState 
	into #NewDepots 
	from #CellsStates C 
	where cast(C.ContentERPOwner as varchar(10)) + '_' + cast(C.ContentERPGoodState as varchar(10)) 
		not in (select 
				cast(Owner as varchar(10)) + '_' + cast(WMSGoodState as varchar(10)) 
				from Depots)
if exists (select * from #NewDepots) begin
	insert into Depots (Alias, Name, 
		Owner, Basic, NoControl, Actual, 
		Deposit, SeparatePicking, WMSGoodState, ICode) 
		select P.Alias + ' (WMS)', P.Alias + ' (WMS)', 
			X.ContentERPOwner, 0, 1, 1, 
			1, 0, X.ContentERPGoodState, Null 
			from #NewDepots X 
			inner join Partners P on X.ERPOwner = P.Uniq
	if @@Error <> 0 begin
		set @nError = -9
		raiserror('Не удалось автоматически создать новые склады (Depots)...', 11,1)
	end
end

-- Создание временной таблицы складов
select Uniq, Owner, WMSGoodState 
	into #_Depots 
	from Depots 
	order by Owner, WMSGoodState

-- Заполняем код склада Trading
alter table #CellsStates add Depot int Null
update #CellsStates set Depot = X.Uniq 
	from #_Depots X 
	where	#CellsStates.ContentERPOwner = X.Owner and 
			#CellsStates.ContentERPGoodState = X.WMSGoodState
if exists (select * from #CellsStates where Depot is Null and IsNull(ContentQnt, 0) <> 0) begin
	raiserror(N'Обнаружены неизвестные склады в #CellsStates!', 16, 1)
	return
end


-------------------------------------------------------------------------------
set @nError = 0
declare @nCount int

begin tran
	-- Геометрия, актуальность, блокировка ячеек
	-- добавить новые 
	if exists (select CellID 	
					from	#CellsStates 
					where	CompoundAddress not in (select Address from WHStorage)
				) begin
		insert	WHStorage
			(Address, WHZone, PalletWidth, PalletHeight, MaxWeight, 
				Depot, State, Packing, Qnt, DateValid, Locked, Actual)
			select CompoundAddress, 
				0 as WHZone, 
				CellWidth, CellHeight, CellMaxWeight, 
				Null as Depot, 
				Null as State, 
				Null as Packing, 
				Null as Qnt, 
				Null as DateValid, 
				C.CellLocked, C.CellActual
			from	#CellsStates C 
			where	C.CompoundAddress not in (select Address from WHStorage)
		select @nError = @@Error, @nCount = @@RowCount
		if @nError <> 0 goto Tr_Error
		print 'Insert WHStorage: ' + ltrim(str(@nCount))
	end
	
	-- обновить существующие
	-- Блокировку в WMS не учитываем, иначе все занятые ячейки
	-- станут недоступны для снятия
	update	WHStorage 
		set		PalletWidth = C.CellWidth, 
				PalletHeight = C.CellHeight, 
				MaxWeight = C.CellMaxWeight, 
				--Locked = C.CellLocked, 
				Actual = C.CellActual 
		from	#CellsStates C 
		where	C.CompoundAddress = WHStorage.Address and (
			WHStorage.PalletWidth <> C.CellWidth or 
			WHStorage.PalletHeight <> C.CellHeight or 
			WHStorage.MaxWeight <> C.CellMaxWeight or 
			--WHStorage.Locked <> C.CellLocked or 
			WHStorage.Actual <> C.CellActual 
			)
	select @nError = @@Error, @nCount = @@RowCount
	if @nError <> 0 goto Tr_Error
	print 'Update WHStorage: ' + ltrim(str(@nCount))
	
	-- удалить удаленные 
	if exists (select Uniq	
					from	WHStorage
					where	Address not in (select CompoundAddress from #CellsStates) 
				) begin
		-- прямо сразу удалить? может, хотя бы снимем актуальность? 
		/*update	WHStorage 
			set		Actual = 0 
			from	#CellsStates 
			where	WHStorage.Address not in (select Address from #CellsStates)
		select @nError = @@Error, @nCount = @@RowCount
		if @nError <> 0 goto Tr_Error*/
		
		delete	WHStorage 
			where	Address not in (select CompoundAddress from #CellsStates)
		select @nError = @@Error, @nCount = @@RowCount
		if @nError <> 0 goto Tr_Error
		print 'Delete WHStorage: ' + ltrim(str(@nCount))
	end 
	
	-- Обновляем содержимое неблокированных ячеек
	update	WHStorage 
		set		Depot		= case when C.ContentQnt <> 0 then C.Depot else Null end, 
				Packing		= case when C.ContentQnt <> 0 then C.Packing else Null end, 
				Qnt			= case when C.ContentQnt <> 0 then C.ContentQnt else Null end, 
				DateValid	= case when C.ContentQnt <> 0 then C.ContentDateValid else Null end, 
				State		= case when C.ContentQnt <> 0 then 'S' else Null end 
		from	#CellsStates C 
		where	C.CompoundAddress = WHStorage.Address and C.CellLocked = 0 and (
			IsNull(WHStorage.Depot, 0)		<> IsNull(C.Depot, 0) or 
			IsNull(WHStorage.Packing, 0)	<> IsNull(C.Packing, 0) or 
			IsNull(WHStorage.Qnt, 0)		<> IsNull(C.ContentQnt, 0) or 
			IsNull(WHStorage.DateValid, '20000101')	<> IsNull(C.ContentDateValid, '20000101') 
			)
	select @nError = @@Error, @nCount = @@RowCount
	if @nError <> 0 goto Tr_Error
	print 'Update WHStorage Qnt: ' + ltrim(str(@nCount))

commit tran
return

Tr_Error:
raiserror('Ошибка %d', 16, 1, @nError)
rollback
return