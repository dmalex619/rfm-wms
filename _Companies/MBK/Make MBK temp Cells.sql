-- Cells on MBK depot
--if db_name() <> 'WMS' return

set nocount on

-- BarCodeLabels
insert into BarCodeLabels (Name, Type, Template, Data, 
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

-- StoresZones
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Приемка', 1, '', Null, 'IN', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Отгрузка', 2, '', Null, 'OUT', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Брак', 3, '', Null, 'DF', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('Виртуальная', 4, '', Null, 'LF', '', 1)

-- Cells
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (1, '', '', '', '', '1', 'IN.1', 100000, 0, 0, 0, 0, 1)
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (2, '', '', '', '', '1', 'OUT.1', 100000, 0, 0, 0, 0, 1)
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (3, '', '', '', '', '1', 'DF.1', 100000, 0, 0, 0, 0, 1)
insert into Cells (StoreZoneID, CBuilding, CLine, CRack, CLevel, CPlace, 
	Address, MaxWeight, CellWidth, CellHeight, GoodsMono, Locked, Actual)
	values (4, '', '', '', '', '1', 'LOST&FOUND', 100000, 0, 0, 0, 1, 1)



if object_id('__MBK_Storage') is not Null drop table __MBK_Storage
CREATE TABLE [dbo].[__MBK_Storage](
	[ERPCode] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[CLine] [varchar](50) NULL,
	[CRack] [varchar](50) NULL,
	[CLevel] [varchar](50) NULL,
	[CPlace] [varchar](50) NULL,
	[Rank] [varchar](50) NULL,
	[Height] [varchar](50) NULL,
	[Weight] [varchar](50) NULL,
	[PalType] [varchar](50) NULL,
	[NonActual] [varchar](50) NULL,
	[Locked] [varchar](50) NULL
) ON [PRIMARY]

exec master..xp_cmdshell 'bcp WMS_MBK.dbo.__MBK_Storage in \\DAlexandrov\E$\SuitableWMS\_SQL\Depots\MBK\MBK_Storage.txt -c -k -C1251 -T'


if object_id('__MBK_Picking') is not Null drop table __MBK_Picking
CREATE TABLE [dbo].[__MBK_Picking](
	[ERPCode] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[CLine] [varchar](50) NULL,
	[CRack] [varchar](50) NULL,
	[CLevel] [varchar](50) NULL,
	[CPlace] [varchar](50) NULL,
	[Rank] [varchar](50) NULL,
	[Height] [varchar](50) NULL,
	[Weight] [varchar](50) NULL,
	[PalType] [varchar](50) NULL,
	[NonActual] [varchar](50) NULL,
	[Locked] [varchar](50) NULL
) ON [PRIMARY]

exec master..xp_cmdshell 'bcp WMS_MBK.dbo.__MBK_Picking in \\DAlexandrov\E$\SuitableWMS\_SQL\Depots\MBK\MBK_Picking.txt -c -k -C1251 -T'



-- Высотка
declare @nStoreZoneID_STOR int
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, 
	NamePrefix, NameSuffix, Actual, ERPCode)
values ('Высотка', 6, '', 1, '', '', 1, Null)
select @nStoreZoneID_STOR = @@Identity

insert into Cells (StoreZoneID, PalletTypeID, 
	CBuilding, CLine, CRack, CLevel, CPlace, Address, 
	MaxWeight, CellWidth, CellHeight, MaxPalletQnt, 
	Rank, ERPCode) 
	select @nStoreZoneID_STOR, case when X.PalType = 'Евро' then 1 when X.PalType = 'Финн' then 2 else Null end, 
		'', X.CLine, right('0' + X.CRack, 2), X.CLevel, X.CPLace, 
		X.CLine + '.' + right('0' + X.CRack, 2) + '.' + X.CLevel + '.' + X.CPLace,
		X.Weight, case when X.PalType = 'Финн' then 1.0  else 0.8 end, cast(X.Height as dec) / 1000, 1, 
		X.Rank, X.ERPCode 
	from __MBK_Storage X 
	where len(ERPCode) > 4 
	order by X.CLine, cast(X.CRack as int), X.CLevel, X.CPLace

-- Буфер высотки и пикинга
declare @nStoreZoneID_STOR_BUF int
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, 
	NamePrefix, NameSuffix, Actual, ERPCode)
values ('Буфер высотки и пикинга', 5, '', 10, '', '.BUF', 1, Null)
select @nStoreZoneID_STOR_BUF = @@Identity

insert into Cells (StoreZoneID, PalletTypeID, 
	CBuilding, CLine, CRack, CLevel, CPlace, Address, 
	MaxWeight, CellWidth, CellHeight, MaxPalletQnt, 
	Rank, ERPCode) 
	select distinct @nStoreZoneID_STOR_BUF, Null, 
--		'', X.CLine, '', '', '', X.CLine + '.S.BUF', 
		'', X.CLine, '', '', '', X.CLine + '.BUF', 
		0, 0, 0, 10, 0, Null 
	from __MBK_Storage X 
	where len(ERPCode) > 4 
	order by X.CLine

-- Привязка буфера
update Cells set BufferCellID = X.ID 
	from (select ID, CLine from Cells where StoreZoneID = @nStoreZoneID_STOR_BUF) X 
	where Cells.StoreZoneID = @nStoreZoneID_STOR and Cells.CLIne = X.CLIne



-- Пикинг
declare @nStoreZoneID_PICK int
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, 
	NamePrefix, NameSuffix, Actual, ERPCode)
values ('Пикинг', 7, '', 1, '', '', 1, Null)
select @nStoreZoneID_PICK = @@Identity

insert into Cells (StoreZoneID, PalletTypeID, 
	CBuilding, CLine, CRack, CLevel, CPlace, Address, 
	MaxWeight, CellWidth, CellHeight, MaxPalletQnt, 
	Rank, ERPCode) 
	select @nStoreZoneID_PICK, Null, 
		'', case when X.CLine = 'Z1' then 'ZZ' else X.CLine end, 
		right('0' + X.CRack, 2), 
		X.CLevel, 
		right('0' + X.CPLace, 2), 
		case when X.CLine = 'Z1' then 'ZZ' else X.CLine end + '.' + 
			right('0' + X.CRack, 2) + '.' + X.CLevel + '.' + right('0' + X.CPLace, 2),
		0, 0, 0, 1, 
		0, X.ERPCode 
	from __MBK_Picking X 
	where len(ERPCode) > 4 
	order by X.CLine, cast(X.CRack as int), X.CLevel, right('0' + X.CPLace, 2)

-- Буфер пикинга
-- Равен буферу высотки
/*
declare @nStoreZoneID_PICK_BUF int
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, 
	NamePrefix, NameSuffix, Actual, ERPCode)
values ('Буфер пикинга', 5, '', 10, '', '.BUF', 1, Null)
select @nStoreZoneID_PICK_BUF = @@Identity

insert into Cells (StoreZoneID, PalletTypeID, 
	CBuilding, CLine, CRack, CLevel, CPlace, Address, 
	MaxWeight, CellWidth, CellHeight, MaxPalletQnt, 
	Rank, ERPCode) 
	select distinct @nStoreZoneID_PICK_BUF, Null, '', 
		case when X.CLine = 'Z1' then 'ZZ' else X.CLine end, '', '', '', 
		case when X.CLine = 'Z1' then 'ZZ' else X.CLine end + '.P.BUF', 
		0, 0, 0, 10, 0, Null 
	from __MBK_Picking X 
	where len(ERPCode) > 4 
	order by case when X.CLine = 'Z1' then 'ZZ' else X.CLine end

-- Привязка буфера
update Cells set BufferCellID = X.ID 
	from (select ID, CLine from Cells where StoreZoneID = @nStoreZoneID_PICK_BUF) X 
	where Cells.StoreZoneID = @nStoreZoneID_PICK and Cells.CLIne = X.CLIne
*/
update Cells set BufferCellID = X.ID 
	from (select ID, CLine from Cells where StoreZoneID = @nStoreZoneID_STOR_BUF) X 
	where Cells.StoreZoneID = @nStoreZoneID_PICK and Cells.CLIne = X.CLIne

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
		1, Null, Null, 
		6, Null, 1)
