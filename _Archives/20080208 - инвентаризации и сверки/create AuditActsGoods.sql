USE [WMS]
GO
/****** Object:  Table [dbo].[AuditActsGoods]    Script Date: 02/08/2008 17:23:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AuditActsGoods](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AuditActID] [int] NOT NULL,
	[PackingID] [int] NOT NULL,
	[QntConfirmed] [decimal](12, 3) NOT NULL,
	[ERPCode] [varchar](50) NULL,
 CONSTRAINT [PK_AuditActsGoods] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Акт ревизии' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditActsGoods', @level2type=N'COLUMN',@level2name=N'AuditActID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Товар-упаковка' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditActsGoods', @level2type=N'COLUMN',@level2name=N'PackingID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Подтвержденное количество' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditActsGoods', @level2type=N'COLUMN',@level2name=N'QntConfirmed'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Код в учетной системе' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditActsGoods', @level2type=N'COLUMN',@level2name=N'ERPCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Расшифровки к актам ревизий' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditActsGoods'
GO
ALTER TABLE [dbo].[AuditActsGoods]  WITH CHECK ADD  CONSTRAINT [FK_AuditActsGoods_AuditActs] FOREIGN KEY([AuditActID])
REFERENCES [dbo].[AuditActs] ([ID])
GO
ALTER TABLE [dbo].[AuditActsGoods] CHECK CONSTRAINT [FK_AuditActsGoods_AuditActs]
GO
ALTER TABLE [dbo].[AuditActsGoods]  WITH CHECK ADD  CONSTRAINT [FK_AuditActsGoods_Packings] FOREIGN KEY([PackingID])
REFERENCES [dbo].[Packings] ([ID])
GO
ALTER TABLE [dbo].[AuditActsGoods] CHECK CONSTRAINT [FK_AuditActsGoods_Packings]