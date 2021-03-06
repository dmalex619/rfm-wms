/*
   13 августа 2013 г.13:28:14
   Пользователь: 
   Сервер: (local)
   База данных: WMS
   Приложение: 
*/

/* Чтобы предотвратить возможность потери данных, необходимо внимательно просмотреть этот сценарий, прежде чем запускать его вне контекста конструктора баз данных.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.AccommodationsRules
	DROP CONSTRAINT FK_AccommodationsRules_StoresZonesTypes_Source
GO
ALTER TABLE dbo.AccommodationsRules
	DROP CONSTRAINT FK_AccommodationsRules_StoresZonesTypes_Target
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.AccommodationsRules
	DROP CONSTRAINT FK_AccommodationsRules_StoresZones_Source
GO
ALTER TABLE dbo.AccommodationsRules
	DROP CONSTRAINT FK_AccommodationsRules_StoresZones_Target
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.AccommodationsRules
	DROP CONSTRAINT DF_AccommodationsRules_Actual
GO
CREATE TABLE dbo.Tmp_AccommodationsRules
	(
	ID int NOT NULL IDENTITY (1, 1),
	Name varchar(250) NULL,
	Priority int NOT NULL,
	SourceZoneTypeID int NULL,
	SourceZoneID int NULL,
	OwnerControl bit NOT NULL,
	GoodStateControl bit NOT NULL,
	PackingControl bit NOT NULL,
	CellPalletTypeControl bit NOT NULL,
	CellWeightControl bit NOT NULL,
	CellHeightControl bit NOT NULL,
	CellMaxQntControl bit NOT NULL,
	RestsControl bit NOT NULL,
	TemperatureModeControl bit NOT NULL,
	FullPalletControl bit NULL,
	HalfStuffControl bit NULL,
	TargetZoneTypeID int NULL,
	TargetZoneID int NULL,
	ABCControl varchar(5) NULL,
	Actual bit NOT NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'Название правила'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'Name'
GO
DECLARE @v sql_variant 
SET @v = N'Приоритет'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'Priority'
GO
DECLARE @v sql_variant 
SET @v = N'Тип зоны - источник'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'SourceZoneTypeID'
GO
DECLARE @v sql_variant 
SET @v = N'Зона - источник'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'SourceZoneID'
GO
DECLARE @v sql_variant 
SET @v = N'Контроль владельца?'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'OwnerControl'
GO
DECLARE @v sql_variant 
SET @v = N'Контроль состояния?'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'GoodStateControl'
GO
DECLARE @v sql_variant 
SET @v = N'Контроль товара?'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'PackingControl'
GO
DECLARE @v sql_variant 
SET @v = N'Контроль типа поддона?'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'CellPalletTypeControl'
GO
DECLARE @v sql_variant 
SET @v = N'Контроль max допустимого веса в ячейке?'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'CellWeightControl'
GO
DECLARE @v sql_variant 
SET @v = N'Контроль ширины ячейки?'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'CellHeightControl'
GO
DECLARE @v sql_variant 
SET @v = N'Контроль max количества паалете в ячейке?'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'CellMaxQntControl'
GO
DECLARE @v sql_variant 
SET @v = N'Контроль остатков?'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'RestsControl'
GO
DECLARE @v sql_variant 
SET @v = N'Учет температурного режима'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'TemperatureModeControl'
GO
DECLARE @v sql_variant 
SET @v = N'Контроль целых паллет'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'FullPalletControl'
GO
DECLARE @v sql_variant 
SET @v = N'Контроль полуфабриката'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'HalfStuffControl'
GO
DECLARE @v sql_variant 
SET @v = N'Тип зоны - приемник'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'TargetZoneTypeID'
GO
DECLARE @v sql_variant 
SET @v = N'Зона - приемник'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'TargetZoneID'
GO
DECLARE @v sql_variant 
SET @v = N'Контроль уходимости товаров'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'ABCControl'
GO
DECLARE @v sql_variant 
SET @v = N'Актуальность'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AccommodationsRules', N'COLUMN', N'Actual'
GO
ALTER TABLE dbo.Tmp_AccommodationsRules ADD CONSTRAINT
	DF_AccommodationsRules_Actual DEFAULT ((1)) FOR Actual
GO
SET IDENTITY_INSERT dbo.Tmp_AccommodationsRules ON
GO
IF EXISTS(SELECT * FROM dbo.AccommodationsRules)
	 EXEC('INSERT INTO dbo.Tmp_AccommodationsRules (ID, Name, Priority, SourceZoneTypeID, SourceZoneID, OwnerControl, GoodStateControl, PackingControl, CellPalletTypeControl, CellWeightControl, CellHeightControl, CellMaxQntControl, RestsControl, TemperatureModeControl, FullPalletControl, HalfStuffControl, TargetZoneTypeID, TargetZoneID, Actual)
		SELECT ID, Name, Priority, SourceZoneTypeID, SourceZoneID, OwnerControl, GoodStateControl, PackingControl, CellPalletTypeControl, CellWeightControl, CellHeightControl, CellMaxQntControl, RestsControl, TemperatureModeControl, FullPalletControl, HalfStuffControl, TargetZoneTypeID, TargetZoneID, Actual FROM dbo.AccommodationsRules WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_AccommodationsRules OFF
GO
DROP TABLE dbo.AccommodationsRules
GO
EXECUTE sp_rename N'dbo.Tmp_AccommodationsRules', N'AccommodationsRules', 'OBJECT' 
GO
ALTER TABLE dbo.AccommodationsRules ADD CONSTRAINT
	PK_AccommodationsRules PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.AccommodationsRules ADD CONSTRAINT
	FK_AccommodationsRules_StoresZones_Source FOREIGN KEY
	(
	SourceZoneID
	) REFERENCES dbo.StoresZones
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.AccommodationsRules ADD CONSTRAINT
	FK_AccommodationsRules_StoresZones_Target FOREIGN KEY
	(
	TargetZoneID
	) REFERENCES dbo.StoresZones
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.AccommodationsRules ADD CONSTRAINT
	FK_AccommodationsRules_StoresZonesTypes_Source FOREIGN KEY
	(
	SourceZoneTypeID
	) REFERENCES dbo.StoresZonesTypes
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.AccommodationsRules ADD CONSTRAINT
	FK_AccommodationsRules_StoresZonesTypes_Target FOREIGN KEY
	(
	TargetZoneTypeID
	) REFERENCES dbo.StoresZonesTypes
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
