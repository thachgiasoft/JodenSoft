 
CREATE TABLE [dbo].[imInOutStockRoomOperationHdr](
	[Iden] [int] NOT NULL,
	[sBillNo] [nvarchar](50) NOT NULL,
	[sStatus] [nvarchar](50) NOT NULL,
	[iStoreInOutType] [int] NOT NULL,
	[iStoreID] [int] NOT NULL,
	[iSourceDestStore] [int] NULL,
	[tStoreInouttime] [datetime] NOT NULL,
	[tCreatetime] [datetime] NULL,
	[sCreator] [nvarchar](20) NULL,
	[sUpdateMan] [nvarchar](20) NULL,
	[tUpdatetime] [datetime] NULL,
	[sAuditMan] [nvarchar](20) NULL,
	[tAudittime] [datetime] NULL,
	[sRemark] [nvarchar](200) NULL,
 CONSTRAINT [PK_imInOutStockRoomOperationHdr] PRIMARY KEY CLUSTERED 
(
	[Iden] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目标源(入库仓\出库仓)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'imInOutStockRoomOperationHdr', @level2type=N'COLUMN',@level2name=N'iStoreID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目的仓(来源仓库、供应商等、目的地仓库车间等)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'imInOutStockRoomOperationHdr', @level2type=N'COLUMN',@level2name=N'iSourceDestStore'
GO

