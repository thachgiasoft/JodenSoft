CREATE TABLE [dbo].[imInOutStockRoomOperationDtl](
	[Iden] [int] NOT NULL,
	[HdrID] [int] NOT NULL,
	[nQty] [decimal](18, 2) NULL,
	[nTaxPrice] [decimal](18, 6) NULL,
	[nTaxAmount] [decimal](18, 6) NULL,
	[nRate] [decimal](18, 2) NULL,
	[nDiscount] [decimal](18, 2) NULL,
	[sUnit] [nvarchar](20) NULL,
	[iUnit] [int] NULL,
	[nPkgQty] [decimal](18, 2) NULL,
	[sLocation] [nvarchar](50) NULL,
	[sRemark] [nvarchar](200) NULL,
 CONSTRAINT [PK_imInOutStockRoomOperationDtl] PRIMARY KEY CLUSTERED 
(
	[Iden] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'含税单价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'imInOutStockRoomOperationDtl', @level2type=N'COLUMN',@level2name=N'nTaxPrice'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'含税金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'imInOutStockRoomOperationDtl', @level2type=N'COLUMN',@level2name=N'nTaxAmount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'折扣' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'imInOutStockRoomOperationDtl', @level2type=N'COLUMN',@level2name=N'nDiscount'
GO

ALTER TABLE [dbo].[imInOutStockRoomOperationDtl] ADD  CONSTRAINT [DF_imInOutStockRoomOperationDtl_nTaxPrice]  DEFAULT ((0)) FOR [nTaxPrice]
GO

ALTER TABLE [dbo].[imInOutStockRoomOperationDtl] ADD  CONSTRAINT [DF_imInOutStockRoomOperationDtl_nTaxAmount]  DEFAULT ((0)) FOR [nTaxAmount]
GO

ALTER TABLE [dbo].[imInOutStockRoomOperationDtl] ADD  CONSTRAINT [DF_imInOutStockRoomOperationDtl_nRate]  DEFAULT ((0)) FOR [nRate]
GO

ALTER TABLE [dbo].[imInOutStockRoomOperationDtl] ADD  CONSTRAINT [DF_imInOutStockRoomOperationDtl_nDiscount]  DEFAULT ((0)) FOR [nDiscount]
GO

