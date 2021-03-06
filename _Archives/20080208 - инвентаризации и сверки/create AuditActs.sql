USE [WMS]
GO
/****** Object:  Table [dbo].[AuditActs]    Script Date: 02/08/2008 17:23:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AuditActs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateAudit] [smalldatetime] NOT NULL,
	[OwnerID] [int] NOT NULL,
	[GoodStateID] [int] NOT NULL,
	[Note] [varchar](250) NOT NULL,
	[DateConfirm] [smalldatetime] NOT NULL,
	[OddmentSavedID] [int] NULL,
	[ERPCode] [varchar](50) NULL,
 CONSTRAINT [PK_AuditActs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дата ввода акта ревизии' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditActs', @level2type=N'COLUMN',@level2name=N'DateAudit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Владелец товара' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditActs', @level2type=N'COLUMN',@level2name=N'OwnerID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Состояние товара' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditActs', @level2type=N'COLUMN',@level2name=N'GoodStateID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Примечание' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditActs', @level2type=N'COLUMN',@level2name=N'Note'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дата автоматического проведения' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditActs', @level2type=N'COLUMN',@level2name=N'DateConfirm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Сохраненные остатки' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditActs', @level2type=N'COLUMN',@level2name=N'OddmentSavedID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Код в учетной системе' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditActs', @level2type=N'COLUMN',@level2name=N'ERPCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Акты ревизий' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditActs'
GO
ALTER TABLE [dbo].[AuditActs]  WITH CHECK ADD  CONSTRAINT [FK_AuditActs_GoodsStates] FOREIGN KEY([GoodStateID])
REFERENCES [dbo].[GoodsStates] ([ID])
GO
ALTER TABLE [dbo].[AuditActs] CHECK CONSTRAINT [FK_AuditActs_GoodsStates]
GO
ALTER TABLE [dbo].[AuditActs]  WITH CHECK ADD  CONSTRAINT [FK_AuditActs_PartnersOwners] FOREIGN KEY([OwnerID])
REFERENCES [dbo].[Partners] ([ID])
GO
ALTER TABLE [dbo].[AuditActs] CHECK CONSTRAINT [FK_AuditActs_PartnersOwners]