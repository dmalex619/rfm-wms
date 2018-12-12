SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Shifts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateBeg] [smalldatetime] NOT NULL,
	[DateEnd] [smalldatetime] NOT NULL,
	[MajorID] [int] NOT NULL,
	[IsNight] [bit] NOT NULL,
	[Note] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Shifts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дата-время начала смены' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shifts', @level2type=N'COLUMN',@level2name=N'DateBeg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дата-время окончания смены' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shifts', @level2type=N'COLUMN',@level2name=N'DateEnd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Старший сотрудник в смене' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shifts', @level2type=N'COLUMN',@level2name=N'MajorID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ночная смена?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shifts', @level2type=N'COLUMN',@level2name=N'IsNight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Примечание' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shifts', @level2type=N'COLUMN',@level2name=N'Note'
GO

ALTER TABLE [dbo].[Shifts]  WITH CHECK ADD  CONSTRAINT [FK_Shifts__Users] FOREIGN KEY([MajorID])
REFERENCES [dbo].[_Users] ([ID])
GO
ALTER TABLE [dbo].[Shifts] CHECK CONSTRAINT [FK_Shifts__Users]
GO
ALTER TABLE [dbo].[Shifts] ADD  CONSTRAINT [DF_Shifts_Note]  DEFAULT ('') FOR [Note]
GO
