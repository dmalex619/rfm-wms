/*
   28 июня 2010 г.14:58:39
   Пользователь: 
   Сервер: (local)
   База данных: WMS_MBK
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
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT FK_TrafficsGoods_TrafficsGoodsErrors
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT FK_TrafficsGoods_Packings
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT FK_TrafficsGoods_Movings
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT FK_TrafficsGoods_GoodsStates
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT FK_TrafficsGoods_Devices
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT FK_TrafficsGoods_CellSource
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT FK_TrafficsGoods_CellTarget
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT FK_TrafficsGoods__Users
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT FK_TrafficsGoods_OutputsGoods
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT FK_TrafficsGoods_Partners
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT FK_TrafficsGoods_Outputs
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT FK_TrafficsGoods_Inputs
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT DF_TrafficsGoods_QntWished
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT DF_TrafficsGoods_QntConfirmed
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT DF_TrafficsGoods_Critical
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT DF_TrafficsGoods_Priority
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT DF_TrafficsGoods_DateBirth
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT DF_TrafficsGoods_Success
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT DF_TrafficsGoods_Note
GO
ALTER TABLE dbo.TrafficsGoods
	DROP CONSTRAINT DF_TrafficsGoods_ByOrder
GO
CREATE TABLE dbo.Tmp_TrafficsGoods
	(
	ID int NOT NULL IDENTITY (1, 1),
	OwnerID int NULL,
	GoodStateID int NOT NULL,
	PackingID int NOT NULL,
	QntWished numeric(12, 3) NOT NULL,
	QntConfirmed numeric(12, 3) NOT NULL,
	DateValid smalldatetime NULL,
	Critical bit NOT NULL,
	CellSourceID int NOT NULL,
	CellTargetID int NOT NULL,
	FrameID int NULL,
	Priority int NOT NULL,
	InputID int NULL,
	OutputID int NULL,
	MovingID int NULL,
	DateBirth smalldatetime NOT NULL,
	DateSend smalldatetime NULL,
	DateAccept smalldatetime NULL,
	DatePrint smalldatetime NULL,
	DateConfirm smalldatetime NULL,
	UserID int NULL,
	DeviceID int NULL,
	Success bit NOT NULL,
	ErrorID int NULL,
	Note varchar(250) NOT NULL,
	ByOrder int NOT NULL,
	OutputGoodID int NULL,
	ERPCode varchar(50) NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'Владелец'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'OwnerID'
GO
DECLARE @v sql_variant 
SET @v = N'Состояние товара'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'GoodStateID'
GO
DECLARE @v sql_variant 
SET @v = N'Упаковка'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'PackingID'
GO
DECLARE @v sql_variant 
SET @v = N'Ожидаемое кол-во, шт.'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'QntWished'
GO
DECLARE @v sql_variant 
SET @v = N'Фактическое кол-во, шт'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'QntConfirmed'
GO
DECLARE @v sql_variant 
SET @v = N'Срок годности (не менее)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'DateValid'
GO
DECLARE @v sql_variant 
SET @v = N'Критичность'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'Critical'
GO
DECLARE @v sql_variant 
SET @v = N'Ячейка-источник'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'CellSourceID'
GO
DECLARE @v sql_variant 
SET @v = N'Ячейка-получатель'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'CellTargetID'
GO
DECLARE @v sql_variant 
SET @v = N'Контейнер, из которого изымаются коробки'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'FrameID'
GO
DECLARE @v sql_variant 
SET @v = N'Приоритет задания'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'Priority'
GO
DECLARE @v sql_variant 
SET @v = N'Код прихода'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'InputID'
GO
DECLARE @v sql_variant 
SET @v = N'Код отгрузки'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'OutputID'
GO
DECLARE @v sql_variant 
SET @v = N'Код внутрискладского перемещения'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'MovingID'
GO
DECLARE @v sql_variant 
SET @v = N'Дата и время формирования задания'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'DateBirth'
GO
DECLARE @v sql_variant 
SET @v = N'Дата и время отправки задания для выполнения'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'DateSend'
GO
DECLARE @v sql_variant 
SET @v = N'Дата и время отклика пользователя'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'DateAccept'
GO
DECLARE @v sql_variant 
SET @v = N'Дата печати пиклиста'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'DatePrint'
GO
DECLARE @v sql_variant 
SET @v = N'Дата и время окончания операции'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'DateConfirm'
GO
DECLARE @v sql_variant 
SET @v = N'Пользователь'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'UserID'
GO
DECLARE @v sql_variant 
SET @v = N'Устройство'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'DeviceID'
GO
DECLARE @v sql_variant 
SET @v = N'Признак успешности'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'Success'
GO
DECLARE @v sql_variant 
SET @v = N'Код ошибки, если она произошла'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'ErrorID'
GO
DECLARE @v sql_variant 
SET @v = N'Примечание'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'Note'
GO
DECLARE @v sql_variant 
SET @v = N'Последовательность выполнения для одного элемента'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'ByOrder'
GO
DECLARE @v sql_variant 
SET @v = N'Код расшифровки отгрузки'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'OutputGoodID'
GO
DECLARE @v sql_variant 
SET @v = N'Код в учетной системе'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_TrafficsGoods', N'COLUMN', N'ERPCode'
GO
ALTER TABLE dbo.Tmp_TrafficsGoods ADD CONSTRAINT
	DF_TrafficsGoods_QntWished DEFAULT ((0)) FOR QntWished
GO
ALTER TABLE dbo.Tmp_TrafficsGoods ADD CONSTRAINT
	DF_TrafficsGoods_QntConfirmed DEFAULT ((0)) FOR QntConfirmed
GO
ALTER TABLE dbo.Tmp_TrafficsGoods ADD CONSTRAINT
	DF_TrafficsGoods_Critical DEFAULT ((0)) FOR Critical
GO
ALTER TABLE dbo.Tmp_TrafficsGoods ADD CONSTRAINT
	DF_TrafficsGoods_Priority DEFAULT ((5)) FOR Priority
GO
ALTER TABLE dbo.Tmp_TrafficsGoods ADD CONSTRAINT
	DF_TrafficsGoods_DateBirth DEFAULT (getdate()) FOR DateBirth
GO
ALTER TABLE dbo.Tmp_TrafficsGoods ADD CONSTRAINT
	DF_TrafficsGoods_Success DEFAULT ((0)) FOR Success
GO
ALTER TABLE dbo.Tmp_TrafficsGoods ADD CONSTRAINT
	DF_TrafficsGoods_Note DEFAULT ('') FOR Note
GO
ALTER TABLE dbo.Tmp_TrafficsGoods ADD CONSTRAINT
	DF_TrafficsGoods_ByOrder DEFAULT ((0)) FOR ByOrder
GO
SET IDENTITY_INSERT dbo.Tmp_TrafficsGoods ON
GO
IF EXISTS(SELECT * FROM dbo.TrafficsGoods)
	 EXEC('INSERT INTO dbo.Tmp_TrafficsGoods (ID, OwnerID, GoodStateID, PackingID, QntWished, QntConfirmed, DateValid, Critical, CellSourceID, CellTargetID, Priority, InputID, OutputID, MovingID, DateBirth, DateSend, DateAccept, DatePrint, DateConfirm, UserID, DeviceID, Success, ErrorID, Note, ByOrder, OutputGoodID, ERPCode)
		SELECT ID, OwnerID, GoodStateID, PackingID, QntWished, QntConfirmed, DateValid, Critical, CellSourceID, CellTargetID, Priority, InputID, OutputID, MovingID, DateBirth, DateSend, DateAccept, DatePrint, DateConfirm, UserID, DeviceID, Success, ErrorID, Note, ByOrder, OutputGoodID, ERPCode FROM dbo.TrafficsGoods WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_TrafficsGoods OFF
GO
DROP TABLE dbo.TrafficsGoods
GO
EXECUTE sp_rename N'dbo.Tmp_TrafficsGoods', N'TrafficsGoods', 'OBJECT' 
GO
ALTER TABLE dbo.TrafficsGoods ADD CONSTRAINT
	PK_TrafficsGoods PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX IX_TrafficsGoods_InputID ON dbo.TrafficsGoods
	(
	InputID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_TrafficsGoods_OutputID ON dbo.TrafficsGoods
	(
	OutputID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_TrafficsGoods_DateConfirm ON dbo.TrafficsGoods
	(
	DateConfirm
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_TrafficsGoods_MovingID ON dbo.TrafficsGoods
	(
	MovingID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_TrafficsGoods_CellSourceID ON dbo.TrafficsGoods
	(
	CellSourceID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_TrafficsGoods_CellTargetID ON dbo.TrafficsGoods
	(
	CellTargetID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_TrafficsGoods_PackingID ON dbo.TrafficsGoods
	(
	PackingID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_TrafficsGoods_OutputGoodID ON dbo.TrafficsGoods
	(
	OutputGoodID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_TrafficsGoods_OwnerID ON dbo.TrafficsGoods
	(
	OwnerID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_TrafficsGoods_GoodStateID ON dbo.TrafficsGoods
	(
	GoodStateID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_TrafficsGoods_DateBirth ON dbo.TrafficsGoods
	(
	DateBirth
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
ALTER TABLE dbo.TrafficsGoods ADD CONSTRAINT
	FK_TrafficsGoods_OutputsGoods FOREIGN KEY
	(
	OutputGoodID
	) REFERENCES dbo.OutputsGoods
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TrafficsGoods ADD CONSTRAINT
	FK_TrafficsGoods__Users FOREIGN KEY
	(
	UserID
	) REFERENCES dbo._Users
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TrafficsGoods ADD CONSTRAINT
	FK_TrafficsGoods_CellSource FOREIGN KEY
	(
	CellSourceID
	) REFERENCES dbo.Cells
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TrafficsGoods ADD CONSTRAINT
	FK_TrafficsGoods_CellTarget FOREIGN KEY
	(
	CellTargetID
	) REFERENCES dbo.Cells
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TrafficsGoods ADD CONSTRAINT
	FK_TrafficsGoods_Devices FOREIGN KEY
	(
	DeviceID
	) REFERENCES dbo.Devices
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TrafficsGoods ADD CONSTRAINT
	FK_TrafficsGoods_GoodsStates FOREIGN KEY
	(
	GoodStateID
	) REFERENCES dbo.GoodsStates
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TrafficsGoods ADD CONSTRAINT
	FK_TrafficsGoods_Movings FOREIGN KEY
	(
	MovingID
	) REFERENCES dbo.Movings
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TrafficsGoods ADD CONSTRAINT
	FK_TrafficsGoods_Packings FOREIGN KEY
	(
	PackingID
	) REFERENCES dbo.Packings
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TrafficsGoods ADD CONSTRAINT
	FK_TrafficsGoods_TrafficsGoodsErrors FOREIGN KEY
	(
	ErrorID
	) REFERENCES dbo.TrafficsGoodsErrors
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT



CREATE NONCLUSTERED INDEX IX_TrafficsGoods_FrameID ON dbo.TrafficsGoods (FrameID) 
	WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
