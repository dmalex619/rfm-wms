/*
   18 сентября 2008 г.10:29:14
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
CREATE TABLE dbo.InputsUnloaders
	(
	ID int NOT NULL IDENTITY (1, 1),
	InputID int NOT NULL,
	UserID int NOT NULL,
	StoreZoneID int NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'Сотрудники, разгружавшие приход'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'InputsUnloaders', NULL, NULL
GO
DECLARE @v sql_variant 
SET @v = N'Приход'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'InputsUnloaders', N'COLUMN', N'InputID'
GO
DECLARE @v sql_variant 
SET @v = N'Сотрудник'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'InputsUnloaders', N'COLUMN', N'UserID'
GO
DECLARE @v sql_variant 
SET @v = N'Складская зона'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'InputsUnloaders', N'COLUMN', N'StoreZoneID'
GO
ALTER TABLE dbo.InputsUnloaders ADD CONSTRAINT
	PK_InputsUnloaders PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.InputsUnloaders ADD CONSTRAINT
	FK_InputsUnloaders_Inputs FOREIGN KEY
	(
	InputID
	) REFERENCES dbo.Inputs
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.InputsUnloaders ADD CONSTRAINT
	FK_InputsUnloaders__Users FOREIGN KEY
	(
	UserID
	) REFERENCES dbo._Users
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
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
COMMIT
