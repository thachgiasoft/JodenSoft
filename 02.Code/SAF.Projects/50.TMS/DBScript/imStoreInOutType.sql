CREATE TABLE [dbo].[imStoreInOutType](
	[Iden] [int] NOT NULL,
	[sStoreInOutName] [nvarchar](50) NOT NULL,
	[sStoreInOutType] [nvarchar](10) NOT NULL,
	[tCreatetime] [datetime] NULL,
	[sCreator] [nvarchar](20) NULL,
	[iReceivePayType] [int] NULL,
	[iAutoCreateType] [int] NULL,
	[bUsable] [bit] NOT NULL,
 CONSTRAINT [PK_imStoreInOutType] PRIMARY KEY CLUSTERED 
(
	[Iden] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收付正负"+","-"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'imStoreInOutType', @level2type=N'COLUMN',@level2name=N'sStoreInOutType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0应收1应付' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'imStoreInOutType', @level2type=N'COLUMN',@level2name=N'iReceivePayType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0不创建1自动创建不审核2自动创建并审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'imStoreInOutType', @level2type=N'COLUMN',@level2name=N'iAutoCreateType'
GO

ALTER TABLE [dbo].[imStoreInOutType] ADD  CONSTRAINT [DF_imStoreInOutType_bUsable]  DEFAULT ((1)) FOR [bUsable]
GO

