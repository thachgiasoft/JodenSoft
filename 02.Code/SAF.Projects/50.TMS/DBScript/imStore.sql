 
CREATE TABLE [dbo].[imStore](
	[Iden] [int] NOT NULL,
	[sStoreNo] [nvarchar](20) NULL,
	[sStoreName] [nvarchar](50) NULL,
	[tCreatetime] [datetime] NULL,
	[sCreator] [nvarchar](20) NULL,
	[bUsable] [bit] NULL,
 CONSTRAINT [PK_imTest] PRIMARY KEY CLUSTERED 
(
	[Iden] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[imStore] ADD  CONSTRAINT [DF_imTest_bUsable]  DEFAULT ((1)) FOR [bUsable]
GO

