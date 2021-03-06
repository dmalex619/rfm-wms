/*
   18 сентября 2008 г.10:31:38
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
ALTER TABLE dbo.Outputs
	DROP CONSTRAINT FK_Outputs_OutputsTypes
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Outputs
	DROP CONSTRAINT FK_Outputs_GoodsStates
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Outputs
	DROP CONSTRAINT FK_Outputs_Partners
GO
ALTER TABLE dbo.Outputs
	DROP CONSTRAINT FK_Outputs_PartnersOwners
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Outputs
	DROP CONSTRAINT DF_Outputs_GoodState
GO
ALTER TABLE dbo.Outputs
	DROP CONSTRAINT DF_Outputs_Note
GO
ALTER TABLE dbo.Outputs
	DROP CONSTRAINT DF_Outputs_CarAlias
GO
ALTER TABLE dbo.Outputs
	DROP CONSTRAINT DF_Outputs_BackDoor
GO
ALTER TABLE dbo.Outputs
	DROP CONSTRAINT DF_Outputs_ChargeOrder
GO
CREATE TABLE dbo.Tmp_Outputs
	(
	ID int NOT NULL IDENTITY (1, 1),
	DateOutput smalldatetime NOT NULL,
	OutputTypeID int NOT NULL,
	PartnerID int NOT NULL,
	OwnerID int NOT NULL,
	GoodStateID int NOT NULL,
	CellID int NULL,
	Note varchar(250) NOT NULL,
	CarAlias varchar(50) NOT NULL,
	BackDoor bit NOT NULL,
	ChargeOrder varchar(50) NOT NULL,
	DateStart smalldatetime NULL,
	DateSelect smalldatetime NULL,
	DatePrint smalldatetime NULL,
	DatePick smalldatetime NULL,
	DateConfirm smalldatetime NULL,
	ConfirmUserID int NULL,
	CoefficientLoad decimal(5, 1) NOT NULL,
	OddmentSavedID int NULL,
	ERPCode varchar(50) NULL,
	ERPBarCode varchar(25) NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'Дата расхода'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'DateOutput'
GO
DECLARE @v sql_variant 
SET @v = N'Тип расхода'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'OutputTypeID'
GO
DECLARE @v sql_variant 
SET @v = N'Владелец товара'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'OwnerID'
GO
DECLARE @v sql_variant 
SET @v = N'Состояние товара'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'GoodStateID'
GO
DECLARE @v sql_variant 
SET @v = N'Ячейка отгрузки'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'CellID'
GO
DECLARE @v sql_variant 
SET @v = N'Примечания'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'Note'
GO
DECLARE @v sql_variant 
SET @v = N'Машина'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'CarAlias'
GO
DECLARE @v sql_variant 
SET @v = N'Признак задней двери'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'BackDoor'
GO
DECLARE @v sql_variant 
SET @v = N'Порядок загрузки'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'ChargeOrder'
GO
DECLARE @v sql_variant 
SET @v = N'Дата-время начала отгрузки'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'DateStart'
GO
DECLARE @v sql_variant 
SET @v = N'Признак окончания сбора товаров'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'DateSelect'
GO
DECLARE @v sql_variant 
SET @v = N'Дата-время печати листа набора'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'DatePrint'
GO
DECLARE @v sql_variant 
SET @v = N'Дата-время полного сбора товаров в ячейке отгрузки'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'DatePick'
GO
DECLARE @v sql_variant 
SET @v = N'Дата и время подтверждения'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'DateConfirm'
GO
DECLARE @v sql_variant 
SET @v = N'Пользователь, выполнивший подтверждение'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'ConfirmUserID'
GO
DECLARE @v sql_variant 
SET @v = N'Коэффициент сложности загрузки'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'CoefficientLoad'
GO
DECLARE @v sql_variant 
SET @v = N'Сохраненные остатки'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'OddmentSavedID'
GO
DECLARE @v sql_variant 
SET @v = N'Код в учетной системе'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'ERPCode'
GO
DECLARE @v sql_variant 
SET @v = N'Штрих-код производственного задания'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Outputs', N'COLUMN', N'ERPBarCode'
GO
ALTER TABLE dbo.Tmp_Outputs ADD CONSTRAINT
	DF_Outputs_GoodState DEFAULT ((0)) FOR GoodStateID
GO
ALTER TABLE dbo.Tmp_Outputs ADD CONSTRAINT
	DF_Outputs_Note DEFAULT ('') FOR Note
GO
ALTER TABLE dbo.Tmp_Outputs ADD CONSTRAINT
	DF_Outputs_CarAlias DEFAULT ('') FOR CarAlias
GO
ALTER TABLE dbo.Tmp_Outputs ADD CONSTRAINT
	DF_Outputs_BackDoor DEFAULT ((0)) FOR BackDoor
GO
ALTER TABLE dbo.Tmp_Outputs ADD CONSTRAINT
	DF_Outputs_ChargeOrder DEFAULT ('') FOR ChargeOrder
GO
ALTER TABLE dbo.Tmp_Outputs ADD CONSTRAINT
	DF_Outputs_CoefficientLoad DEFAULT 1 FOR CoefficientLoad
GO
SET IDENTITY_INSERT dbo.Tmp_Outputs ON
GO
IF EXISTS(SELECT * FROM dbo.Outputs)
	 EXEC('INSERT INTO dbo.Tmp_Outputs (ID, DateOutput, OutputTypeID, PartnerID, OwnerID, GoodStateID, CellID, Note, CarAlias, BackDoor, ChargeOrder, DateStart, DateSelect, DatePrint, DatePick, DateConfirm, ConfirmUserID, OddmentSavedID, ERPCode, ERPBarCode)
		SELECT ID, DateOutput, OutputTypeID, PartnerID, OwnerID, GoodStateID, CellID, Note, CarAlias, BackDoor, ChargeOrder, DateStart, DateSelect, DatePrint, DatePick, DateConfirm, ConfirmUserID, OddmentSavedID, ERPCode, ERPBarCode FROM dbo.Outputs WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Outputs OFF
GO
ALTER TABLE dbo.OutputsGoods
	DROP CONSTRAINT FK_OutputsGoods_Outputs
GO
ALTER TABLE dbo.TrafficsFrames
	DROP CONSTRAINT FK_TrafficsFrames_Outputs
GO
ALTER TABLE dbo.OutputsItems
	DROP CONSTRAINT FK_OutputsItems_Outputs
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT FK_TrafficsGoods_Outputs
GO
DROP TABLE dbo.Outputs
GO
EXECUTE sp_rename N'dbo.Tmp_Outputs', N'Outputs', 'OBJECT' 
GO
ALTER TABLE dbo.Outputs ADD CONSTRAINT
	PK_Outputs PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX IX_Outputs_DateOutput ON dbo.Outputs
	(
	DateOutput
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Outputs_DateConfirm ON dbo.Outputs
	(
	DateConfirm
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Outputs_GoodStateID ON dbo.Outputs
	(
	GoodStateID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Outputs_OwnerID ON dbo.Outputs
	(
	OwnerID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
ALTER TABLE dbo.Outputs ADD CONSTRAINT
	FK_Outputs_GoodsStates FOREIGN KEY
	(
	GoodStateID
	) REFERENCES dbo.GoodsStates
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Outputs ADD CONSTRAINT
	FK_Outputs_OutputsTypes FOREIGN KEY
	(
	OutputTypeID
	) REFERENCES dbo.OutputsTypes
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TrafficsGoods ADD CONSTRAINT
	FK_TrafficsGoods_Outputs FOREIGN KEY
	(
	OutputID
	) REFERENCES dbo.Outputs
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.OutputsItems ADD CONSTRAINT
	FK_OutputsItems_Outputs FOREIGN KEY
	(
	OutputID
	) REFERENCES dbo.Outputs
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TrafficsFrames ADD CONSTRAINT
	FK_TrafficsFrames_Outputs FOREIGN KEY
	(
	OutputID
	) REFERENCES dbo.Outputs
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.OutputsGoods ADD CONSTRAINT
	FK_OutputsGoods_Outputs FOREIGN KEY
	(
	OutputID
	) REFERENCES dbo.Outputs
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
