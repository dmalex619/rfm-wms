USE [WMS]
GO
/****** Object:  Table [dbo].[Inventories]    Script Date: 02/08/2008 16:13:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Inventories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateInventory] [smalldatetime] NOT NULL CONSTRAINT [DF_Inventories_DateInventory]  DEFAULT (getdate()),
	[Note] [varchar](250) NOT NULL CONSTRAINT [DF_Inventories_Note]  DEFAULT (''),
	[BarCode]  AS ('RV.'+replace(str([ID],(10)),' ','0')),
	[DateStart] [smalldatetime] NULL,
	[DateConfirm] [smalldatetime] NULL,
	[ERPCode] [varchar](50) NULL,
 CONSTRAINT [PK_Inventories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дата и время создания' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventories', @level2type=N'COLUMN',@level2name=N'DateInventory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Примечание' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventories', @level2type=N'COLUMN',@level2name=N'Note'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дата и время начала работы' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventories', @level2type=N'COLUMN',@level2name=N'DateStart'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дата и время подтверждения' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventories', @level2type=N'COLUMN',@level2name=N'DateConfirm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Код в учетной системе' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventories', @level2type=N'COLUMN',@level2name=N'ERPCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Задания на инвентаризацию' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventories'