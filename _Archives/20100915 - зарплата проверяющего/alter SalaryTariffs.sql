/*
   16 сентября 2010 г.10:24:07
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
ALTER TABLE dbo.SalaryTariffs
	DROP CONSTRAINT DF_SalaryTariffs_InputsItemsRelativeCount
GO
ALTER TABLE dbo.SalaryTariffs
	DROP CONSTRAINT DF_SalaryTariffs_AccInputsOperationsCount
GO
ALTER TABLE dbo.SalaryTariffs
	DROP CONSTRAINT DF_SalaryTariffs_MovesUpOperationsCount
GO
ALTER TABLE dbo.SalaryTariffs
	DROP CONSTRAINT DF_SalaryTariffs_MovesDownOperationsCount
GO
ALTER TABLE dbo.SalaryTariffs
	DROP CONSTRAINT DF_SalaryTariffs_MovesFloorOperations
GO
ALTER TABLE dbo.SalaryTariffs
	DROP CONSTRAINT DF_SalaryTariffs_PickOutputsLinesCount
GO
ALTER TABLE dbo.SalaryTariffs
	DROP CONSTRAINT DF_SalaryTariffs_PickOutputsBoxes
GO
ALTER TABLE dbo.SalaryTariffs
	DROP CONSTRAINT DF_SalaryTariffs_PickOutputsNetto
GO
ALTER TABLE dbo.SalaryTariffs
	DROP CONSTRAINT DF_SalaryTariffs_OutputsLines
GO
ALTER TABLE dbo.SalaryTariffs
	DROP CONSTRAINT DF_SalaryTariffs_OutputsBoxesCount
GO
ALTER TABLE dbo.SalaryTariffs
	DROP CONSTRAINT DF_SalaryTariffs_OutputsNetto
GO
ALTER TABLE dbo.SalaryTariffs
	DROP CONSTRAINT DF_SalaryTariffs_MovingsBoxesCount
GO
ALTER TABLE dbo.SalaryTariffs
	DROP CONSTRAINT DF_SalaryTariffs_InventoriesCellsCount
GO
ALTER TABLE dbo.SalaryTariffs
	DROP CONSTRAINT DF_SalaryTariffs_UserID
GO
ALTER TABLE dbo.SalaryTariffs
	DROP CONSTRAINT DF_SalaryTariffs_DateInput
GO
CREATE TABLE dbo.Tmp_SalaryTariffs
	(
	ID int NOT NULL IDENTITY (1, 1),
	DateBeg smalldatetime NOT NULL,
	InputsItemsRelative money NOT NULL,
	AccInputsOperations money NOT NULL,
	MovesUpOperations money NOT NULL,
	MovesDownOperations money NOT NULL,
	MovesFloorOperations money NOT NULL,
	PickOutputsLines money NOT NULL,
	PickOutputsBoxes money NOT NULL,
	PickOutputsNetto money NOT NULL,
	OutputsLines money NOT NULL,
	OutputsBoxes money NOT NULL,
	OutputsNetto money NOT NULL,
	ValidateOutputsLines money NOT NULL,
	ValidateOutputsBoxes money NOT NULL,
	ValidateOutputsNetto money NOT NULL,
	MovingsBoxes money NOT NULL,
	InventoriesCells money NOT NULL,
	UserID int NOT NULL,
	DateInput smalldatetime NOT NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'Тарифы по видам работ'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'ID'
GO
DECLARE @v sql_variant 
SET @v = N'Дата начала действия'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'DateBeg'
GO
DECLARE @v sql_variant 
SET @v = N'Выгрузка (условная паллета)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'InputsItemsRelative'
GO
DECLARE @v sql_variant 
SET @v = N'Приход (операция)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'AccInputsOperations'
GO
DECLARE @v sql_variant 
SET @v = N'Подъем (паллета)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'MovesUpOperations'
GO
DECLARE @v sql_variant 
SET @v = N'Спуск (паллета)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'MovesDownOperations'
GO
DECLARE @v sql_variant 
SET @v = N'Перемещение (паллета)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'MovesFloorOperations'
GO
DECLARE @v sql_variant 
SET @v = N'Пикинг (строка)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'PickOutputsLines'
GO
DECLARE @v sql_variant 
SET @v = N'Пикинг (коробка, не весовой товар)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'PickOutputsBoxes'
GO
DECLARE @v sql_variant 
SET @v = N'Пикинг (кг, весовой товар)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'PickOutputsNetto'
GO
DECLARE @v sql_variant 
SET @v = N'Отгрузка (строк)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'OutputsLines'
GO
DECLARE @v sql_variant 
SET @v = N'Отгрузка (корбка, невесовой товар)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'OutputsBoxes'
GO
DECLARE @v sql_variant 
SET @v = N'Отгрузка (кг, весовой товар)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'OutputsNetto'
GO
DECLARE @v sql_variant 
SET @v = N'Проверка загрузки в машину (строка)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'ValidateOutputsLines'
GO
DECLARE @v sql_variant 
SET @v = N'Проверка загрузки в машину (коробка, невесовой товар)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'ValidateOutputsBoxes'
GO
DECLARE @v sql_variant 
SET @v = N'Проверка загрузки в машину (кг, весовой товар)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'ValidateOutputsNetto'
GO
DECLARE @v sql_variant 
SET @v = N'Перемещение (коробка)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'MovingsBoxes'
GO
DECLARE @v sql_variant 
SET @v = N'Ревизия (ячейка)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_SalaryTariffs', N'COLUMN', N'InventoriesCells'
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_InputsItemsRelativeCount DEFAULT ((0)) FOR InputsItemsRelative
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_AccInputsOperationsCount DEFAULT ((0)) FOR AccInputsOperations
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_MovesUpOperationsCount DEFAULT ((0)) FOR MovesUpOperations
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_MovesDownOperationsCount DEFAULT ((0)) FOR MovesDownOperations
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_MovesFloorOperations DEFAULT ((0)) FOR MovesFloorOperations
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_PickOutputsLinesCount DEFAULT ((0)) FOR PickOutputsLines
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_PickOutputsBoxes DEFAULT ((0)) FOR PickOutputsBoxes
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_PickOutputsNetto DEFAULT ((0)) FOR PickOutputsNetto
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_OutputsLines DEFAULT ((0)) FOR OutputsLines
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_OutputsBoxesCount DEFAULT ((0)) FOR OutputsBoxes
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_OutputsNetto DEFAULT ((0)) FOR OutputsNetto
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_ValidateOutputsLines DEFAULT 0 FOR ValidateOutputsLines
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_ValidateOutputsBoxes DEFAULT 0 FOR ValidateOutputsBoxes
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_ValidateOutputsNetto DEFAULT 0 FOR ValidateOutputsNetto
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_MovingsBoxesCount DEFAULT ((0)) FOR MovingsBoxes
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_InventoriesCellsCount DEFAULT ((0)) FOR InventoriesCells
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_UserID DEFAULT ((0)) FOR UserID
GO
ALTER TABLE dbo.Tmp_SalaryTariffs ADD CONSTRAINT
	DF_SalaryTariffs_DateInput DEFAULT (getdate()) FOR DateInput
GO
SET IDENTITY_INSERT dbo.Tmp_SalaryTariffs ON
GO
IF EXISTS(SELECT * FROM dbo.SalaryTariffs)
	 EXEC('INSERT INTO dbo.Tmp_SalaryTariffs (ID, DateBeg, InputsItemsRelative, AccInputsOperations, MovesUpOperations, MovesDownOperations, MovesFloorOperations, PickOutputsLines, PickOutputsBoxes, PickOutputsNetto, OutputsLines, OutputsBoxes, OutputsNetto, MovingsBoxes, InventoriesCells, UserID, DateInput)
		SELECT ID, DateBeg, InputsItemsRelative, AccInputsOperations, MovesUpOperations, MovesDownOperations, MovesFloorOperations, PickOutputsLines, PickOutputsBoxes, PickOutputsNetto, OutputsLines, OutputsBoxes, OutputsNetto, MovingsBoxes, InventoriesCells, UserID, DateInput FROM dbo.SalaryTariffs WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_SalaryTariffs OFF
GO
DROP TABLE dbo.SalaryTariffs
GO
EXECUTE sp_rename N'dbo.Tmp_SalaryTariffs', N'SalaryTariffs', 'OBJECT' 
GO
ALTER TABLE dbo.SalaryTariffs ADD CONSTRAINT
	PK_SalaryTariffs PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
