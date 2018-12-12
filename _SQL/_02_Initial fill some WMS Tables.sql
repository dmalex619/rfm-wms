-- ��������� ������� ��������� ����������� ������������ WMS
--if db_name() <> 'WMS' return

/*

��������!
��� ������ ��������� �� ���������� �������������� ��� ������
� ����������� ���� Frames.BarCode!

*/

set nocount on

-- _Users
insert into _Users (Name, Password, IsAdmin, Actual) 
	values ('�������������', 'admin', 1, 1)

-- _Roles
insert into _Roles (Name, AppRole, AppRolePassword, Actual, ERPCode) 
	values ('��������� ������', NULL, NULL, 1, NULL)
insert into _Roles (Name, AppRole, AppRolePassword, Actual, ERPCode) 
	values ('��������� �����', NULL, NULL, 1, NULL)
insert into _Roles (Name, AppRole, AppRolePassword, Actual, ERPCode) 
	values ('��������', NULL, NULL, 1, NULL)
insert into _Roles (Name, AppRole, AppRolePassword, Actual, ERPCode) 
	values ('������������ ������', NULL, NULL, 1, NULL)

-- _Settings
insert into _Settings (Name, Variable, Type, Value) 
	values ('��� ��������-��������� ������', 'gnWe', 'N', '1')
insert into _Settings (Name, Variable, Type, Value) 
--	values ('�������� �����������', 'WeName', 'C', '����. �����')
--	values ('�������� �����������', 'WeName', 'C', '���. �����')
--	values ('�������� �����������', 'WeName', 'C', '���. �����')
	values ('�������� �����������', 'WeName', 'C', '�� �2. �����')
insert into _Settings (Name, Variable, Type, Value) 
--	values ('����� �����������', 'WeAddress', 'C', '��, ���������, ��.���������')
--	values ('����� �����������', 'WeAddress', 'C', '������������ ���., ��������')
--	values ('����� �����������', 'WeAddress', 'C', '������������� ���., ���������')
	values ('����� �����������', 'WeAddress', 'C', '������������')
insert into _Settings (Name, Variable, Type, Value) 
	values ('����� ����������� ������ Lost&Found', 'sLostFoundAddress', 'C', 'LOST&FOUND')
insert into _Settings (Name, Variable, Type, Value) 
	values ('����� ������ ��������� �����', 'cMobileState', 'C', 'P')
insert into _Settings (Name, Variable, Type, Value) 
	values ('������: �����. ��� �������', 'nDefInputTypeID', 'N', '1')
insert into _Settings (Name, Variable, Type, Value) 
	values ('������: �����. ���������', 'nDefInputPartnerID', 'N', '1')
insert into _Settings (Name, Variable, Type, Value) 
	values ('������: �����. ��������', 'nDefInputOwnerID', 'N', '1')
insert into _Settings (Name, Variable, Type, Value) 
	values ('������: �����.��������� ������', 'nDefInputGoodStateID', 'N', '1')
insert into _Settings (Name, Variable, Type, Value) 
	values ('����� ������� �����', 'cAddressMask', 'C', 'BL.RR.V.C')
insert into _Settings (Name, Variable, Type, Value) 
	values ('��������� ������������� � ���.������������', 'bEasyConfirm', 'L', 'False')
insert into _Settings (Name, Variable, Type, Value) 
	values ('�������������� �������� �������?', 'bAutoRecruiting', 'L', 'True')

/*
-- _Menus
truncate table _Menus
--set identity_insert _Menus on
--insert into _Menus (ID, ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (0, '������� ��������', 1, 1, '', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (0, '�����', 2, 1, '', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (0, '�����������', 3, 1, '', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (0, '������', 4, 1, '', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (0, '�����������', 5, 1, '', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (0, '����� �������', 6, 1, '', '', 1, 1)

insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (1, '�������', 1, 1, 'frmInputs', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (1, '�������', 2, 1, 'frmOutputs', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (1, '�������', 3, 1, 'frmInventories', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (1, '����', 4, 1, 'frmAuditActs', '', 1, 0)

insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (2, '������', 1, 1, 'frmCells', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (2, '�������', 2, 1, 'frmOddments', '', 1, 0)

insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (3, '�������� ����������� �����������', 1, 1, 'frmTrafficsFrames', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (3, '�������� ����������� �������/����', 2, 1, 'frmTrafficsGoods', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (3, '���������� � �� ������� ������������', 3, 1, 'frmFrames', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (3, '��������������� �����������', 4, 1, 'frmMovings', '', 1, 0)

insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (4, '���������� � �����-����', 1, 1, 'frmReportsBarCode', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (4, '�������� � ��������/������������', 2, 1, 'frmReportCellsFramesHistory', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (4, '��������������� � �����������', 3, 1, 'frmReportTraffics', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (4, '������� � �������� �� ������', 4, 1, 'frmReportOddmentsBalance', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (4, '����� �������� � ��������', 5, 1, 'frmReportInputsDateValid', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (4, '����� �� ��������� (��� �/�)', 6, 1, 'frmReportForSalary', '', 1, 0)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (4, '������/��������', 7, 1, 'frmSelectOnePacking', '', 1, 0)

insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (5, '�������', 1, 1, 'frmSysLook', '', 1, 1)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (5, '������������', 2, 1, 'frmUsers', '', 1, 0)

insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (6, '����� �� ������� ����', 1, 1, 'frmAccessMenu', '', 1, 1)
insert into _Menus (ParentID, ItemText, ByOrder, Actual, CmdName, CmdParam, IsForm, IsAccessOn) 
	values (6, '����� �� �������� ����', 2, 1, 'frmAccessControls', '', 1, 1)
--set identity_insert _Menus off
*/

-- _MobileMenus
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('�������', '������� ���������� �������', 'Input', '', 0, 1)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('�������', '������� �� ��������', 'Return', '', 0, 0)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('�������. ����������', '����������� ������� ����������', 'TrafficFrameHigh', '', 0, 1)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('�������. ��������', '����������� ������� ��������', 'TrafficFrameGround', '', 0, 1)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('�������. �� �����', '����������� ������� �� �����', 'TrafficFrameFact', '', 0, 1)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('������ �������', '������ ������ ������� �� �������', 'AssemblyPallet', '', 0, 1)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('�������� �������', '������ �������� �������', 'FillPickingManual', '', 0, 1)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('�������', '������� ����� ������', 'Inventory', '', 0, 1)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('���������� � �/�', '���������� � �����-����', 'BarCodeInfo', '', 0, 1)
insert into _MobileMenus (Alias, Name, Tag, State, SortOrder, Actual) 
	values ('������ �������', '�����-����������� ������ ������', 'OldCellsContents', '', 0, 0)

/*
-- GoodsStates
insert into GoodsStates (Name, Note, Basic, Actual, ERPCode)
	values ('_�����', '����� �������� ��� ������������� �������� ������������', 1, 1, '1')
insert into GoodsStates (Name, Note, Basic, Actual, ERPCode)
	values ('����', '����������� �����', 0, 1, '2')

-- InputsTypes
insert into InputsTypes (Name, OwnerID, GoodStateID, Actual)
	values ('_�������� ������', Null, 1, 1)
insert into InputsTypes (Name, OwnerID, GoodStateID, Actual)
	values ('�������', Null, Null, 1)

-- OutputsTypes
insert into OutputsTypes (Name, OwnerID, GoodStateID, Actual)
	values ('_�������� ������', Null, 1, 1)
insert into OutputsTypes (Name, OwnerID, GoodStateID, Actual)
	values ('��������', Null, Null, 1)

-- MovingsTypes
insert into MovingsTypes (Name, GoodStateID, Actual)
	values ('������', Null, 1)
insert into MovingsTypes (Name, GoodStateID, Actual)
	values ('�������� �������', 1, 1)
*/

-- StoresZonesTypes
insert into StoresZonesTypes (Name, ShortCode, 
	ForFrames, ForStorage, ForPicking, ForInputs, ForOutputs, 
	GoodsMono, Special, AddressMask, Actual)
	values ('������', 'IN', Null, 0, 0, 1, 0, 0, 0, 'BL.RR.V.C', 1)
insert into StoresZonesTypes (Name, ShortCode, 
	ForFrames, ForStorage, ForPicking, ForInputs, ForOutputs, 
	GoodsMono, Special, AddressMask, Actual)
	values ('��������', 'OUT', 0, 0, 0, 0, 1, 0, 0, 'BL.RR.V.C', 1)
insert into StoresZonesTypes (Name, ShortCode, 
	ForFrames, ForStorage, ForPicking, ForInputs, ForOutputs, 
	GoodsMono, Special, AddressMask, Actual)
	values ('����', 'DFCT', 0, 0, 0, 1, 0, 0, 0, 'BL.RR.V.C', 1)
insert into StoresZonesTypes (Name, ShortCode, 
	ForFrames, ForStorage, ForPicking, ForInputs, ForOutputs, 
	GoodsMono, Special, AddressMask, Actual)
	values ('�����������', 'LOST&FOUND', Null, 0, 0, 0, 0, 0, 1, 'BL.RR.V.C', 1)
insert into StoresZonesTypes (Name, ShortCode, 
	ForFrames, ForStorage, ForPicking, ForInputs, ForOutputs, 
	GoodsMono, Special, AddressMask, Actual)
	values ('�����', 'BUF', 1, 0, 0, 0, 0, 0, 0, 'BL.RR.V.C', 1)
insert into StoresZonesTypes (Name, ShortCode, 
	ForFrames, ForStorage, ForPicking, ForInputs, ForOutputs, 
	GoodsMono, Special, AddressMask, Actual)
	values ('��������', 'STOR', 1, 1, 0, 0, 0, 1, 0, 'BL.RR.V.C', 1)
insert into StoresZonesTypes (Name, ShortCode, 
	ForFrames, ForStorage, ForPicking, ForInputs, ForOutputs, 
	GoodsMono, Special, AddressMask, Actual)
	values ('������', 'PICK', 0, 1, 1, 0, 0, 1, 0, 'BL.RR.V.C', 1)
insert into StoresZonesTypes (Name, ShortCode, 
	ForFrames, ForStorage, ForPicking, ForInputs, ForOutputs, 
	GoodsMono, Special, AddressMask, Actual)
	values ('�����', 'RILL', 1, 1, 0, 0, 0, 1, 0, 'BL.RR.V.C', 0)

/*
-- StoresZones
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('�������', 1, '', Null, 'IN', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('��������', 2, '', Null, 'OUT', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('����', 3, '', Null, 'DF', '', 1)
insert into StoresZones (Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, Actual) 
	values ('�����������', 4, '', Null, 'LF', '', 1)

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
	values ('_� ������/�� ��������', -1, 0)*/
insert into TrafficsFramesErrors (Name, Severity, LockFrame, LockCellSource, LockCellTarget)
	values ('��������� ����������', 5, 1, 0, 0)
insert into TrafficsFramesErrors (Name, Severity, LockFrame, LockCellSource, LockCellTarget)
	values ('�������� ������ �����/����������', 5, 0, 1, 0)
insert into TrafficsFramesErrors (Name, Severity, LockFrame, LockCellSource, LockCellTarget)
	values ('������� ������ ������/����������', 5, 0, 0, 1)

-- TrafficsGoodsErrors
insert into TrafficsGoodsErrors (Name, Severity)
	values ('_������ ������', 9)
/*insert into TrafficsGoodsErrors (Name, Severity)
	values ('������ ����������', 3)*/

-- PalletsTypes
insert into PalletsTypes (Name, PalletWidth, PalletLength, PalletHeight, PalletWeight, Actual)
	values ('EUR - ���� ������', 0.8, 1.2, 0.15, 20, 1)
insert into PalletsTypes (Name, PalletWidth, PalletLength, PalletHeight, PalletWeight, Actual)
	values ('FIN - ������� ������', 1.0, 1.2, 0.15, 25, 1)

-- Tares
insert into Tares (Name, TareWidth, TareLength, TareHeight, TareWeight, Actual)
	values ('EUR - ���� ������', 0.8, 1.2, 0.15, 20, 1)
insert into Tares (Name, TareWidth, TareLength, TareHeight, TareWeight, Actual)
	values ('FIN - ������� ������', 1.0, 1.2, 0.15, 25, 1)

-- DevicesTypes
insert into DevicesTypes (Name, Actual)
	values ('Symbol MC9090G Mobile PC', 1)

-- InventoriesErrors
/*insert into InventoriesErrors (Name) values ('_������ ������')
insert into InventoriesErrors (Name) values ('������������ ����������')
insert into InventoriesErrors (Name) values ('������������ ������������')
insert into InventoriesErrors (Name) values ('������������ ����� ��������')
insert into InventoriesErrors (Name) values ('������ �� �����')
insert into InventoriesErrors (Name) values ('������ �����')*/

-- Devices
/*insert into Devices (Name, DeviceTypeID, DeviceGuid, MACAddress, Available, Actual)
	values ('MS Device Emulator', 1, '00740061-006f-0072-0000-000000000000', '', 1, 1)
insert into Devices (Name, DeviceTypeID, DeviceGuid, MACAddress, Available, Actual)
	values ('MC9090G', 1, '6f6d661d-442e-e15a-5800-0050bf7a60e2', '', 1, 1)*/

-- AccommodationsSortings
/*insert into AccommodationsSortings (Name, SortingRule) 
	values ('�������� � �������', 'NearestPicking')
insert into AccommodationsSortings (Name, SortingRule) 
	values ('�����', '')
insert into AccommodationsSortings (Name, SortingRule) 
	values ('�����', 'MaxWeight, CellHeight')*/

/*
-- AccommodationsRules
insert into AccommodationsRules (Name, Priority, SourceZoneTypeID, SourceZoneID, 
	OwnerControl, GoodStateControl, PackingControl, 
	CellPalletTypeControl, CellWeightControl, CellHeightControl, CellMaxQntControl, 
	RestsControl, FullPalletControl, HalfStuffControl, 
	AccommodationSortingID, TargetZoneTypeID, TargetZoneID, Actual) 
	values ('���� ����', 1, 1, Null, 
		0, 1, 0, 
		0, 0, 0, 0, 
		0, Null, Null, 
		2, Null, 3, 1)
insert into AccommodationsRules (Name, Priority, SourceZoneTypeID, SourceZoneID, 
	OwnerControl, GoodStateControl, PackingControl, 
	CellPalletTypeControl, CellWeightControl, CellHeightControl, CellMaxQntControl, 
	RestsControl, FullPalletControl, HalfStuffControl, 
	AccommodationSortingID, TargetZoneTypeID, TargetZoneID, Actual) 
	values ('��� ���������, ������ ����� (������)', 8, 1, Null, 
		0, 0, 1, 
		0, 0, 0, 1, 
		1, Null, Null, 
		2, 7, Null, 1)
insert into AccommodationsRules (Name, Priority, SourceZoneTypeID, SourceZoneID, 
	OwnerControl, GoodStateControl, PackingControl, 
	CellPalletTypeControl, CellWeightControl, CellHeightControl, CellMaxQntControl, 
	RestsControl, FullPalletControl, HalfStuffControl, 
	AccommodationSortingID, TargetZoneTypeID, TargetZoneID, Actual) 
	values ('��� ���������, ������ ����� (�������)', 9, 1, Null, 
		0, 0, 0, 
		1, 1, 1, 1, 
		0, Null, Null, 
		1, 6, Null, 1)
insert into AccommodationsRules (Name, Priority, SourceZoneTypeID, SourceZoneID, 
	OwnerControl, GoodStateControl, PackingControl, 
	CellPalletTypeControl, CellWeightControl, CellHeightControl, CellMaxQntControl, 
	RestsControl, FullPalletControl, HalfStuffControl, 
	AccommodationSortingID, TargetZoneTypeID, TargetZoneID, Actual) 
	values ('����� � ����� (����� �������)', 5, 1, Null, 
		0, 0, 0, 
		1, 1, 1, 1, 
		0, Null, Null, 
		2, 8, Null, 1)
*/

-- BarCodeLabels
/*insert into BarCodeLabels (Name, Type, Template, Data, 
	Copies, InvertLabel, NormalOrientationTemplate, InvertOrientationTemplate, Actual)
	values ('������ 55�40', 'CL', 
		'^XA^DFR:Cell.zpl^FS^FO0,10^AUN,18,10^FN1^FS^FO0,100^BY2^BCN,100,N,N,N,N^FN2^FS^XZ', 
		'^XA^PO##InvertLabel##^PQ##Copies##^XFR:Cell.zpl^FN1^FD#Address#^FS^FN2^FD#BarCode#^FS^XZ', 
		1, 0, 'N', 'I', 1)*/

--insert into BarCodeLabels (Name, Type, Template, Data, 
--	Copies, InvertLabel, NormalOrientationTemplate, InvertOrientationTemplate, Actual)
--	values ('������ 100�74', 'CL', 
--		'^XA^DFR:Cell.zpl^FS^FO50,10^AUN,270,150^FN1^FS^FO50,300^BY4^BCN,200,N,N,N,N^FN2^FS^XZ', 
--		'^XA^PO##InvertLabel##^PQ##Copies##^XFR:Cell.zpl^FN1^FD#Address#^FS^FN2^FD#BarCode#^FS^^XZ', 
--		1, 0, 'N', 'I', 1)

/*insert into BarCodeLabels (Name, Type, Template, Data, 
	Copies, InvertLabel, NormalOrientationTemplate, InvertOrientationTemplate, Actual)
	values ('������ 100�74 ����.', 'CL', 
		'^XA^DFR:Cell.zpl^FS^FO600,50^AUR,180,100^FN1^FS^FO300,50^BY2^BCR,200,N,N,N,N^FN2^FS^FO100,50^AUR,90,50^FN3^FS^XZ', 
		'^XA^PO##InvertLabel##^PQ##Copies##^XFR:Cell.zpl^FN1^FD#Address#^FS^FN2^FD#BarCode#^FS^FN3^FDZoneType: #StoreZoneTypeShortCode#^FS^XZ', 
		1, 0, 'N', 'I', 1)*/
/*insert into BarCodeLabels (Name, Type, Template, Data, 
	Copies, InvertLabel, NormalOrientationTemplate, InvertOrientationTemplate, Actual)
	values ('��������� 55�40', 'FR', 
		'^XA^DFR:Frame.zpl^FS^FO0,10^AUN,18,10^FN1^FS^FO0,100^BY2^BCN,100,N,N,N,N^FN1^FS^XZ', 
		'^XA^PO##InvertLabel##^PQ##Copies##^XFR:Frame.zpl^FN1^FD#BarCode#^FS^XZ', 
		3, 1, 'N', 'I', 1)*/
--insert into BarCodeLabels (Name, Type, Template, Data, 
--	Copies, InvertLabel, NormalOrientationTemplate, InvertOrientationTemplate, Actual)
--	values ('��������� 100�74', 'FR', 
--		'^XA^DFR:Frame.zpl^FS^FO50,50^AVN,90,50^FN1^FS^FO50,200^BY3^BCN,200,N,N,N,N^FN2^FS^FO50,500^ATN,18,10^FN3^FS^XZ', 
--		'^XA^PO##InvertLabel##^PQ##Copies##^XFR:Frame.zpl^FN1^FD#BarCode#^FS^FN2^FD#BarCode#^FS^FN3^FDDateBirth: #DateBirth#^FS^XZ', 
--		2, 1, 'N', 'I', 1)
