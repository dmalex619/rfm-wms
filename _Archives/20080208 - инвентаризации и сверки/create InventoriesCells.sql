USE [WMS]
GO
/****** Object:  Table [dbo].[InventoriesCells]    Script Date: 02/08/2008 16:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoriesCells](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InventoryID] [int] NOT NULL,
	[CellID] [int] NOT NULL,
	[UserID] [int] NULL,
	[Success] [bit] NULL,
 CONSTRAINT [PK_InventoriesCells] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Код инвентаризации' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoriesCells', @level2type=N'COLUMN',@level2name=N'InventoryID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ячейка' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoriesCells', @level2type=N'COLUMN',@level2name=N'CellID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Пользователь' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoriesCells', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Признак успешности завершения' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoriesCells', @level2type=N'COLUMN',@level2name=N'Success'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Список ячеек для инвентаризации' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoriesCells'
GO
ALTER TABLE [dbo].[InventoriesCells]  WITH CHECK ADD  CONSTRAINT [FK_InventoriesCells__Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[_Users] ([ID])
GO
ALTER TABLE [dbo].[InventoriesCells] CHECK CONSTRAINT [FK_InventoriesCells__Users]
GO
ALTER TABLE [dbo].[InventoriesCells]  WITH CHECK ADD  CONSTRAINT [FK_InventoriesCells_Cells] FOREIGN KEY([CellID])
REFERENCES [dbo].[Cells] ([ID])
GO
ALTER TABLE [dbo].[InventoriesCells] CHECK CONSTRAINT [FK_InventoriesCells_Cells]
GO
ALTER TABLE [dbo].[InventoriesCells]  WITH CHECK ADD  CONSTRAINT [FK_InventoriesCells_Inventories] FOREIGN KEY([InventoryID])
REFERENCES [dbo].[Inventories] ([ID])
GO
ALTER TABLE [dbo].[InventoriesCells] CHECK CONSTRAINT [FK_InventoriesCells_Inventories]