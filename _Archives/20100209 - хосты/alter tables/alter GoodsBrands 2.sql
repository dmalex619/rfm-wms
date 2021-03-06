/*
   9 февраля 2010 г.11:41:37
   User: 
   Server: (local)
   Database: WMS
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.GoodsBrands
	DROP CONSTRAINT DF_GoodsProducers_Name
GO
ALTER TABLE dbo.GoodsBrands
	DROP CONSTRAINT DF_GoodsProducers_Actual
GO
CREATE TABLE dbo.Tmp_GoodsBrands
	(
	ID int NOT NULL IDENTITY (1, 1),
	Name varchar(100) NOT NULL,
	Actual bit NOT NULL,
	ERPCode varchar(50) NULL,
	HostID int NOT NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'Торговые марки'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_GoodsBrands', NULL, NULL
GO
DECLARE @v sql_variant 
SET @v = N'Наименование производителя товара'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_GoodsBrands', N'COLUMN', N'Name'
GO
DECLARE @v sql_variant 
SET @v = N'Актуальность'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_GoodsBrands', N'COLUMN', N'Actual'
GO
DECLARE @v sql_variant 
SET @v = N'Код в учетной системе'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_GoodsBrands', N'COLUMN', N'ERPCode'
GO
DECLARE @v sql_variant 
SET @v = N'Код хоста'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_GoodsBrands', N'COLUMN', N'HostID'
GO
ALTER TABLE dbo.Tmp_GoodsBrands ADD CONSTRAINT
	DF_GoodsProducers_Name DEFAULT ('') FOR Name
GO
ALTER TABLE dbo.Tmp_GoodsBrands ADD CONSTRAINT
	DF_GoodsProducers_Actual DEFAULT ((0)) FOR Actual
GO
SET IDENTITY_INSERT dbo.Tmp_GoodsBrands ON
GO
IF EXISTS(SELECT * FROM dbo.GoodsBrands)
	 EXEC('INSERT INTO dbo.Tmp_GoodsBrands (ID, Name, Actual, ERPCode, HostID)
		SELECT ID, Name, Actual, ERPCode, HostID FROM dbo.GoodsBrands WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_GoodsBrands OFF
GO
ALTER TABLE dbo.Goods
	DROP CONSTRAINT FK_Goods_GoodsBrands
GO
DROP TABLE dbo.GoodsBrands
GO
EXECUTE sp_rename N'dbo.Tmp_GoodsBrands', N'GoodsBrands', 'OBJECT' 
GO
ALTER TABLE dbo.GoodsBrands ADD CONSTRAINT
	PK_GoodsProducers PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX IX_GoodsBrands_ERPCode ON dbo.GoodsBrands
	(
	ERPCode
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_GoodsBrands_HostID ON dbo.GoodsBrands
	(
	HostID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.GoodsBrands ADD CONSTRAINT
	FK_GoodsBrands_Hosts FOREIGN KEY
	(
	HostID
	) REFERENCES dbo.Hosts
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
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
COMMIT
