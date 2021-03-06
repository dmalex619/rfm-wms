SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Complexes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL CONSTRAINT [DF_Complexes_Name]  DEFAULT (''),
	[Alias] [varchar](25) COLLATE Cyrillic_General_CI_AS NOT NULL CONSTRAINT [DF_Complexes_Alias]  DEFAULT (''),
	[Actual] [bit] NOT NULL CONSTRAINT [DF_Complexes_Actual]  DEFAULT ((1)),
	[ERPCode] [varchar](50) COLLATE Cyrillic_General_CI_AS NULL,
 CONSTRAINT [PK_Complexes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Название физ.склада' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Complexes', @level2type=N'COLUMN', @level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Название физ.склада - краткое' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Complexes', @level2type=N'COLUMN', @level2name=N'Alias'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Актуально?' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Complexes', @level2type=N'COLUMN', @level2name=N'Actual'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Код в учетной системе' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Complexes', @level2type=N'COLUMN', @level2name=N'ERPCode'

BEGIN TRANSACTION
GO
CREATE NONCLUSTERED INDEX IX_Complexes_ERPCode ON dbo.Complexes
	(
	ERPCode
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.Complexes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
