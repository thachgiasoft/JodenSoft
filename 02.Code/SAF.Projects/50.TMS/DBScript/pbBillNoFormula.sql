
CREATE TABLE [dbo].[pbBillNoFormula](
	[iIden] [int] NOT NULL,
	[iFormulaId] [int] NOT NULL,
	[sBillName] [varchar](50) NOT NULL,
	[sBillCaption] [nvarchar](50) NOT NULL,
	[sGroup] [varchar](10) NULL,
	[sBillFormula] [nvarchar](100) NOT NULL,
	[sBillFormulaReset] [nvarchar](100) NOT NULL,
	[sParamFormula] [varchar](max) NULL,
	[sEncryptCode] [varchar](32) NOT NULL,
	[iVersion] [int] NULL,
	[iStartDay] [smallint] NOT NULL,
	[iStartHour] [smallint] NOT NULL,
	[sParamName] [nvarchar](1000) NULL,
	[sNotNullParamName] [nvarchar](max) NULL,
 CONSTRAINT [PK__pbBillNo__54648D273627DDB5] PRIMARY KEY CLUSTERED 
(
	[iFormulaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[pbBillNoFormula] ADD  CONSTRAINT [DF__pbBillNoF__iStar__72222593]  DEFAULT ((1)) FOR [iStartDay]
GO

ALTER TABLE [dbo].[pbBillNoFormula] ADD  CONSTRAINT [DF__pbBillNoF__iStar__731649CC]  DEFAULT ((0)) FOR [iStartHour]
GO

ALTER TABLE [dbo].[pbBillNoFormula] ADD  CONSTRAINT [DF__pbBillNoF__sNotN__5F252B0F]  DEFAULT ('') FOR [sNotNullParamName]
GO

