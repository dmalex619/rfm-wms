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
ALTER TABLE dbo.Frames
	DROP CONSTRAINT FK_Frames_Partners
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Frames
	DROP CONSTRAINT FK_Frames_PalletsTypes
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Frames
	DROP CONSTRAINT FK_Frames_GoodsStates
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Frames
	DROP CONSTRAINT DF_Frames_DateBirth
GO
ALTER TABLE dbo.Frames
	DROP CONSTRAINT DF_Frames_FrameHeight
GO
ALTER TABLE dbo.Frames
	DROP CONSTRAINT DF_Frames_HasTraffic
GO
ALTER TABLE dbo.Frames
	DROP CONSTRAINT DF_Frames_Locked
GO
ALTER TABLE dbo.Frames
	DROP CONSTRAINT DF_Frames_Actual
GO
CREATE TABLE dbo.Tmp_Frames
	(
	ID int NOT NULL IDENTITY (1, 1),
	OwnerID int NULL,
	GoodStateID int NULL,
	BarCode  AS ('FR.0401.'+replace(str([ID],(10)),' ','0')) PERSISTED ,
	DateBirth smalldatetime NOT NULL,
	DateLastOperation smalldatetime NULL,
	PalletTypeID int NULL,
	FrameHeight decimal(10, 3) NOT NULL,
	HasTraffic bit NOT NULL,
	Locked bit NOT NULL,
	State char(1) NULL,
	Actual bit NOT NULL,
	ERPCode varchar(50) NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'Владелец товара'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Frames', N'COLUMN', N'OwnerID'
GO
DECLARE @v sql_variant 
SET @v = N'Состояние товара'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Frames', N'COLUMN', N'GoodStateID'
GO
DECLARE @v sql_variant 
SET @v = N'Штрих-код контейнера'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Frames', N'COLUMN', N'BarCode'
GO
DECLARE @v sql_variant 
SET @v = N'Дата-время создания контейнера'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Frames', N'COLUMN', N'DateBirth'
GO
DECLARE @v sql_variant 
SET @v = N'Дата-время последней операции'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Frames', N'COLUMN', N'DateLastOperation'
GO
DECLARE @v sql_variant 
SET @v = N'Тип поддона'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Frames', N'COLUMN', N'PalletTypeID'
GO
DECLARE @v sql_variant 
SET @v = N'Высота контейнера'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Frames', N'COLUMN', N'FrameHeight'
GO
DECLARE @v sql_variant 
SET @v = N'Есть транспортировка?'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Frames', N'COLUMN', N'HasTraffic'
GO
DECLARE @v sql_variant 
SET @v = N'Блокирован?'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Frames', N'COLUMN', N'Locked'
GO
DECLARE @v sql_variant 
SET @v = N'Состояние контейнера: <NULL>, B, T, S, I, P'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Frames', N'COLUMN', N'State'
GO
DECLARE @v sql_variant 
SET @v = N'Актуальность'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Frames', N'COLUMN', N'Actual'
GO
DECLARE @v sql_variant 
SET @v = N'Код в учетной системе'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Frames', N'COLUMN', N'ERPCode'
GO
ALTER TABLE dbo.Tmp_Frames ADD CONSTRAINT
	DF_Frames_DateBirth DEFAULT (getdate()) FOR DateBirth
GO
ALTER TABLE dbo.Tmp_Frames ADD CONSTRAINT
	DF_Frames_FrameHeight DEFAULT ((0)) FOR FrameHeight
GO
ALTER TABLE dbo.Tmp_Frames ADD CONSTRAINT
	DF_Frames_HasTraffic DEFAULT ((0)) FOR HasTraffic
GO
ALTER TABLE dbo.Tmp_Frames ADD CONSTRAINT
	DF_Frames_Locked DEFAULT ((0)) FOR Locked
GO
ALTER TABLE dbo.Tmp_Frames ADD CONSTRAINT
	DF_Frames_Actual DEFAULT ((1)) FOR Actual
GO
SET IDENTITY_INSERT dbo.Tmp_Frames ON
GO
IF EXISTS(SELECT * FROM dbo.Frames)
	 EXEC('INSERT INTO dbo.Tmp_Frames (ID, OwnerID, GoodStateID, DateBirth, DateLastOperation, PalletTypeID, FrameHeight, HasTraffic, Locked, State, Actual, ERPCode)
		SELECT ID, OwnerID, GoodStateID, DateBirth, DateLastOperation, PalletTypeID, FrameHeight, HasTraffic, Locked, State, Actual, ERPCode FROM dbo.Frames WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Frames OFF
GO
ALTER TABLE dbo.OutputsItems
	DROP CONSTRAINT FK_OutputsItems_Frames
GO
ALTER TABLE dbo.TrafficsFrames
	DROP CONSTRAINT FK_TrafficsFrames_Frames
GO
ALTER TABLE dbo.CellsChanges
	DROP CONSTRAINT FK_CellsChanges_Frames
GO
ALTER TABLE dbo.CellsContents
	DROP CONSTRAINT FK_CellsContents_Frames
GO
ALTER TABLE dbo.CellsContentsSnapshotsBeg
	DROP CONSTRAINT FK_CellsContentsSnapshotsBeg_Frames
GO
ALTER TABLE dbo.CellsContentsSnapshotsEnd
	DROP CONSTRAINT FK_CellsContentsSnapshotsEnd_Frames
GO
ALTER TABLE dbo.InputsItems
	DROP CONSTRAINT FK_InputsItems_Frames
GO
ALTER TABLE dbo.InventoriesCells
	DROP CONSTRAINT FK_InventoriesCells_Frames
GO
DROP TABLE dbo.Frames
GO
EXECUTE sp_rename N'dbo.Tmp_Frames', N'Frames', 'OBJECT' 
GO
ALTER TABLE dbo.Frames ADD CONSTRAINT
	PK_Frames PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX IX_Frames_BarCode ON dbo.Frames
	(
	BarCode
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Frames_OwnerID ON dbo.Frames
	(
	OwnerID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Frames_GoodStateID ON dbo.Frames
	(
	GoodStateID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Frames_PalletTypeID ON dbo.Frames
	(
	PalletTypeID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Frames_ERPCode ON dbo.Frames
	(
	ERPCode
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.Frames ADD CONSTRAINT
	FK_Frames_GoodsStates FOREIGN KEY
	(
	GoodStateID
	) REFERENCES dbo.GoodsStates
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Frames ADD CONSTRAINT
	FK_Frames_PalletsTypes FOREIGN KEY
	(
	PalletTypeID
	) REFERENCES dbo.PalletsTypes
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
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
ALTER TABLE dbo.InventoriesCells ADD CONSTRAINT
	FK_InventoriesCells_Frames FOREIGN KEY
	(
	FrameID
	) REFERENCES dbo.Frames
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.InputsItems ADD CONSTRAINT
	FK_InputsItems_Frames FOREIGN KEY
	(
	FrameID
	) REFERENCES dbo.Frames
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CellsContentsSnapshotsEnd ADD CONSTRAINT
	FK_CellsContentsSnapshotsEnd_Frames FOREIGN KEY
	(
	FrameID
	) REFERENCES dbo.Frames
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CellsContentsSnapshotsBeg ADD CONSTRAINT
	FK_CellsContentsSnapshotsBeg_Frames FOREIGN KEY
	(
	FrameID
	) REFERENCES dbo.Frames
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CellsContents ADD CONSTRAINT
	FK_CellsContents_Frames FOREIGN KEY
	(
	FrameID
	) REFERENCES dbo.Frames
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CellsChanges ADD CONSTRAINT
	FK_CellsChanges_Frames FOREIGN KEY
	(
	FrameID
	) REFERENCES dbo.Frames
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TrafficsFrames ADD CONSTRAINT
	FK_TrafficsFrames_Frames FOREIGN KEY
	(
	FrameID
	) REFERENCES dbo.Frames
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.OutputsItems ADD CONSTRAINT
	FK_OutputsItems_Frames FOREIGN KEY
	(
	FrameID
	) REFERENCES dbo.Frames
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
