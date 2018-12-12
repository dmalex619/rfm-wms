SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SalaryExtraWorks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateWork] [smalldatetime] NOT NULL CONSTRAINT [DF_SalaryExtraWorks_DateWork]  DEFAULT (getdate()),
	[UserID] [int] NOT NULL CONSTRAINT [DF_SalaryExtraWorks_UserID]  DEFAULT ((0)),
	[WorkName] [varchar](250) COLLATE Cyrillic_General_CI_AS NOT NULL CONSTRAINT [DF_SalaryExtraWorks_WorkName]  DEFAULT (''),
	[Qnt] [decimal](6, 1) NOT NULL CONSTRAINT [DF_SalaryExtraWorks_Qnt]  DEFAULT ((0)),
	[Price] [money] NOT NULL CONSTRAINT [DF_SalaryExtraWorks_Price]  DEFAULT ((0)),
	[Note] [varchar](250) COLLATE Cyrillic_General_CI_AS NOT NULL CONSTRAINT [DF_SalaryExtraWorks_Note]  DEFAULT (''),
	[ERPCode] [varchar](50) COLLATE Cyrillic_General_CI_AS NULL,
 CONSTRAINT [PK_SalaryExtraWorks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дополнительные внутрискладские работы' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryExtraWorks', @level2type=N'COLUMN', @level2name=N'ID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дата выполнения работ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryExtraWorks', @level2type=N'COLUMN', @level2name=N'DateWork'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Сотрудник, выполнявший работы (код)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryExtraWorks', @level2type=N'COLUMN', @level2name=N'UserID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Название работ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryExtraWorks', @level2type=N'COLUMN', @level2name=N'WorkName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Количество' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryExtraWorks', @level2type=N'COLUMN', @level2name=N'Qnt'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Тариф (стоимость за единицу работ)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryExtraWorks', @level2type=N'COLUMN', @level2name=N'Price'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Примечание' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryExtraWorks', @level2type=N'COLUMN', @level2name=N'Note'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Код в host-системе' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'SalaryExtraWorks', @level2type=N'COLUMN', @level2name=N'ERPCode'
