/*
   23 апреля 2010 г.10:50:06
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
ALTER TABLE dbo.Complexes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.StoresZones
	DROP CONSTRAINT FK_StoresZones_StoresZonesTypes
GO
ALTER TABLE dbo.StoresZonesTypes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.StoresZones
	DROP CONSTRAINT DF_StoresZones_NamePrefix
GO
ALTER TABLE dbo.StoresZones
	DROP CONSTRAINT DF_StoresZones_NameSuffix
GO
ALTER TABLE dbo.StoresZones
	DROP CONSTRAINT DF_StoresZones_Actual
GO
CREATE TABLE dbo.Tmp_StoresZones
	(
	ID int NOT NULL IDENTITY (1, 1),
	Name varchar(50) NOT NULL,
	StoreZoneTypeID int NOT NULL,
	ComplexID int NULL,
	Sequence char(1) NOT NULL,
	MaxPalletQnt numeric(9, 0) NULL,
	NamePrefix varchar(5) NOT NULL,
	NameSuffix varchar(5) NOT NULL,
	TemperatureMode varchar(1) NULL,
	Actual bit NOT NULL,
	ERPCode varchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_StoresZones SET (LOCK_ESCALATION = TABLE)
GO
DECLARE @v sql_variant 
SET @v = N'Наименование зоны склада'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_StoresZones', N'COLUMN', N'Name'
GO
DECLARE @v sql_variant 
SET @v = N'Тип зоны склада'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_StoresZones', N'COLUMN', N'StoreZoneTypeID'
GO
DECLARE @v sql_variant 
SET @v = N'Физический склад'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_StoresZones', N'COLUMN', N'ComplexID'
GO
DECLARE @v sql_variant 
SET @v = N'Последовательность обхода: F, L, S'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_StoresZones', N'COLUMN', N'Sequence'
GO
DECLARE @v sql_variant 
SET @v = N'Максимальное кол-во контейнеров в ячейке зоны'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_StoresZones', N'COLUMN', N'MaxPalletQnt'
GO
DECLARE @v sql_variant 
SET @v = N'Префикс адреса ячеек зоны'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_StoresZones', N'COLUMN', N'NamePrefix'
GO
DECLARE @v sql_variant 
SET @v = N'Суффикс адреса ячеек зоны'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_StoresZones', N'COLUMN', N'NameSuffix'
GO
DECLARE @v sql_variant 
SET @v = N'Температурный режим хранения товара'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_StoresZones', N'COLUMN', N'TemperatureMode'
GO
DECLARE @v sql_variant 
SET @v = N'Актуальность'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_StoresZones', N'COLUMN', N'Actual'
GO
DECLARE @v sql_variant 
SET @v = N'Код в учетной системе'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_StoresZones', N'COLUMN', N'ERPCode'
GO
ALTER TABLE dbo.Tmp_StoresZones ADD CONSTRAINT
	DF_StoresZones_NamePrefix DEFAULT ('') FOR NamePrefix
GO
ALTER TABLE dbo.Tmp_StoresZones ADD CONSTRAINT
	DF_StoresZones_NameSuffix DEFAULT ('') FOR NameSuffix
GO
ALTER TABLE dbo.Tmp_StoresZones ADD CONSTRAINT
	DF_StoresZones_Actual DEFAULT ((1)) FOR Actual
GO
SET IDENTITY_INSERT dbo.Tmp_StoresZones ON
GO
IF EXISTS(SELECT * FROM dbo.StoresZones)
	 EXEC('INSERT INTO dbo.Tmp_StoresZones (ID, Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, TemperatureMode, Actual, ERPCode)
		SELECT ID, Name, StoreZoneTypeID, Sequence, MaxPalletQnt, NamePrefix, NameSuffix, TemperatureMode, Actual, ERPCode FROM dbo.StoresZones WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_StoresZones OFF
GO
ALTER TABLE dbo.AccommodationsRules
	DROP CONSTRAINT FK_AccommodationsRules_StoresZones_Source
GO
ALTER TABLE dbo.AccommodationsRules
	DROP CONSTRAINT FK_AccommodationsRules_StoresZones_Target
GO
ALTER TABLE dbo.InputsUnloaders
	DROP CONSTRAINT FK_InputsUnloaders_StoresZones
GO
ALTER TABLE dbo.OutputsLoaders
	DROP CONSTRAINT FK_OutputsLoaders_StoresZones
GO
ALTER TABLE dbo.Cells
	DROP CONSTRAINT FK_Cells_StoresZones
GO
DROP TABLE dbo.StoresZones
GO
EXECUTE sp_rename N'dbo.Tmp_StoresZones', N'StoresZones', 'OBJECT' 
GO
ALTER TABLE dbo.StoresZones ADD CONSTRAINT
	PK_StoresZones PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX IX_StoresZones_StoreZoneTypeID ON dbo.StoresZones
	(
	StoreZoneTypeID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_StoresZones_ComplexID ON dbo.StoresZones
	(
	ComplexID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.StoresZones ADD CONSTRAINT
	FK_StoresZones_StoresZonesTypes FOREIGN KEY
	(
	StoreZoneTypeID
	) REFERENCES dbo.StoresZonesTypes
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.StoresZones ADD CONSTRAINT
	FK_StoresZones_Complexes FOREIGN KEY
	(
	ComplexID
	) REFERENCES dbo.Complexes
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Cells ADD CONSTRAINT
	FK_Cells_StoresZones FOREIGN KEY
	(
	StoreZoneID
	) REFERENCES dbo.StoresZones
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Cells SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.OutputsLoaders ADD CONSTRAINT
	FK_OutputsLoaders_StoresZones FOREIGN KEY
	(
	StoreZoneID
	) REFERENCES dbo.StoresZones
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OutputsLoaders SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.InputsUnloaders ADD CONSTRAINT
	FK_InputsUnloaders_StoresZones FOREIGN KEY
	(
	StoreZoneID
	) REFERENCES dbo.StoresZones
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.InputsUnloaders SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
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
ALTER TABLE dbo.AccommodationsRules SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
