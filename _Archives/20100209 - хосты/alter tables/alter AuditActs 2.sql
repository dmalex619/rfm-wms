/*
   9 февраля 2010 г.11:51:52
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
ALTER TABLE dbo.AuditActs
	DROP CONSTRAINT FK_AuditActs_PartnersOwners
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.AuditActs
	DROP CONSTRAINT FK_AuditActs_GoodsStates
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_AuditActs
	(
	ID int NOT NULL IDENTITY (1, 1),
	DateAudit smalldatetime NOT NULL,
	OwnerID int NOT NULL,
	GoodStateID int NOT NULL,
	Note varchar(250) NOT NULL,
	DateConfirm smalldatetime NULL,
	OddmentSavedID int NULL,
	ERPCode varchar(50) NULL,
	HostID int NOT NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'Акты ревизий'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AuditActs', NULL, NULL
GO
DECLARE @v sql_variant 
SET @v = N'Дата ввода акта ревизии'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AuditActs', N'COLUMN', N'DateAudit'
GO
DECLARE @v sql_variant 
SET @v = N'Владелец товара'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AuditActs', N'COLUMN', N'OwnerID'
GO
DECLARE @v sql_variant 
SET @v = N'Состояние товара'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AuditActs', N'COLUMN', N'GoodStateID'
GO
DECLARE @v sql_variant 
SET @v = N'Примечание'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AuditActs', N'COLUMN', N'Note'
GO
DECLARE @v sql_variant 
SET @v = N'Дата автоматического проведения'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AuditActs', N'COLUMN', N'DateConfirm'
GO
DECLARE @v sql_variant 
SET @v = N'Сохраненные остатки'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AuditActs', N'COLUMN', N'OddmentSavedID'
GO
DECLARE @v sql_variant 
SET @v = N'Код в учетной системе'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AuditActs', N'COLUMN', N'ERPCode'
GO
DECLARE @v sql_variant 
SET @v = N'Код хоста'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AuditActs', N'COLUMN', N'HostID'
GO
SET IDENTITY_INSERT dbo.Tmp_AuditActs ON
GO
IF EXISTS(SELECT * FROM dbo.AuditActs)
	 EXEC('INSERT INTO dbo.Tmp_AuditActs (ID, DateAudit, OwnerID, GoodStateID, Note, DateConfirm, OddmentSavedID, ERPCode, HostID)
		SELECT ID, DateAudit, OwnerID, GoodStateID, Note, DateConfirm, OddmentSavedID, ERPCode, HostID FROM dbo.AuditActs WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_AuditActs OFF
GO
ALTER TABLE dbo.AuditActsGoods
	DROP CONSTRAINT FK_AuditActsGoods_AuditActs
GO
DROP TABLE dbo.AuditActs
GO
EXECUTE sp_rename N'dbo.Tmp_AuditActs', N'AuditActs', 'OBJECT' 
GO
ALTER TABLE dbo.AuditActs ADD CONSTRAINT
	PK_AuditActs PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX IX_AuditActs_DateAudit ON dbo.AuditActs
	(
	DateAudit
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_AuditActs_OwnerID ON dbo.AuditActs
	(
	OwnerID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_AuditActs_GoodStateID ON dbo.AuditActs
	(
	GoodStateID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_AuditActs_ERPCode ON dbo.AuditActs
	(
	ERPCode
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_AuditActs_HostID ON dbo.AuditActs
	(
	HostID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.AuditActs ADD CONSTRAINT
	FK_AuditActs_GoodsStates FOREIGN KEY
	(
	GoodStateID
	) REFERENCES dbo.GoodsStates
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.AuditActs ADD CONSTRAINT
	FK_AuditActs_PartnersOwners FOREIGN KEY
	(
	OwnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.AuditActs ADD CONSTRAINT
	FK_AuditActs_Hosts FOREIGN KEY
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
ALTER TABLE dbo.AuditActsGoods ADD CONSTRAINT
	FK_AuditActsGoods_AuditActs FOREIGN KEY
	(
	AuditActID
	) REFERENCES dbo.AuditActs
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
