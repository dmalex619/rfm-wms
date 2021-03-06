/*
   18 сентября 2008 г.10:34:07
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
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.OutputsLoaders
	(
	ID int NOT NULL IDENTITY (1, 1),
	OutputID int NOT NULL,
	UserID int NOT NULL,
	StoreZoneID int NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'Сотрудники, загружавшие машину'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'OutputsLoaders', NULL, NULL
GO
DECLARE @v sql_variant 
SET @v = N'Отгрузка'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'OutputsLoaders', N'COLUMN', N'OutputID'
GO
DECLARE @v sql_variant 
SET @v = N'Сотрудник'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'OutputsLoaders', N'COLUMN', N'UserID'
GO
DECLARE @v sql_variant 
SET @v = N'Складская зона'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'OutputsLoaders', N'COLUMN', N'StoreZoneID'
GO
ALTER TABLE dbo.OutputsLoaders ADD CONSTRAINT
	PK_OutputsLoaders PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.OutputsLoaders ADD CONSTRAINT
	FK_OutputsLoaders_Outputs FOREIGN KEY
	(
	OutputID
	) REFERENCES dbo.Outputs
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OutputsLoaders ADD CONSTRAINT
	FK_OutputsLoaders__Users FOREIGN KEY
	(
	UserID
	) REFERENCES dbo._Users
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
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
COMMIT
