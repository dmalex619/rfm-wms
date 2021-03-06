/*
   9 февраля 2010 г.11:44:50
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
ALTER TABLE dbo.Partners
	DROP CONSTRAINT DF_Partners_Owner
GO
ALTER TABLE dbo.Partners
	DROP CONSTRAINT DF_Partners_RestControl
GO
ALTER TABLE dbo.Partners
	DROP CONSTRAINT DF_Partners_Actual
GO
CREATE TABLE dbo.Tmp_Partners
	(
	ID int NOT NULL IDENTITY (1, 1),
	Name varchar(100) NOT NULL,
	Owner bit NOT NULL,
	SeparatePicking bit NOT NULL,
	Actual bit NOT NULL,
	ERPCode varchar(50) NULL,
	HostID int NOT NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'Наименование контрагента'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Partners', N'COLUMN', N'Name'
GO
DECLARE @v sql_variant 
SET @v = N'Владелец товара?'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Partners', N'COLUMN', N'Owner'
GO
DECLARE @v sql_variant 
SET @v = N'Учет остатков товара для владельца?'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Partners', N'COLUMN', N'SeparatePicking'
GO
DECLARE @v sql_variant 
SET @v = N'Актуальность'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Partners', N'COLUMN', N'Actual'
GO
DECLARE @v sql_variant 
SET @v = N'Код в учетной системе'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Partners', N'COLUMN', N'ERPCode'
GO
DECLARE @v sql_variant 
SET @v = N'Код хоста'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Partners', N'COLUMN', N'HostID'
GO
ALTER TABLE dbo.Tmp_Partners ADD CONSTRAINT
	DF_Partners_Owner DEFAULT ((0)) FOR Owner
GO
ALTER TABLE dbo.Tmp_Partners ADD CONSTRAINT
	DF_Partners_RestControl DEFAULT ((0)) FOR SeparatePicking
GO
ALTER TABLE dbo.Tmp_Partners ADD CONSTRAINT
	DF_Partners_Actual DEFAULT ((1)) FOR Actual
GO
SET IDENTITY_INSERT dbo.Tmp_Partners ON
GO
IF EXISTS(SELECT * FROM dbo.Partners)
	 EXEC('INSERT INTO dbo.Tmp_Partners (ID, Name, Owner, SeparatePicking, Actual, ERPCode, HostID)
		SELECT ID, Name, Owner, SeparatePicking, Actual, ERPCode, HostID FROM dbo.Partners WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Partners OFF
GO
ALTER TABLE dbo.Inputs
	DROP CONSTRAINT FK_Inputs_Partners
GO
ALTER TABLE dbo.Inputs
	DROP CONSTRAINT FK_Inputs_PartnersOwners
GO
ALTER TABLE dbo.CellsContentsSnapshotsEnd
	DROP CONSTRAINT FK_CellsContentsSnapshotsEnd_Partners
GO
ALTER TABLE dbo.AuditActs
	DROP CONSTRAINT FK_AuditActs_PartnersOwners
GO
ALTER TABLE dbo.Oddments
	DROP CONSTRAINT FK_Oddments_Partners
GO
ALTER TABLE dbo.CellsContents
	DROP CONSTRAINT FK_CellsContents_Partners
GO
ALTER TABLE dbo.Cells
	DROP CONSTRAINT FK_Cells_Partners
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT FK_TrafficsGoods_Partners
GO
ALTER TABLE dbo.GoodsStates
	DROP CONSTRAINT FK_GoodsStates_Partners
GO
ALTER TABLE dbo.InputsTypes
	DROP CONSTRAINT FK_InputsTypes_Partners
GO
ALTER TABLE dbo.CellsChanges
	DROP CONSTRAINT FK_CellsChanges_Partners
GO
ALTER TABLE dbo.InventoriesCells
	DROP CONSTRAINT FK_InventoriesCells_Partners
GO
ALTER TABLE dbo.Movings
	DROP CONSTRAINT FK_Movings_Partners
GO
ALTER TABLE dbo.Frames
	DROP CONSTRAINT FK_Frames_Partners
GO
ALTER TABLE dbo.OutputsTypes
	DROP CONSTRAINT FK_OutputsTypes_Partners
GO
ALTER TABLE dbo.Outputs
	DROP CONSTRAINT FK_Outputs_Partners
GO
ALTER TABLE dbo.Outputs
	DROP CONSTRAINT FK_Outputs_PartnersOwners
GO
ALTER TABLE dbo.CellsContentsSnapshotsBeg
	DROP CONSTRAINT FK_CellsContentsSnapshotsBeg_Partners
GO
DROP TABLE dbo.Partners
GO
EXECUTE sp_rename N'dbo.Tmp_Partners', N'Partners', 'OBJECT' 
GO
ALTER TABLE dbo.Partners ADD CONSTRAINT
	PK_Partners PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX IX_Partners_ERPCode ON dbo.Partners
	(
	ERPCode
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Partners_HostID ON dbo.Partners
	(
	HostID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.Partners ADD CONSTRAINT
	FK_Partners_Hosts FOREIGN KEY
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
ALTER TABLE dbo.CellsContentsSnapshotsBeg ADD CONSTRAINT
	FK_CellsContentsSnapshotsBeg_Partners FOREIGN KEY
	(
	OwnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Outputs ADD CONSTRAINT
	FK_Outputs_Partners FOREIGN KEY
	(
	PartnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Outputs ADD CONSTRAINT
	FK_Outputs_PartnersOwners FOREIGN KEY
	(
	OwnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.OutputsTypes ADD CONSTRAINT
	FK_OutputsTypes_Partners FOREIGN KEY
	(
	OwnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Frames ADD CONSTRAINT
	FK_Frames_Partners FOREIGN KEY
	(
	OwnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Movings ADD CONSTRAINT
	FK_Movings_Partners FOREIGN KEY
	(
	OwnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.InventoriesCells ADD CONSTRAINT
	FK_InventoriesCells_Partners FOREIGN KEY
	(
	OwnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CellsChanges ADD CONSTRAINT
	FK_CellsChanges_Partners FOREIGN KEY
	(
	OwnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.InputsTypes ADD CONSTRAINT
	FK_InputsTypes_Partners FOREIGN KEY
	(
	OwnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.GoodsStates ADD CONSTRAINT
	FK_GoodsStates_Partners FOREIGN KEY
	(
	OwnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TrafficsGoods ADD CONSTRAINT
	FK_TrafficsGoods_Partners FOREIGN KEY
	(
	OwnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Cells ADD CONSTRAINT
	FK_Cells_Partners FOREIGN KEY
	(
	FixedOwnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CellsContents ADD CONSTRAINT
	FK_CellsContents_Partners FOREIGN KEY
	(
	OwnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Oddments ADD CONSTRAINT
	FK_Oddments_Partners FOREIGN KEY
	(
	OwnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
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
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CellsContentsSnapshotsEnd ADD CONSTRAINT
	FK_CellsContentsSnapshotsEnd_Partners FOREIGN KEY
	(
	OwnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Inputs ADD CONSTRAINT
	FK_Inputs_Partners FOREIGN KEY
	(
	PartnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Inputs ADD CONSTRAINT
	FK_Inputs_PartnersOwners FOREIGN KEY
	(
	OwnerID
	) REFERENCES dbo.Partners
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
