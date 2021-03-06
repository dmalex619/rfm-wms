/*
   9 февраля 2010 г.11:43:03
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
ALTER TABLE dbo.GoodsGroups
	DROP CONSTRAINT DF_GoodsGroups_Actual
GO
CREATE TABLE dbo.Tmp_GoodsGroups
	(
	ID int NOT NULL IDENTITY (1, 1),
	Name varchar(100) NOT NULL,
	Actual bit NOT NULL,
	ERPCode varchar(50) NULL,
	HostID int NOT NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'Название товарной группы'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_GoodsGroups', N'COLUMN', N'Name'
GO
DECLARE @v sql_variant 
SET @v = N'Актуальность'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_GoodsGroups', N'COLUMN', N'Actual'
GO
DECLARE @v sql_variant 
SET @v = N'Код в учетной системе'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_GoodsGroups', N'COLUMN', N'ERPCode'
GO
DECLARE @v sql_variant 
SET @v = N'Код хоста'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_GoodsGroups', N'COLUMN', N'HostID'
GO
ALTER TABLE dbo.Tmp_GoodsGroups ADD CONSTRAINT
	DF_GoodsGroups_Actual DEFAULT ((1)) FOR Actual
GO
SET IDENTITY_INSERT dbo.Tmp_GoodsGroups ON
GO
IF EXISTS(SELECT * FROM dbo.GoodsGroups)
	 EXEC('INSERT INTO dbo.Tmp_GoodsGroups (ID, Name, Actual, ERPCode, HostID)
		SELECT ID, Name, Actual, ERPCode, HostID FROM dbo.GoodsGroups WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_GoodsGroups OFF
GO
ALTER TABLE dbo.Goods
	DROP CONSTRAINT FK_Goods_GoodsGroups
GO
DROP TABLE dbo.GoodsGroups
GO
EXECUTE sp_rename N'dbo.Tmp_GoodsGroups', N'GoodsGroups', 'OBJECT' 
GO
ALTER TABLE dbo.GoodsGroups ADD CONSTRAINT
	PK_GoodsGroups PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX IX_GoodsGroups_ERPCode ON dbo.GoodsGroups
	(
	ERPCode
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_GoodsGroups_HostID ON dbo.GoodsGroups
	(
	HostID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.GoodsGroups ADD CONSTRAINT
	FK_GoodsGroups_Hosts FOREIGN KEY
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
