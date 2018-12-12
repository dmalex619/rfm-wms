-- Процедура заливки некоторых стандартных справочников WMS
--if db_name() <> 'WMS' return

/*

ВНИМАНИЕ!
Для каждой локальной БД необходимо переопределить код склада
в вычисляемом поле Frames.BarCode!

*/

set nocount on

-- _Users
insert into _Users (Name, Password, IsAdmin, Actual) 
	values ('Администратор', 'admin', 1, 1)

-- _Roles
insert into _Roles (Name, AppRole, AppRolePassword, Actual, ERPCode) 
	values ('Начальник склада', NULL, NULL, 1, NULL)
insert into _Roles (Name, AppRole, AppRolePassword, Actual, ERPCode) 
	values ('Начальник смены', NULL, NULL, 1, NULL)
insert into _Roles (Name, AppRole, AppRolePassword, Actual, ERPCode) 
	values ('Оператор', NULL, NULL, 1, NULL)
insert into _Roles (Name, AppRole, AppRolePassword, Actual, ERPCode) 
	values ('Конфигуратор склада', NULL, NULL, 1, NULL)

-- _Settings
insert into _Settings (Name, Variable, Type, Value) 
	values ('Код партнера-владельца склада', 'gnWe', 'N', '1')
insert into _Settings (Name, Variable, Type, Value) 
--	values ('Название организации', 'WeName', 'C', 'ИНКО. Склад')
--	values ('Название организации', 'WeName', 'C', 'ШОК. Склад')
--	values ('Название организации', 'WeName', 'C', 'МБК. Склад')
	values ('Название организации', 'WeName', 'C', 'ХК №2. Склад')
insert into _Settings (Name, Variable, Type, Value) 
--	values ('Адрес организации', 'WeAddress', 'C', 'МО, Жуковский, ул.Наркомвод')
--	values ('Адрес организации', 'WeAddress', 'C', 'Белгородская обл., Шебекино')
--	values ('Адрес организации', 'WeAddress', 'C', 'Ленинградская обл., Всеволжск')
	values ('Адрес организации', 'WeAddress', 'C', 'Екатеринбург')
insert into _Settings (Name, Variable, Type, Value) 
	values ('Адрес виртуальной ячейки Lost&Found', 'sLostFoundAddress', 'C', 'LOST&FOUND')
insert into _Settings (Name, Variable, Type, Value) 
	values ('Режим работы мобильной части', 'cMobileState', 'C', 'P')
insert into _Settings (Name, Variable, Type, Value) 
	values ('Приход: Умолч. тип прихода', 'nDefInputTypeID', 'N', '1')
insert into _Settings (Name, Variable, Type, Value) 
	values ('Приход: Умолч. поставщик', 'nDefInputPartnerID', 'N', '1')
insert into _Settings (Name, Variable, Type, Value) 
	values ('Приход: Умолч. владелец', 'nDefInputOwnerID', 'N', '1')
insert into _Settings (Name, Variable, Type, Value) 
	values ('Приход: Умолч.состояние товара', 'nDefInputGoodStateID', 'N', '1')
insert into _Settings (Name, Variable, Type, Value) 
	values ('Маска адресов ячеек', 'cAddressMask', 'C', 'BL.RR.V.C')
insert into _Settings (Name, Variable, Type, Value) 
	values ('Разрешено подтверждение с авт.исправлением', 'bEasyConfirm', 'L', 'False')
insert into _Settings (Name, Variable, Type, Value) 
	values ('Автоматическая подпитка пикинга?', 'bAutoRecruiting', 'L', 'True')

/*
-- _Menus
truncate table _Menus
--set identity_insert _Menus on
--insert into _Menus (ID, ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (0, 'Внешние операции', 1, 1, '', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (0, 'Склад', 2, 1, '', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (0, 'Перемещения', 3, 1, '', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (0, 'Отчеты', 4, 1, '', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (0, 'Справочники', 5, 1, '', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (0, 'Права доступа', 6, 1, '', '', 1, 1)

insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (1, 'Приходы', 1, 1, 'frmInputs', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (1, 'Расходы', 2, 1, 'frmOutputs', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (1, 'Ревизии', 3, 1, 'frmInventories', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (1, 'Акты', 4, 1, 'frmAuditActs', '', 1, 0)

insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (2, 'Ячейки', 1, 1, 'frmCells', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (2, 'Остатки', 2, 1, 'frmOddments', '', 1, 0)

insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (3, 'Операции перемещения контейнеров', 1, 1, 'frmTrafficsFrames', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (3, 'Операции перемещения коробок/штук', 2, 1, 'frmTrafficsGoods', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (3, 'Контейнеры и их текущее расположение', 3, 1, 'frmFrames', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (3, 'Внутрискладские перемещения', 4, 1, 'frmMovings', '', 1, 0)

insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (4, 'Информация о штрих-коде', 1, 1, 'frmReportsBarCode', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (4, 'Операции с ячейками/контейнерами', 2, 1, 'frmReportCellsFramesHistory', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (4, 'Транспортировки и перемещения', 3, 1, 'frmReportTraffics', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (4, 'Остатки и операции за период', 4, 1, 'frmReportOddmentsBalance', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (4, 'Сроки годности в приходах', 5, 1, 'frmReportInputsDateValid', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (4, 'Отчет по операциям (для з/п)', 6, 1, 'frmReportForSalary', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (4, 'Товары/упаковки', 7, 1, 'frmSelectOnePacking', '', 1, 0)

insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (5, 'Таблицы', 1, 1, 'frmSysLook', '', 1, 1)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (5, 'Пользователи', 2, 1, 'frmUsers', '', 1, 0)

insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (6, 'Права на главное меню', 1, 1, 'frmAccessMenu', '', 1, 1)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (6, 'Права на элементы форм', 2, 1, 'frmAccessControls', '', 1, 1)
--set identity_insert _Menus off
*/

-- _MobileMenus
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('Приемка', 'Приемка ожидаемого прихода', 'Input', '', 0, 1)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('Возврат', 'Возврат по отгрузке', 'Return', '', 0, 0)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('Перемещ. штабелером', 'Перемещение поддона штабелером', 'TrafficFrameHigh', '', 0, 1)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('Перемещ. тележкой', 'Перемещение поддона тележкой', 'TrafficFrameGround', '', 0, 1)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('Перемещ. по факту', 'Перемещение поддона по факту', 'TrafficFrameFact', '', 0, 1)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('Сборка поддона', 'Сборка нового поддона из коробок', 'AssemblyPallet', '', 0, 1)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('Подпитка пикинга', 'Ручная подпитка пикинга', 'FillPickingManual', '', 0, 1)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('Ревизия', 'Ревизия ячеек склада', 'Inventory', '', 0, 1)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('Информация о Ш/К', 'Информация о штрих-коде', 'BarCodeInfo', '', 0, 1)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('Старые паллеты', 'Штрих-кодирование старых паллет', 'OldCellsContents', '', 0, 0)

/*
-- GoodsStates
insert into GoodsStates (Name, Note, Basic, Actual, ERPCode)
	values ('_Годен', 'Товар пригоден для осуществления основной деятельности', 1, 1, '1')
insert into GoodsStates (Name, Note, Basic, Actual, ERPCode)
	values ('Брак', 'Бракованный товар', 0, 1, '2')

-- InputsTypes
insert into InputsTypes (Name, OwnerID, GoodStateID, Actual)
	values ('_Основной приход', Null, 1, 1)
insert into InputsTypes (Name, OwnerID, GoodStateID, Actual)
	values ('Возврат', Null, Null, 1)

-- OutputsTypes
insert into OutputsTypes (Name, OwnerID, GoodStateID, Actual)
	values ('_Основной расход', Null, 1, 1)
insert into OutputsTypes (Name, OwnerID, GoodStateID, Actual)
	values ('Списание', Null, Null, 1)

-- MovingsTypes
insert into MovingsTypes (Name, GoodStateID, Actual)
	values ('Ручное', Null, 1)
insert into MovingsTypes (Name, GoodStateID, Actual)
	values ('Подпитка пикинга', 1, 1)
*/

-- StoresZonesTypes
insert into StoresZonesTypes (Name, ShortCode, 
	ForFrames, ForStorage, ForPicking, ForInputs, ForOutputs, 
	GoodsMono, Special, AddressMask, Actual)
	values ('Приход', 'IN', Null, 0, 0, 1, 0, 0, 0, 'BL.RR.V.C', 1)
insert into StoresZonesTypes (Name, ShortCode, 
	ForFrames, ForStorage, ForPicking, ForInputs, ForOutputs, 
	GoodsMono, Special, AddressMask, Actual)
	values ('Отгрузка', 'OUT', 0, 0, 0, 0, 1, 0, 0, 'BL.RR.V.C', 1)
insert into StoresZonesTypes (Name, ShortCode, 
	ForFrames, ForStorage, ForPicking, ForInputs, ForOutputs, 
	GoodsMono, Special, AddressMask, Actual)
	values ('Брак', 'DFCT', 0, 0, 0, 1, 0, 0, 0, 'BL.RR.V.C', 1)
insert into StoresZonesTypes (Name, ShortCode, 
	ForFrames, ForStorage, ForPicking, ForInputs, ForOutputs, 
	GoodsMono, Special, AddressMask, Actual)
	values ('Виртуальная', 'LOST&FOUND', Null, 0, 0, 0, 0, 0, 1, 'BL.RR.V.C', 1)
insert into StoresZonesTypes (Name, ShortCode, 
	ForFrames, ForStorage, ForPicking, ForInputs, ForOutputs, 
	GoodsMono, Special, AddressMask, Actual)
	values ('Буфер', 'BUF', 1, 0, 0, 0, 0, 0, 0, 'BL.RR.V.C', 1)
insert into StoresZonesTypes (Name, ShortCode, 
	ForFrames, ForStorage, ForPicking, ForInputs, ForOutputs, 
	GoodsMono, Special, AddressMask, Actual)
	values ('Хранение', 'STOR', 1, 1, 0, 0, 0, 1, 0, 'BL.RR.V.C', 1)
insert into StoresZonesTypes (Name, ShortCode, 
	ForFrames, ForStorage, ForPicking, ForInputs, ForOutputs, 
	GoodsMono, Special, AddressMask, Actual)
	values ('Пикинг', 'PICK', 0, 1, 1, 0, 0, 1, 0, 'BL.RR.V.C', 1)
insert into StoresZonesTypes (Name, ShortCode, 
	ForFrames, ForStorage, ForPicking, ForInputs, ForOutputs, 
	GoodsMono, Special, AddressMask, Actual)
	values ('Ручей', 'RILL', 1, 1, 0, 0, 0, 1, 0, 'BL.RR.V.C', 0)

/*
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
*/

-- TrafficsFramesErrors
/*insert into TrafficsFramesErrors (Name, Severity, LockCell)
	values ('_В ПИКИНГ/НА ОТГРУЗКУ', -1, 0)*/
insert into TrafficsFramesErrors (Name, Severity, LockFrame, LockCellSource, LockCellTarget)
	values ('Контейнер непригоден', 5, 1, 0, 0)
insert into TrafficsFramesErrors (Name, Severity, LockFrame, LockCellSource, LockCellTarget)
	values ('Исходная ячейка пуста/непригодна', 5, 0, 1, 0)
insert into TrafficsFramesErrors (Name, Severity, LockFrame, LockCellSource, LockCellTarget)
	values ('Целевая ячейка эанята/непригодна', 5, 0, 0, 1)

-- TrafficsGoodsErrors
insert into TrafficsGoodsErrors (Name, Severity)
	values ('_Прочие ошибки', 9)
/*insert into TrafficsGoodsErrors (Name, Severity)
	values ('Ячейка непригодна', 3)*/

-- PalletsTypes
insert into PalletsTypes (Name, PalletWidth, PalletLength, PalletHeight, PalletWeight, Actual)
	values ('EUR - Евро поддон', 0.8, 1.2, 0.15, 20, 1)
insert into PalletsTypes (Name, PalletWidth, PalletLength, PalletHeight, PalletWeight, Actual)
	values ('FIN - Финский поддон', 1.0, 1.2, 0.15, 25, 1)

-- Tares
insert into Tares (Name, TareWidth, TareLength, TareHeight, TareWeight, Actual)
	values ('EUR - Евро поддон', 0.8, 1.2, 0.15, 20, 1)
insert into Tares (Name, TareWidth, TareLength, TareHeight, TareWeight, Actual)
	values ('FIN - Финский поддон', 1.0, 1.2, 0.15, 25, 1)

-- DevicesTypes
insert into DevicesTypes (Name, Actual)
	values ('Symbol MC9090G Mobile PC', 1)

-- InventoriesErrors
/*insert into InventoriesErrors (Name) values ('_Прочие ошибки')
insert into InventoriesErrors (Name) values ('Несовпадение количества')
insert into InventoriesErrors (Name) values ('Несовпадение номенклатуры')
insert into InventoriesErrors (Name) values ('Несовпадение срока годности')
insert into InventoriesErrors (Name) values ('Ячейка НЕ пуста')
insert into InventoriesErrors (Name) values ('Ячейка пуста')*/

-- Devices
/*insert into Devices (Name, DeviceTypeID, DeviceGuid, MACAddress, Available, Actual)
	values ('MS Device Emulator', 1, '00740061-006f-0072-0000-000000000000', '', 1, 1)
insert into Devices (Name, DeviceTypeID, DeviceGuid, MACAddress, Available, Actual)
	values ('MC9090G', 1, '6f6d661d-442e-e15a-5800-0050bf7a60e2', '', 1, 1)*/

-- AccommodationsSortings
/*insert into AccommodationsSortings (Name, SortingRule) 
	values ('Близость к пикингу', 'NearestPicking')
insert into AccommodationsSortings (Name, SortingRule) 
	values ('Адрес', '')
insert into AccommodationsSortings (Name, SortingRule) 
	values ('Масса', 'MaxWeight, CellHeight')*/

/*
-- AccommodationsRules
insert into AccommodationsRules (Name, Priority, SourceZoneTypeID, SourceZoneID, 
	OwnerControl, GoodStateControl, PackingControl, 
	CellPalletTypeControl, CellWeightControl, CellHeightControl, CellMaxQntControl, 
	RestsControl, FullPalletControl, HalfStuffControl, 
	AccommodationSortingID, TargetZoneTypeID, TargetZoneID, Actual) 
	values ('Весь брак', 1, 1, Null, 
		0, 1, 0, 
		0, 0, 0, 0, 
		0, Null, Null, 
		2, Null, 3, 1)
insert into AccommodationsRules (Name, Priority, SourceZoneTypeID, SourceZoneID, 
	OwnerControl, GoodStateControl, PackingControl, 
	CellPalletTypeControl, CellWeightControl, CellHeightControl, CellMaxQntControl, 
	RestsControl, FullPalletControl, HalfStuffControl, 
	AccommodationSortingID, TargetZoneTypeID, TargetZoneID, Actual) 
	values ('Все хранители, годный товар (пикинг)', 8, 1, Null, 
		0, 0, 1, 
		0, 0, 0, 1, 
		1, Null, Null, 
		2, 7, Null, 1)
insert into AccommodationsRules (Name, Priority, SourceZoneTypeID, SourceZoneID, 
	OwnerControl, GoodStateControl, PackingControl, 
	CellPalletTypeControl, CellWeightControl, CellHeightControl, CellMaxQntControl, 
	RestsControl, FullPalletControl, HalfStuffControl, 
	AccommodationSortingID, TargetZoneTypeID, TargetZoneID, Actual) 
	values ('Все хранители, годный товар (высотка)', 9, 1, Null, 
		0, 0, 0, 
		1, 1, 1, 1, 
		0, Null, Null, 
		1, 6, Null, 1)
insert into AccommodationsRules (Name, Priority, SourceZoneTypeID, SourceZoneID, 
	OwnerControl, GoodStateControl, PackingControl, 
	CellPalletTypeControl, CellWeightControl, CellHeightControl, CellMaxQntControl, 
	RestsControl, FullPalletControl, HalfStuffControl, 
	AccommodationSortingID, TargetZoneTypeID, TargetZoneID, Actual) 
	values ('Товар в ручей (целые паллеты)', 5, 1, Null, 
		0, 0, 0, 
		1, 1, 1, 1, 
		0, Null, Null, 
		2, 8, Null, 1)
*/

-- BarCodeLabels
/*insert into BarCodeLabels (Name, Type, Template, Data, 
	Copies, InvertLabel, NormalOrientationTemplate, InvertOrientationTemplate, Actual)
	values ('Ячейка 55х40', 'CL', 
		'^XA^DFR:Cell.zpl^FS^FO0,10^AUN,18,10^FN1^FS^FO0,100^BY2^BCN,100,N,N,N,N^FN2^FS^XZ', 
		'^XA^PO##InvertLabel##^PQ##Copies##^XFR:Cell.zpl^FN1^FD#Address#^FS^FN2^FD#BarCode#^FS^XZ', 
		1, 0, 'N', 'I', 1)*/

--insert into BarCodeLabels (Name, Type, Template, Data, 
--	Copies, InvertLabel, NormalOrientationTemplate, InvertOrientationTemplate, Actual)
--	values ('Ячейка 100х74', 'CL', 
--		'^XA^DFR:Cell.zpl^FS^FO50,10^AUN,270,150^FN1^FS^FO50,300^BY4^BCN,200,N,N,N,N^FN2^FS^XZ', 
--		'^XA^PO##InvertLabel##^PQ##Copies##^XFR:Cell.zpl^FN1^FD#Address#^FS^FN2^FD#BarCode#^FS^^XZ', 
--		1, 0, 'N', 'I', 1)

/*insert into BarCodeLabels (Name, Type, Template, Data, 
	Copies, InvertLabel, NormalOrientationTemplate, InvertOrientationTemplate, Actual)
	values ('Ячейка 100х74 верт.', 'CL', 
		'^XA^DFR:Cell.zpl^FS^FO600,50^AUR,180,100^FN1^FS^FO300,50^BY2^BCR,200,N,N,N,N^FN2^FS^FO100,50^AUR,90,50^FN3^FS^XZ', 
		'^XA^PO##InvertLabel##^PQ##Copies##^XFR:Cell.zpl^FN1^FD#Address#^FS^FN2^FD#BarCode#^FS^FN3^FDZoneType: #StoreZoneTypeShortCode#^FS^XZ', 
		1, 0, 'N', 'I', 1)*/
/*insert into BarCodeLabels (Name, Type, Template, Data, 
	Copies, InvertLabel, NormalOrientationTemplate, InvertOrientationTemplate, Actual)
	values ('Контейнер 55х40', 'FR', 
		'^XA^DFR:Frame.zpl^FS^FO0,10^AUN,18,10^FN1^FS^FO0,100^BY2^BCN,100,N,N,N,N^FN1^FS^XZ', 
		'^XA^PO##InvertLabel##^PQ##Copies##^XFR:Frame.zpl^FN1^FD#BarCode#^FS^XZ', 
		3, 1, 'N', 'I', 1)*/
--insert into BarCodeLabels (Name, Type, Template, Data, 
--	Copies, InvertLabel, NormalOrientationTemplate, InvertOrientationTemplate, Actual)
--	values ('Контейнер 100х74', 'FR', 
--		'^XA^DFR:Frame.zpl^FS^FO50,50^AVN,90,50^FN1^FS^FO50,200^BY3^BCN,200,N,N,N,N^FN2^FS^FO50,500^ATN,18,10^FN3^FS^XZ', 
--		'^XA^PO##InvertLabel##^PQ##Copies##^XFR:Frame.zpl^FN1^FD#BarCode#^FS^FN2^FD#BarCode#^FS^FN3^FDDateBirth: #DateBirth#^FS^XZ', 
--		2, 1, 'N', 'I', 1)
