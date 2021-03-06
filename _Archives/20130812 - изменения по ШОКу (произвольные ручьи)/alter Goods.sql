/*
   13 августа 2013 г.13:32:10
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
ALTER TABLE dbo.Goods
	DROP CONSTRAINT FK_Goods_GoodsGroups
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Goods
	DROP CONSTRAINT FK_Goods_GoodsBrands
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Goods
	DROP CONSTRAINT FK_Goods_Hosts
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Goods
	DROP CONSTRAINT DF_Goods_Articul
GO
ALTER TABLE dbo.Goods
	DROP CONSTRAINT DF_Goods_Retention
GO
ALTER TABLE dbo.Goods
	DROP CONSTRAINT DF_Goods_Weighting
GO
ALTER TABLE dbo.Goods
	DROP CONSTRAINT DF_Goods_TemperatureMode
GO
ALTER TABLE dbo.Goods
	DROP CONSTRAINT DF_Goods_Gravity
GO
ALTER TABLE dbo.Goods
	DROP CONSTRAINT DF_Goods_Cost
GO
ALTER TABLE dbo.Goods
	DROP CONSTRAINT DF_Goods_Actual
GO
CREATE TABLE dbo.Tmp_Goods
	(
	ID int NOT NULL IDENTITY (1, 1),
	Alias varchar(50) NOT NULL,
	Name varchar(200) NOT NULL,
	BarCode varchar(13) NOT NULL,
	Articul varchar(100) NOT NULL,
	Netto numeric(10, 3) NOT NULL,
	Brutto numeric(10, 3) NOT NULL,
	Retention int NOT NULL,
	Weighting bit NOT NULL,
	HalfStuff bit NOT NULL,
	TemperatureMode varchar(1) NOT NULL,
	GoodGroupID int NOT NULL,
	GoodBrandID int NOT NULL,
	Gravity char(1) NOT NULL,
	Cost money NOT NULL,
	Actual bit NOT NULL,
	ABCRank varchar(1) NOT NULL,
	ERPCode varchar(50) NULL,
	HostID int NOT NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'Наименование товара'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Goods', N'COLUMN', N'Name'
GO
DECLARE @v sql_variant 
SET @v = N'Вес нетто (шт, кг)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Goods', N'COLUMN', N'Netto'
GO
DECLARE @v sql_variant 
SET @v = N'Вес брутто (шт,  кг)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Goods', N'COLUMN', N'Brutto'
GO
DECLARE @v sql_variant 
SET @v = N'Срок хранения (дни)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Goods', N'COLUMN', N'Retention'
GO
DECLARE @v sql_variant 
SET @v = N'Весовой товар?'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Goods', N'COLUMN', N'Weighting'
GO
DECLARE @v sql_variant 
SET @v = N'Признак полуфабриката'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Goods', N'COLUMN', N'HalfStuff'
GO
DECLARE @v sql_variant 
SET @v = N'Температурный режим хранения товара'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Goods', N'COLUMN', N'TemperatureMode'
GO
DECLARE @v sql_variant 
SET @v = N'Товарная группа'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Goods', N'COLUMN', N'GoodGroupID'
GO
DECLARE @v sql_variant 
SET @v = N'Производитель товара'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Goods', N'COLUMN', N'GoodBrandID'
GO
DECLARE @v sql_variant 
SET @v = N'Текущая себестоимость'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Goods', N'COLUMN', N'Cost'
GO
DECLARE @v sql_variant 
SET @v = N'Актуальность'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Goods', N'COLUMN', N'Actual'
GO
DECLARE @v sql_variant 
SET @v = N'ABC-ранг товара (по уходимости со склада)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Goods', N'COLUMN', N'ABCRank'
GO
DECLARE @v sql_variant 
SET @v = N'Код в учетной системе'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Goods', N'COLUMN', N'ERPCode'
GO
DECLARE @v sql_variant 
SET @v = N'Код хоста'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Goods', N'COLUMN', N'HostID'
GO
ALTER TABLE dbo.Tmp_Goods ADD CONSTRAINT
	DF_Goods_Articul DEFAULT ('') FOR Articul
GO
ALTER TABLE dbo.Tmp_Goods ADD CONSTRAINT
	DF_Goods_Retention DEFAULT ((0)) FOR Retention
GO
ALTER TABLE dbo.Tmp_Goods ADD CONSTRAINT
	DF_Goods_Weighting DEFAULT ((0)) FOR Weighting
GO
ALTER TABLE dbo.Tmp_Goods ADD CONSTRAINT
	DF_Goods_TemperatureMode DEFAULT ('F') FOR TemperatureMode
GO
ALTER TABLE dbo.Tmp_Goods ADD CONSTRAINT
	DF_Goods_Gravity DEFAULT ('') FOR Gravity
GO
ALTER TABLE dbo.Tmp_Goods ADD CONSTRAINT
	DF_Goods_Cost DEFAULT ((0)) FOR Cost
GO
ALTER TABLE dbo.Tmp_Goods ADD CONSTRAINT
	DF_Goods_Actual DEFAULT ((1)) FOR Actual
GO
ALTER TABLE dbo.Tmp_Goods ADD CONSTRAINT
	DF_Goods_ABCRank DEFAULT '' FOR ABCRank
GO
SET IDENTITY_INSERT dbo.Tmp_Goods ON
GO
IF EXISTS(SELECT * FROM dbo.Goods)
	 EXEC('INSERT INTO dbo.Tmp_Goods (ID, Alias, Name, BarCode, Articul, Netto, Brutto, Retention, Weighting, HalfStuff, TemperatureMode, GoodGroupID, GoodBrandID, Gravity, Cost, Actual, ERPCode, HostID)
		SELECT ID, Alias, Name, BarCode, Articul, Netto, Brutto, Retention, Weighting, HalfStuff, TemperatureMode, GoodGroupID, GoodBrandID, Gravity, Cost, Actual, ERPCode, HostID FROM dbo.Goods WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Goods OFF
GO
ALTER TABLE dbo.Packings
	DROP CONSTRAINT FK_Packings_Goods
GO
DROP TABLE dbo.Goods
GO
EXECUTE sp_rename N'dbo.Tmp_Goods', N'Goods', 'OBJECT' 
GO
ALTER TABLE dbo.Goods ADD CONSTRAINT
	PK_Goods PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX IX_Goods_Alias ON dbo.Goods
	(
	Alias
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Goods_BarCode ON dbo.Goods
	(
	BarCode
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Goods_GoodGroupID ON dbo.Goods
	(
	GoodGroupID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Goods_GoodBrandID ON dbo.Goods
	(
	GoodBrandID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Goods_ERPCode ON dbo.Goods
	(
	ERPCode
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Goods_HostID ON dbo.Goods
	(
	HostID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.Goods ADD CONSTRAINT
	FK_Goods_Hosts FOREIGN KEY
	(
	HostID
	) REFERENCES dbo.Hosts
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Goods ADD CONSTRAINT
	FK_Goods_GoodsBrands FOREIGN KEY
	(
	GoodBrandID
	) REFERENCES dbo.GoodsBrands
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Goods ADD CONSTRAINT
	FK_Goods_GoodsGroups FOREIGN KEY
	(
	GoodGroupID
	) REFERENCES dbo.GoodsGroups
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Packings ADD CONSTRAINT
	FK_Packings_Goods FOREIGN KEY
	(
	GoodID
	) REFERENCES dbo.Goods
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
