-- Процедура обнуления данных в БД WMS
--if db_name() <> 'WMS' return

-- Запомнить все внешние ключи
if object_id('__ForeignKeys') is not Null drop table __ForeignKeys
select Object_Name(ConstID) as KeyName, 
	Object_Name(FKeyID) as FTable, Object_Name(RKeyID) as RTable, 
	C1.Name as FColumn, C2.Name as RColumn 
	into __ForeignKeys 
	from SysForeignKeys SF 
	inner join (select Name, ID, ColID from SysColumns) C1 
		on C1.ID = FKeyID and C1.ColID = SF.FKey 
	inner join (select Name, ID, ColID from SysColumns) C2 
		on C2.ID = RKeyID and C2.ColID = SF.RKey 
	order by 1

declare @DropScript varchar(max), @AddScript varchar(max)
select @DropScript = '', @AddScript = ''
--SELECT * into _ASD from __ForeignKeys
-- Скрипт на удаление связей
select @DropScript = @DropScript + 
	'if exists (select * from dbo.sysobjects where id = object_id(N''[dbo].[' + KeyName + 
	']'') and OBJECTPROPERTY(id, N''IsForeignKey'') = 1) ' + 
	'ALTER TABLE [dbo].[' + FTable + '] DROP CONSTRAINT ' + KeyName + '; '
	from __ForeignKeys

-- Скрипт на добавление связей
select @AddScript = @AddScript + 
	'ALTER TABLE [dbo].[' + FTable + '] ADD CONSTRAINT [' + KeyName + '] ' + 
	'FOREIGN KEY ([' + FColumn + ']) REFERENCES [dbo].[' + RTable + '] ([' + RColumn + ']); '
	from __ForeignKeys

-- Удаление связей
exec (@DropScript)

-- Обнуление данных
truncate table _Forms
truncate table _Grids
truncate table _MobileFiles
truncate table _MobileMenus
truncate table _OldCellsContents
truncate table _Roles
truncate table _Security
truncate table _Settings
truncate table _Users
truncate table _UsersRoles

truncate table AccommodationsRules

truncate table AuditActs
truncate table AuditActsGoods

truncate table BarCodeLabels

truncate table Brigades
truncate table BrigadesHistory

truncate table Cells
truncate table CellsChanges
truncate table CellsContents

truncate table CellsContentsSnapshots
truncate table CellsContentsSnapshotsBeg
truncate table CellsContentsSnapshotsEnd

truncate table CellsLog

truncate table Devices
truncate table DevicesNotifications
truncate table DevicesSessions
truncate table DevicesTypes

truncate table Frames

truncate table Goods
truncate table GoodsBrands
truncate table GoodsGroups
truncate table GoodsStates

truncate table Hosts

truncate table Inputs
truncate table InputsGoods
truncate table InputsItems
truncate table InputsTypes
truncate table InputsUnloaders

truncate table Inventories
truncate table InventoriesCells

truncate table Movings
truncate table MovingsGoods
truncate table MovingsTypes

truncate table Oddments
truncate table OddmentsSaved
truncate table OddmentsSavedGoods

truncate table Outputs
truncate table OutputsGoods
truncate table OutputsItems
truncate table OutputsLoaders
truncate table OutputsTypes

truncate table Packings

truncate table PalletsTypes

truncate table Partners

truncate table SalaryExtraWorks
truncate table SalaryTariffs

truncate table StoresZones
truncate table StoresZonesTypes

truncate table Tares

truncate table TrafficsFrames
truncate table TrafficsFramesErrors
truncate table TrafficsGoods
truncate table TrafficsGoodsErrors

-- Добавление связей
exec (@AddScript)
if @@Error = 0 drop table __ForeignKeys
