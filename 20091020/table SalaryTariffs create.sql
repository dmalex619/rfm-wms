SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaryTariffs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateBeg] [smalldatetime] NOT NULL,
	[InputsItemsRelative] [money] NOT NULL CONSTRAINT [DF_SalaryTariffs_InputsItemsRelativeCount]  DEFAULT ((0)),
	[AccInputsOperations] [money] NOT NULL CONSTRAINT [DF_SalaryTariffs_AccInputsOperationsCount]  DEFAULT ((0)),
	[MovesUpOperations] [money] NOT NULL CONSTRAINT [DF_SalaryTariffs_MovesUpOperationsCount]  DEFAULT ((0)),
	[MovesDownOperations] [money] NOT NULL CONSTRAINT [DF_SalaryTariffs_MovesDownOperationsCount]  DEFAULT ((0)),
	[MovesFloorOperations] [money] NOT NULL CONSTRAINT [DF_SalaryTariffs_MovesFloorOperations]  DEFAULT ((0)),
	[PickOutputsLines] [money] NOT NULL CONSTRAINT [DF_SalaryTariffs_PickOutputsLinesCount]  DEFAULT ((0)),
	[PickOutputsBoxes] [money] NOT NULL CONSTRAINT [DF_SalaryTariffs_PickOutputsBoxes]  DEFAULT ((0)),
	[PickOutputsNetto] [money] NOT NULL CONSTRAINT [DF_SalaryTariffs_PickOutputsNetto]  DEFAULT ((0)),
	[OutputsLines] [money] NOT NULL CONSTRAINT [DF_SalaryTariffs_OutputsLines]  DEFAULT ((0)),
	[OutputsBoxes] [money] NOT NULL CONSTRAINT [DF_SalaryTariffs_OutputsBoxesCount]  DEFAULT ((0)),
	[OutputsNetto] [money] NOT NULL CONSTRAINT [DF_SalaryTariffs_OutputsNetto]  DEFAULT ((0)),
	[MovingsBoxes] [money] NOT NULL CONSTRAINT [DF_SalaryTariffs_MovingsBoxesCount]  DEFAULT ((0)),
	[InventoriesCells] [money] NOT NULL CONSTRAINT [DF_SalaryTariffs_InventoriesCellsCount]  DEFAULT ((0)),
	[UserID] [int] NOT NULL CONSTRAINT [DF_SalaryTariffs_UserID]  DEFAULT ((0)),
	[DateInput] [smalldatetime] NOT NULL CONSTRAINT [DF_SalaryTariffs_DateInput]  DEFAULT (getdate()),
 CONSTRAINT [PK_SalaryTariffs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Тарифы по видам работ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryTariffs', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дата начала действия' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryTariffs', @level2type=N'COLUMN', @level2name=N'DateBeg'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Выгрузка (условная паллета)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryTariffs', @level2type=N'COLUMN', @level2name=N'InputsItemsRelative'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Приход (операция)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryTariffs', @level2type=N'COLUMN', @level2name=N'AccInputsOperations'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Подъем (паллета)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryTariffs', @level2type=N'COLUMN', @level2name=N'MovesUpOperations'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Спуск (паллета)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryTariffs', @level2type=N'COLUMN', @level2name=N'MovesDownOperations'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Перемещение (паллета)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryTariffs', @level2type=N'COLUMN', @level2name=N'MovesFloorOperations'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Пикинг (строка)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryTariffs', @level2type=N'COLUMN', @level2name=N'PickOutputsLines'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Пикинг (коробка, не весовой товар)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryTariffs', @level2type=N'COLUMN', @level2name=N'PickOutputsBoxes'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Пикинг (кг, весовой товар)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryTariffs', @level2type=N'COLUMN', @level2name=N'PickOutputsNetto'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Отгрузка (строк)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryTariffs', @level2type=N'COLUMN', @level2name=N'OutputsLines'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Отгрузка (корбка, невесовой товар)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryTariffs', @level2type=N'COLUMN', @level2name=N'OutputsBoxes'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Отгрузка (кг, весовой товар)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryTariffs', @level2type=N'COLUMN', @level2name=N'OutputsNetto'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Перемещение (коробка)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryTariffs', @level2type=N'COLUMN', @level2name=N'MovingsBoxes'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ревизия (ячейка)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryTariffs', @level2type=N'COLUMN', @level2name=N'InventoriesCells'
