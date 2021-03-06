/*
   18 мая 2010 г.12:21:27
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
ALTER TABLE dbo.Inputs
	DROP CONSTRAINT FK_Inputs_Partners
GO
ALTER TABLE dbo.Inputs
	DROP CONSTRAINT FK_Inputs_PartnersOwners
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Inputs
	DROP CONSTRAINT FK_Inputs_Hosts
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Inputs
	DROP CONSTRAINT FK_Inputs_InputsTypes
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Inputs
	DROP CONSTRAINT FK_Inputs_GoodsStates
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Inputs
	DROP CONSTRAINT DF_Inputs_InputType
GO
ALTER TABLE dbo.Inputs
	DROP CONSTRAINT DF_Inputs_Partner
GO
ALTER TABLE dbo.Inputs
	DROP CONSTRAINT DF_Inputs_Owner
GO
ALTER TABLE dbo.Inputs
	DROP CONSTRAINT DF_Inputs_GoodState
GO
ALTER TABLE dbo.Inputs
	DROP CONSTRAINT DF_Inputs_Note
GO
ALTER TABLE dbo.Inputs
	DROP CONSTRAINT DF_Inputs_CoefficientUnload
GO
CREATE TABLE dbo.Tmp_Inputs
	(
	ID int NOT NULL IDENTITY (1, 1),
	DateInput smalldatetime NOT NULL,
	InputTypeID int NOT NULL,
	PartnerID int NOT NULL,
	OwnerID int NOT NULL,
	GoodStateID int NOT NULL,
	Note varchar(250) NOT NULL,
	DateStart smalldatetime NULL,
	DateConfirm smalldatetime NULL,
	ConfirmUserID int NULL,
	CoefficientUnload decimal(5, 1) NOT NULL,
	PalletsFactQnt int NOT NULL,
	OddmentSavedID int NULL,
	ERPCode varchar(50) NULL,
	ERPBarCode varchar(25) NULL,
	HostID int NOT NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'Дата прихода'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Inputs', N'COLUMN', N'DateInput'
GO
DECLARE @v sql_variant 
SET @v = N'Тип прихода'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Inputs', N'COLUMN', N'InputTypeID'
GO
DECLARE @v sql_variant 
SET @v = N'Поставщик'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Inputs', N'COLUMN', N'PartnerID'
GO
DECLARE @v sql_variant 
SET @v = N'Владелец товара'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Inputs', N'COLUMN', N'OwnerID'
GO
DECLARE @v sql_variant 
SET @v = N'Состояние товара'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Inputs', N'COLUMN', N'GoodStateID'
GO
DECLARE @v sql_variant 
SET @v = N'Примечания'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Inputs', N'COLUMN', N'Note'
GO
DECLARE @v sql_variant 
SET @v = N'Дата-время начала приемки'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Inputs', N'COLUMN', N'DateStart'
GO
DECLARE @v sql_variant 
SET @v = N'Дата и время подтверждения'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Inputs', N'COLUMN', N'DateConfirm'
GO
DECLARE @v sql_variant 
SET @v = N'Пользователь, выполнивший подтверждение'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Inputs', N'COLUMN', N'ConfirmUserID'
GO
DECLARE @v sql_variant 
SET @v = N'Коэффициент сложности разгрузки'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Inputs', N'COLUMN', N'CoefficientUnload'
GO
DECLARE @v sql_variant 
SET @v = N'Принято поддонов'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Inputs', N'COLUMN', N'PalletsFactQnt'
GO
DECLARE @v sql_variant 
SET @v = N'Сохраненные остатки'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Inputs', N'COLUMN', N'OddmentSavedID'
GO
DECLARE @v sql_variant 
SET @v = N'Код в учетной системе'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Inputs', N'COLUMN', N'ERPCode'
GO
DECLARE @v sql_variant 
SET @v = N'Штрих-код производственного задания'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Inputs', N'COLUMN', N'ERPBarCode'
GO
DECLARE @v sql_variant 
SET @v = N'Код хоста'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_Inputs', N'COLUMN', N'HostID'
GO
ALTER TABLE dbo.Tmp_Inputs ADD CONSTRAINT
	DF_Inputs_InputType DEFAULT ((0)) FOR InputTypeID
GO
ALTER TABLE dbo.Tmp_Inputs ADD CONSTRAINT
	DF_Inputs_Partner DEFAULT ((0)) FOR PartnerID
GO
ALTER TABLE dbo.Tmp_Inputs ADD CONSTRAINT
	DF_Inputs_Owner DEFAULT ((0)) FOR OwnerID
GO
ALTER TABLE dbo.Tmp_Inputs ADD CONSTRAINT
	DF_Inputs_GoodState DEFAULT ((0)) FOR GoodStateID
GO
ALTER TABLE dbo.Tmp_Inputs ADD CONSTRAINT
	DF_Inputs_Note DEFAULT ('') FOR Note
GO
ALTER TABLE dbo.Tmp_Inputs ADD CONSTRAINT
	DF_Inputs_CoefficientUnload DEFAULT ((1)) FOR CoefficientUnload
GO
ALTER TABLE dbo.Tmp_Inputs ADD CONSTRAINT
	DF_Inputs_PalletsFactQnt DEFAULT 0 FOR PalletsFactQnt
GO
SET IDENTITY_INSERT dbo.Tmp_Inputs ON
GO
IF EXISTS(SELECT * FROM dbo.Inputs)
	 EXEC('INSERT INTO dbo.Tmp_Inputs (ID, DateInput, InputTypeID, PartnerID, OwnerID, GoodStateID, Note, DateStart, DateConfirm, ConfirmUserID, CoefficientUnload, OddmentSavedID, ERPCode, ERPBarCode, HostID)
		SELECT ID, DateInput, InputTypeID, PartnerID, OwnerID, GoodStateID, Note, DateStart, DateConfirm, ConfirmUserID, CoefficientUnload, OddmentSavedID, ERPCode, ERPBarCode, HostID FROM dbo.Inputs WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Inputs OFF
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT FK_TrafficsGoods_Inputs
GO
ALTER TABLE dbo.TrafficsFrames
	DROP CONSTRAINT FK_TrafficsFrames_Inputs
GO
ALTER TABLE dbo.InputsUnloaders
	DROP CONSTRAINT FK_InputsUnloaders_Inputs
GO
ALTER TABLE dbo.InputsGoods
	DROP CONSTRAINT FK_InputsGoods_Inputs
GO
ALTER TABLE dbo.InputsItems
	DROP CONSTRAINT FK_InputsItems_Inputs
GO
DROP TABLE dbo.Inputs
GO
EXECUTE sp_rename N'dbo.Tmp_Inputs', N'Inputs', 'OBJECT' 
GO
ALTER TABLE dbo.Inputs ADD CONSTRAINT
	PK_Inputs PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX IX_Inputs_DateInput ON dbo.Inputs
	(
	DateInput
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Inputs_DateConfirm ON dbo.Inputs
	(
	DateConfirm
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Inputs_GoodStateID ON dbo.Inputs
	(
	GoodStateID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Inputs_OwnerID ON dbo.Inputs
	(
	OwnerID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Inputs_InputTypeID ON dbo.Inputs
	(
	InputTypeID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Inputs_PartnerID ON dbo.Inputs
	(
	PartnerID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Inputs_ERPCode ON dbo.Inputs
	(
	ERPCode
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Inputs_ERPBarCode ON dbo.Inputs
	(
	ERPBarCode
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_Inputs_HostID ON dbo.Inputs
	(
	HostID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.Inputs ADD CONSTRAINT
	FK_Inputs_GoodsStates FOREIGN KEY
	(
	GoodStateID
	) REFERENCES dbo.GoodsStates
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Inputs ADD CONSTRAINT
	FK_Inputs_InputsTypes FOREIGN KEY
	(
	InputTypeID
	) REFERENCES dbo.InputsTypes
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Inputs ADD CONSTRAINT
	FK_Inputs_Hosts FOREIGN KEY
	(
	HostID
	) REFERENCES dbo.Hosts
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
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
BEGIN TRANSACTION
GO
ALTER TABLE dbo.InputsItems ADD CONSTRAINT
	FK_InputsItems_Inputs FOREIGN KEY
	(
	InputID
	) REFERENCES dbo.Inputs
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.InputsGoods ADD CONSTRAINT
	FK_InputsGoods_Inputs FOREIGN KEY
	(
	InputID
	) REFERENCES dbo.Inputs
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
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
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TrafficsFrames ADD CONSTRAINT
	FK_TrafficsFrames_Inputs FOREIGN KEY
	(
	InputID
	) REFERENCES dbo.Inputs
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TrafficsGoods ADD CONSTRAINT
	FK_TrafficsGoods_Inputs FOREIGN KEY
	(
	InputID
	) REFERENCES dbo.Inputs
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
