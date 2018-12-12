-- Процедура копирования ячеек из Trading в WMS
-- В конце - блокировка ячеек по их текущей занятости в Trading
if db_name() <> 'WMS' return

set nocount on

-- BarCodeLabels
/*insert into BarCodeLabels (Name, Type, Template, Data, 
	Copies, InvertLabel, NormalOrientationTemplate, InvertOrientationTemplate, Actual)
	values ('Ячейка 100х74', 'CL', 
		'^XA^DFR:Cell.zpl^FS^FO50,10^AUN,270,150^FN1^FS^FO50,300^BY4^BCN,200,N,N,N,N^FN2^FS^XZ', 
		'^XA^PO##InvertLabel##^PQ##Copies##^XFR:Cell.zpl^FN1^FD#Address#^FS^FN2^FD#BarCode#^FS^^XZ', 
		1, 0, 'N', 'I', 1)
insert into BarCodeLabels (Name, Type, Template, Data, 
	Copies, InvertLabel, NormalOrientationTemplate, InvertOrientationTemplate, Actual)
	values ('Контейнер 100х74', 'FR', 
		'^XA^DFR:Frame.zpl^FS^FO50,50^AVN,90,50^FN1^FS^FO50,200^BY3^BCN,200,N,N,N,N^FN2^FS^FO50,500^ATN,18,10^FN3^FS^XZ', 
		'^XA^PO##InvertLabel##^PQ##Copies##^XFR:Frame.zpl^FN1^FD#BarCode#^FS^FN2^FD#BarCode#^FS^FN3^FDDateBirth: #DateBirth#^FS^XZ', 
		3, 1, 'N', 'I', 1)

-- StoresZonesTypes (update)
update StoresZonesTypes set ForFrames = Null where ShortCode = 'IN'
update StoresZonesTypes set ForFrames = 0 where ShortCode = 'OUT'
update StoresZonesTypes set ForFrames = 0 where ShortCode = 'DFCT'
update StoresZonesTypes set ForFrames = Null where ShortCode = 'LOST&FOUND'
update StoresZonesTypes set ForFrames = 1 where ShortCode = 'BUF'
update StoresZonesTypes set ForFrames = 1 where ShortCode = 'STOR'
update StoresZonesTypes set ForFrames = 0 where ShortCode = 'PICK'
update StoresZonesTypes set ForFrames = 1 where ShortCode = 'RILL'

-- StoresZones
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Приемка', 1, '', Null, 'IN', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Отгрузка', 2, '', Null, 'OUT', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Брак', 3, '', Null, 'DF', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Виртуальная', 4, '', Null, 'LF', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Буфер приемки', 5, '', Null, '', '.BUF', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Буфер отгрузки', 5, '', Null, '', '.BUF', 1)

-- Individual Cells
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (1, '', '', '', '', '1', 
			'IN.1', 50000, 0, 0, 0, 0, 1)
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (2, '', '', '', '', '1', 
			'OUT.1', 50000, 0, 0, 0, 0, 1)
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (3, '', '', '', '', '1', 
			'DF.1', 50000, 0, 0, 0, 0, 1)
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (4, '', '', '', '', '1', 
			'LOST&FOUND', 1000000, 0, 0, 0, 1, 1)

insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (5, '', '', '', '', '1', 
			'IN.1.BUF', 50000, 0, 0, 0, 0, 1)
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (6, '', '', '', '', '1', 
			'OUT.1.BUF', 50000, 0, 0, 0, 0, 1)
update Cells set BufferCellID = 5 where ID = 1
update Cells set BufferCellID = 6 where ID = 2

-- AccommodationsRules
insert into AccommodationsRules (Name, Priority, SourceZoneTypeID, SourceZoneID, 
	OwnerControl, GoodStateControl, PackingControl, 
	CellPalletTypeControl, CellWeightControl, CellHeightControl, CellMaxQntControl, 
	RestsControl, FullPalletControl, HalfStuffControl, 
	AccommodationSortingID, TargetZoneTypeID, TargetZoneID, Actual) 
	values ('Весь брак', 1, Null, Null, 
		0, 1, 0, 
		0, 0, 0, 0, 
		0, Null, Null, 
		2, 3, Null, 1)
insert into AccommodationsRules (Name, Priority, SourceZoneTypeID, SourceZoneID, 
	OwnerControl, GoodStateControl, PackingControl, 
	CellPalletTypeControl, CellWeightControl, CellHeightControl, CellMaxQntControl, 
	RestsControl, FullPalletControl, HalfStuffControl, 
	AccommodationSortingID, TargetZoneTypeID, TargetZoneID, Actual) 
	values ('Все хранители, годный товар (пикинг)', 3, Null, Null, 
		0, 0, 1, 
		0, 0, 0, 1, 
		1, Null, Null, 
		2, 7, Null, 1)
insert into AccommodationsRules (Name, Priority, SourceZoneTypeID, SourceZoneID, 
	OwnerControl, GoodStateControl, PackingControl, 
	CellPalletTypeControl, CellWeightControl, CellHeightControl, CellMaxQntControl, 
	RestsControl, FullPalletControl, HalfStuffControl, 
	AccommodationSortingID, TargetZoneTypeID, TargetZoneID, Actual) 
	values ('Все хранители, годный товар (высотка)', 5, Null, Null, 
		0, 0, 0, 
		1, 1, 1, 1, 
		1, Null, Null, 
		1, 6, Null, 1)
*/
declare @nZoneStorageID int, @nZoneBufferID int, @nStBufID int
declare @nBufID int, @cNamePrefix varchar(5), @cNameSuffix varchar(5)

-- Код зоны высотного хранения
select @nZoneStorageID  = ID from StoresZonesTypes where ShortCode = 'STOR'
select @nZoneBufferID  = ID from StoresZonesTypes where ShortCode = 'BUF'
/*
if object_id('Tempdb..#_SB') is not Null drop table #_SB
select distinct left(Address, 1) as Building 
	into #_SB 
	from Trading.dbo.WHStorage 
	where left(Address, 1) in ('3', '4')
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	select 'Высотка ' + X.Building, @nZoneStorageID, '', 1, '', '', 1 
	from #_SB X 
	order by 1 

-- Создание буферной зоны
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Буфер высотки', @nZoneBufferID, '', 4, '', '.BUF', 1)
select @nStBufID = @@Identity
select @nBufID = ID, @cNamePrefix = NamePrefix, @cNameSuffix = NameSuffix 
	from StoresZones where ID = @nStBufID

-- Ячейки высотного хранения
insert into Cells (StoreZoneID, PalletTypeID, 
	CBuilding, CLine, CRack, CLevel, CPlace, Address, 
	MaxWeight, CellWidth, CellHeight, GoodsMono, MaxPalletQnt, Locked, Actual, ERPCode)
	select SZ.ID, 
		case when S.PalletWidth = 0.8 then 1 else 2 end, 
		left(S.Address, 1), 
		substring(S.Address, 2, 1),
		substring(S.Address, 3, 2),
		substring(S.Address, 5, 1),
		substring(S.Address, 6, 1),
		left(S.Address, 1) + substring(S.Address, 2, 1) + '.' + 
			substring(S.Address, 3, 2) + '.' + 
			substring(S.Address, 5, 1) + '.' + 
			substring(S.Address, 6, 1), 
		S.MaxWeight, 
		S.PalletWidth, 
		S.PalletHeight, 
		1, 1, 0, 1, S.Address 
	from Trading.dbo.WHStorage S 
	inner join StoresZones SZ on left(S.Address, 1) = right(SZ.Name, 1) 
		and SZ.StoreZoneTypeID = @nZoneStorageID 
	order by S.Address

-- Буфер высотного хранения
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, Address, 
	MaxWeight, CellWidth, CellHeight, GoodsMono, MaxPalletQnt, Locked, Actual)
	select @nBufID, 
		left(S.Line, 1), 
		right(S.Line, 1),
		'', '', '', 
		S.Line + @cNameSuffix, 
		0, 0, 0, 0, 4, 0, 1
	from (select distinct CBuilding + CLine as Line 
			from Cells where StoreZoneID in 
				(select ID from StoresZones where StoreZoneTypeID = @nZoneStorageID)) S 
	order by S.Line

-- Приписка буферов к высотке
update Cells set BufferCellID = X.ID 
	from (select ID, CBuilding, CLine from Cells where StoreZoneID = @nBufID) X 
	where Cells.StoreZoneID in (select ID from StoresZones where StoreZoneTypeID = @nZoneStorageID) and 
		Cells.CBuilding = X.CBuilding and Cells.CLine = X.CLine

-- Блокировка ячеек по их текущей занятости в Trading
update Cells 
	set Actual = 0 
	from Trading.dbo.WHStorage X 
	where Cells.ERPCode = X.Address and X.State is not Null

------------------------------------------------------------

-- Для начального запуска ИНКО с пикингом не работаем!!!
RETURN
*/
------------------------------------------------------------

-- Зоны пикинга
-- Для привязки ячеек к товарам должны быть заполнены таблицы Goods & Packings
declare @nZonePickingID int, @nPkBufID int
select @nZonePickingID  = ID from StoresZonesTypes where ShortCode = 'PICK'

-- Проверка уникальности адресов
declare @cDoubleAddresses varchar(max)
set @cDoubleAddresses = ''
select @cDoubleAddresses = @cDoubleAddresses + 
	Address + ',' 
	from Trading.dbo.WHPicking 
	where Address in (select Address from Cells)
if len(@cDoubleAddresses) > 0 begin
	print @cDoubleAddresses
	raiserror(N'Duplicated addresses!', 16, 1)
	return
end

-- Создание зон пикинга
if object_id('Tempdb..#_PB') is not Null drop table #_PB
select distinct left(Address, 1) as Building 
	into #_PB 
	from Trading.dbo.WHPicking 
	where Address is not Null
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	select 'Пикинг ' + X.Building, @nZonePickingID, '', 1, '', '', 1 
	from #_PB X 
	order by 1 

-- Создание буферной зоны
-- ОТМЕНЕНО: создаем вручную
/*insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Буфер пикинга', @nZoneBufferID, '', Null, 'PB', '', 1)
select @nPkBufID = @@Identity
select @nBufID = ID, @cNamePrefix = NamePrefix, @cNameSuffix = NameSuffix 
	from StoresZones where ID = @nPkBufID*/

-- Ячейки пикинга
if object_id('Tempdb..#PickCells') is not Null drop table #PickCells
select SZ.ID as StoreZoneID, 
	left(S.Address, 1) as CBuilding, 
	substring(S.Address, 2, 1) as CLine,
	substring(S.Address, 3, 2) as CRack,
	substring(S.Address, 5, 1) as CLevel,
	substring(S.Address, 6, 1) as CPlace,
	left(S.Address, 1) + substring(S.Address, 2, 1) + '.' + 
		substring(S.Address, 3, 2) + '.' + 
		substring(S.Address, 5, 1) + '.' + 
		substring(S.Address, 6, 1) as Address, 
	1 as FixedGoodStateID, 
	/*P.ID*/Null as FixedPackingID, 
	0 as MaxWeight, 
	0 as CellWidth, 
	0 as CellHeight, 
	1 as GoodsMono, 
	1 as MaxPalletQnt, 
	1 as Locked, 
	1 as Actual 
	into #PickCells
	from Trading.dbo.WHPicking S 
	inner join StoresZones SZ on left(S.Address, 1) = right(SZ.Name, 1) and 
		SZ.StoreZoneTypeID = @nZonePickingID 
	order by S.Address
insert into Cells (StoreZoneID, 
	CBuilding, CLine, CRack, CLevel, CPlace, Address, 
	FixedGoodStateID, FixedPackingID, 
	MaxWeight, CellWidth, CellHeight, 
	GoodsMono, MaxPalletQnt, Locked, Actual) 
	select StoreZoneID, 
		CBuilding, CLine, CRack, CLevel, CPlace, Address, 
		FixedGoodStateID, FixedPackingID, 
		MaxWeight, CellWidth, CellHeight, 
		GoodsMono, MaxPalletQnt, Locked, Actual 
	from #PickCells

-- Буфер пикинга
-- ОТМЕНЕНО: создаем вручную
/*insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, Address, 
	MaxWeight, CellWidth, CellHeight, GoodsMono, MaxPalletQnt, Locked, Actual)
	select @nBufID, 
		P.Building, 
		'',
		'', '', '', 
		@cNamePrefix + P.Building + @cNameSuffix, 
		0, 0, 0, 0, 50, 0, 1
	from #_PB P 
	order by P.Building

-- Приписка буферов к пикингу
update Cells set BufferCellID = X.ID 
	from (select ID, CBuilding, CLine from Cells where StoreZoneID = @nBufID) X 
	where Cells.StoreZoneID in (select ID from StoresZones where StoreZoneTypeID = @nZonePickingID) and 
		Cells.CBuilding = X.CBuilding and X.CLine = ''*/

-- Установка ранга ячеек по умолчанию
/*update Cells set Rank = ID 
	where StoreZoneID in (select ID from StoresZones where StoreZoneTypeID = @nZonePickingID)*/
