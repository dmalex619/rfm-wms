-- МБК
-- Standart cells begin

-- ВНИМАНИЕ!!!
-- После закачки из хоста данных о состояниях товара
-- обязательно приписать состояние "Брак" ячейка брака!!!

set nocount on

-- BarCodeLabels
insert into BarCodeLabels (Name, Type, Template, Data, 
	Copies, InvertLabel, NormalOrientationTemplate, InvertOrientationTemplate, Actual)
	values ('Ячейка 100х74', 'CL', 
		'^XA^DFR:Cell.zpl^MTD~SD15^FS^FO50,10^AUN,270,150^FN1^FS^FO50,300^BY4^BCN,200,N,N,N,N^FN2^FS^XZ', 
		'^XA^PO##InvertLabel##^PQ##Copies##^XFR:Cell.zpl^FN1^FD#Address#^FS^FN2^FD#BarCode#^FS^^XZ', 
		1, 0, 'N', 'I', 1)
insert into BarCodeLabels (Name, Type, Template, Data, 
	Copies, InvertLabel, NormalOrientationTemplate, InvertOrientationTemplate, Actual)
	values ('Контейнер 100х74', 'FR', 
		'^XA^DFR:Frame.zpl^MTD~SD15^FS^FO70,50^AVN,90,50^FN1^FS^FO70,200^BY3^BCN,200,N,N,N,N^FN2^FS^FO70,500^ATN,18,10^FN3^FS^XZ', 
		'^XA^PO##InvertLabel##^PQ##Copies##^XFR:Frame.zpl^FN1^FD#BarCode#^FS^FN2^FD#BarCode#^FS^FN3^FDDateBirth: #DateBirth#^FS^XZ', 
		2, 1, 'N', 'I', 1)

-- StoresZonesTypes (update)
update StoresZonesTypes set ForFrames = 1 where ShortCode = 'IN'
update StoresZonesTypes set ForFrames = 0 where ShortCode = 'OUT'
update StoresZonesTypes set ForFrames = 0 where ShortCode = 'DFCT'
update StoresZonesTypes set ForFrames = Null where ShortCode = 'LOST&FOUND'
update StoresZonesTypes set ForFrames = 1 where ShortCode = 'BUF'
update StoresZonesTypes set ForFrames = 1 where ShortCode = 'STOR'
update StoresZonesTypes set ForFrames = 0 where ShortCode = 'PICK'
update StoresZonesTypes set ForFrames = 1 where ShortCode = 'RILL'

-- StoresZones
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Приемка из цеха производства', 1, '', Null, 'IN', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Приемка от поставщиков', 1, '', Null, 'IN', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Отгрузка в цех производства', 2, '', Null, 'OUT', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Отгрузка покупателям', 2, '', Null, 'OUT', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Брак', 3, '', Null, 'DF', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Виртуальная', 4, '', Null, 'LF', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Буфер отгрузки', 5, '', Null, '', '.BUF', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Пикинг', 7, '', 1, '', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Пристенок (готовая продукция)', 6, '', 1, '', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Пристенок (полуфабрикат)', 6, '', 1, '', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Ручей (готовая продукция)', 8, '', 18, '', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Ручей (полуфабрикат)', 8, '', 21, '', '', 1)

-- Cells
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (1, '', '', '', '', '1', 'IN.1', 50000, 0, 0, 0, 0, 1)
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (2, '', '', '', '', '2', 'IN.2', 50000, 0, 0, 0, 0, 1)
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (3, '', '', '', '', '1', 'OUT.1', 50000, 0, 0, 0, 0, 1)
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (4, '', '', '', '', '2', 'OUT.2', 50000, 0, 0, 0, 0, 1)
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (5, '', '', '', '', '1', 'DF.1', 50000, 0, 0, 0, 0, 1)
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (6, '', '', '', '', '1', 'LOST&FOUND', 1000000, 0, 0, 0, 1, 1)

declare @nStoreZoneTypeID int, @nStoreZoneID int
declare @cBuilding varchar(1), @cLine varchar(1), @nRack int, @nLevel int, @cPlace varchar(1)
declare @nRackLimit int

-- Outputs Cells Buffers
set @nStoreZoneTypeID = Null
select @nStoreZoneTypeID = ID 
	from StoresZonesTypes 
	where ShortCode = 'BUF'
if @nStoreZoneTypeID is Null return

-- StoresZones
set @nStoreZoneID = Null
select @nStoreZoneID = ID 
	from StoresZones 
	where StoreZoneTypeID = @nStoreZoneTypeID
if @nStoreZoneID is Null return

declare @nOutBuf1 int, @nOutBuf2 int
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (@nStoreZoneID, '', '', '', '', '1', 'OUTBUF.1', 50000, 0, 0, 0, 0, 1)
set @nOutBuf1 = @@Identity
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (@nStoreZoneID, '', '', '', '', '2', 'OUTBUF.2', 50000, 0, 0, 0, 0, 1)
set @nOutBuf2 = @@Identity
update Cells set BufferCellID = @nOutBuf1 where Address = 'OUT.1'
update Cells set BufferCellID = @nOutBuf2 where Address = 'OUT.2'
-- Standart cells end



-- Make some Rills
set @nStoreZoneTypeID = Null
select @nStoreZoneTypeID = ID 
	from StoresZonesTypes 
	where ShortCode = 'RILL'
if @nStoreZoneTypeID is Null return

-- StoresZones
/*
set @nStoreZoneID = Null
select @nStoreZoneID = ID 
	from StoresZones 
	where StoreZoneTypeID = @nStoreZoneTypeID
if @nStoreZoneID is Null return
*/

declare @nRillFullID int
select @nRillFullID = ID 
	from StoresZones 
	where StoreZoneTypeID = @nStoreZoneTypeID and charindex('готовая продукция', Name) > 0
if @nRillFullID is Null return
declare @nRillHalfID int
select @nRillHalfID = ID 
	from StoresZones 
	where StoreZoneTypeID = @nStoreZoneTypeID and charindex('полуфабрикат', Name) > 0
if @nRillHalfID is Null return

-- Rill Cells
select @cBuilding = '', @cLine = 'C', @nRack = 1, @nLevel = 1, @cPlace = ''

while @cLine <= 'F' begin
	set @nRackLimit = case when @cLine in ('C', 'E') then 26 else 24 end
	while @nRack <= @nRackLimit begin
		while @nLevel <= 5 begin
			insert into Cells (StoreZoneID, 
				CBuilding, CLine, CRack, CLevel, CPlace, 
				Address, 
				MaxWeight, CellWidth, CellHeight, PalletTypeID, 
				[Rank], 
				GoodsMono, Locked, Actual)
				values (case when @cLine in ('C', 'D') then @nRillFullID else @nRillHalfID end, 
					@cBuilding, @cLine, replace(str(@nRack, 2), ' ', '0'), cast(@nLevel as varchar), @cPlace, 
					'' + @cLine + '.' + 
						replace(str(@nRack, 2), ' ', '0') + '.' + 
						cast(@nLevel as varchar), 
					case when @cLine in ('C', 'D') then 13500 else 15750 end, 0.8, 
					case when @nLevel = 5 and 
						((@cLine in ('C', 'E') and @nRack not in ( 9, 10, 11, 12, 20, 21, 22, 23)) or 
						 (@cLine in ('D', 'F') and @nRack not in ( 7,  8,  9, 10, 18, 19, 20, 21))) 
						then 2.1 else 1.7 end, 1, 
					@nRack, 
					1, 0, 1)
			set @nLevel = @nLevel + 1
		end
		set @nRack = @nRack + 1
		set @nLevel = 1
	end
	set @cLine = char(ascii(@cLine) + 1)
	set @nRack = 1
end



-- Пристеночные стеллажи очень хитрые!
--
-- 1. Стеллажи со стороны производства (G & H):
--		a) 1-ый этаж - паллетный буфер отгрузки в производство (1 ячейка)
--		b) со 2-го по 5-ый этажи - паллетное хранение хвостов для полуфабриката (212 ячеек)
-- 2. Стеллаж со стороны улицы (B):
--		a) 1-ый этаж - паллетный буфер отгрузки на сторону (1 ячейка)
--		b) со 2-го по 5-ый этажи - паллетное хранение хвостов для готовой продукции (100 ячеек)
-- 3. Стеллаж со стороны улицы (A):
--		a) стояки 1-9, 1-ый этаж - паллетный буфер отгрузки на сторону (1 ячейка)
--		b) стояки 1-6, со 2-го по 5-ый этажи - паллетное хранение хвостов для готовой продукции (24 ячейки)
--		b) стояки 7-9, с  3-го по 5-ый этажи - паллетное хранение хвостов для готовой продукции (9 ячеек)
--			(ячейки 2-го этажа на стояках с 7-го по 9-ый исключены под ворота)
--		c) стояки 10-28, с 1-го по 3-ий этажи - пикинг готовой продукции (57 ячеек)
--		d) стояки 10-28, с 4-го по 5-ый этажи - брак (1 ячейка)
--
-- ИТОГО: в зонах A, B, G, H - 402 ячеек разного назначения, имеющих букву линии в адресе,
--	плюс 1 разнесенная ячейка буфера отгрузки в производство (G & H)
--	плюс 1 разнесенная ячейка буфера отгрузки на сторону (A & B)
--	плюс 1 ячейка брака



-- Get Picking zone ID
set @nStoreZoneTypeID = Null
select @nStoreZoneTypeID = ID 
	from StoresZonesTypes 
	where ShortCode = 'PICK'
if @nStoreZoneTypeID is Null return

-- PickingZones
declare @nPickingZoneID int
set @nPickingZoneID = Null
select @nPickingZoneID = ID 
	from StoresZones 
	where StoreZoneTypeID = @nStoreZoneTypeID
if @nPickingZoneID is Null return

-- Make some Storage
set @nStoreZoneTypeID = Null
select @nStoreZoneTypeID = ID 
	from StoresZonesTypes 
	where ShortCode = 'STOR'
if @nStoreZoneTypeID is Null return

-- StoresZones
/*
set @nStoreZoneID = Null
select @nStoreZoneID = ID 
	from StoresZones 
	where StoreZoneTypeID = @nStoreZoneTypeID
if @nStoreZoneID is Null return
*/

declare @nStorFullID int
select @nStorFullID = ID 
	from StoresZones 
	where StoreZoneTypeID = @nStoreZoneTypeID and charindex('готовая продукция', Name) > 0
if @nStorFullID is Null return
declare @nStorHalfID int
select @nStorHalfID = ID 
	from StoresZones 
	where StoreZoneTypeID = @nStoreZoneTypeID and charindex('полуфабрикат', Name) > 0
if @nStorHalfID is Null return

declare @nLevelStorageStart int, @nRackPickingStart int
select  @nLevelStorageStart = 2, @nRackPickingStart = 10

-- Storage Cells
select @cBuilding = '', @cLine = 'A', @nRack = 1, @nLevel = @nLevelStorageStart, @cPlace = ''

while @cLine <= 'H' begin
	if @cLine in ('C', 'D', 'E', 'F') goto NextLine
	
	set @nRackLimit = case when @cLine = 'A' then 9 when @cLine = 'G' then 28 else 25 end
	while @nRack <= @nRackLimit begin
		while @nLevel <= 5 begin
			-- Исключаем ворота
			if @cLine = 'A' and @nRack between 7 and 9 and @nLevel = 2 goto NextStep
			
			insert into Cells (StoreZoneID, 
				CBuilding, CLine, CRack, CLevel, CPlace, 
				Address, 
				MaxWeight, CellWidth, CellHeight, PalletTypeID, 
				[Rank], 
				GoodsMono, Locked, Actual)
				values (case when @cLine in ('A', 'B') then @nStorFullID 
						else @nStorHalfID end, 
					@cBuilding, @cLine, replace(str(@nRack, 2), ' ', '0'), cast(@nLevel as varchar), @cPlace, 
					'' + @cLine + '.' + 
						replace(str(@nRack, 2), ' ', '0') + '.' + 
						cast(@nLevel as varchar), 
					750, 0.8, case when @nLevel = 5 then 2.1 else 1.7 end, 1, 
					@nRack, 
					1, 0, 1)
			
			NextStep:
			set @nLevel = @nLevel + 1
		end
		set @nRack = @nRack + 1
		set @nLevel = @nLevelStorageStart
	end
	
	NextLine:
	set @cLine = char(ascii(@cLine) + 1)
	set @nRack = 1
end



-- Picking Cells
select @cBuilding = '', @cLine = 'A', @nRack = @nRackPickingStart, @nLevel = 1, @cPlace = ''

while @cLine <= 'A' begin
	set @nRackLimit = 28
	while @nRack <= @nRackLimit begin
		while @nLevel <= 3 begin
			insert into Cells (StoreZoneID, 
				CBuilding, CLine, CRack, CLevel, CPlace, 
				Address, 
				MaxWeight, CellWidth, CellHeight, PalletTypeID, 
				GoodsMono, Locked, Actual)
				values (@nPickingZoneID, 
					@cBuilding, @cLine, replace(str(@nRack, 2), ' ', '0'), cast(@nLevel as varchar), @cPlace, 
					'' + @cLine + '.' + 
						replace(str(@nRack, 2), ' ', '0') + '.' + 
						cast(@nLevel as varchar), 
					750, 0.8, case when @nLevel = 5 then 2.1 else 1.7 end, 1, 
					1, 0, 1)
			set @nLevel = @nLevel + 1
		end
		set @nRack = @nRack + 1
		set @nLevel = 1
	end
	
	set @cLine = char(ascii(@cLine) + 1)
	set @nRack = @nRackPickingStart
end



-- AccommodationsRules
insert into AccommodationsRules (Name, Priority, SourceZoneTypeID, SourceZoneID, 
	OwnerControl, GoodStateControl, PackingControl, 
	CellPalletTypeControl, CellWeightControl, CellHeightControl, CellMaxQntControl, 
	RestsControl, FullPalletControl, HalfStuffControl, 
	TargetZoneTypeID, TargetZoneID, Actual) 
	values ('Брак', 1, Null, Null, 
		0, 1, 0, 
		0, 0, 0, 0, 
		0, Null, Null, 
		3, Null, 1)
insert into AccommodationsRules (Name, Priority, SourceZoneTypeID, SourceZoneID, 
	OwnerControl, GoodStateControl, PackingControl, 
	CellPalletTypeControl, CellWeightControl, CellHeightControl, CellMaxQntControl, 
	RestsControl, FullPalletControl, HalfStuffControl, 
	TargetZoneTypeID, TargetZoneID, Actual) 
	values ('Пикинг', 3, Null, Null, 
		0, 0, 1, 
		0, 0, 0, 1, 
		1, Null, Null, 
		7, Null, 1)
insert into AccommodationsRules (Name, Priority, SourceZoneTypeID, SourceZoneID, 
	OwnerControl, GoodStateControl, PackingControl, 
	CellPalletTypeControl, CellWeightControl, CellHeightControl, CellMaxQntControl, 
	RestsControl, FullPalletControl, HalfStuffControl, 
	TargetZoneTypeID, TargetZoneID, Actual) 
	values ('Высотка', 4, Null, Null, 
		0, 0, 0, 
		1, 1, 1, 1, 
		1, 0, 0, 
		6, Null, 1)
