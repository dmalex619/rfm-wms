SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Hosts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ShortCode] [varchar](25) NOT NULL,
	[Password] [varchar](50) NOT NULL CONSTRAINT [DF_HostSystems_HostSystemPassword]  DEFAULT (''),
	[Actual] [bit] NOT NULL CONSTRAINT [DF_HostSystems_Actual]  DEFAULT ((1)),
 CONSTRAINT [PK_HostSystems] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Название хоста' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hosts', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Краткий код хоста' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hosts', @level2type=N'COLUMN',@level2name=N'ShortCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Пароль' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hosts', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Актуально?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hosts', @level2type=N'COLUMN',@level2name=N'Actual'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Список хост-систем' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hosts'