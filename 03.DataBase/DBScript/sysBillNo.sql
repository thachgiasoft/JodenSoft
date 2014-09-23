USE [SAF]
GO

/****** Object:  Table [dbo].[sysBillNo]    Script Date: 2014-10-01 0:45:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[sysBillNo](
	[Iden] [INT] IDENTITY(1,1) NOT NULL,
	[BillNoType] [VARCHAR](50) NOT NULL,
	[ResetType] [VARCHAR](50) NOT NULL,
	[Separator] [VARCHAR](50) NOT NULL,
	[Prefix] [VARCHAR](50) NOT NULL,
	[YearFormat] [VARCHAR](50) NOT NULL,
	[MonthFormat] [VARCHAR](50) NOT NULL,
	[DayFormat] [VARCHAR](50) NOT NULL,
	[Midfix] [VARCHAR](50) NOT NULL,
	[CurrentIden] [INT] NOT NULL,
	[IdenLength] [INT] NOT NULL,
	[CurrentDate] [DATETIME] NULL,
	[Suffix] [VARCHAR](50) NOT NULL,
 CONSTRAINT [PK_BillNoType_Iden] PRIMARY KEY CLUSTERED 
(
	[Iden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_sysBillNo_BillNoType] UNIQUE NONCLUSTERED 
(
	[BillNoType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[sysBillNo] ADD  CONSTRAINT [Default_sysBillNo_ResetType]  DEFAULT ('day') FOR [ResetType]
GO

ALTER TABLE [dbo].[sysBillNo] ADD  CONSTRAINT [Default_sysBillNo_Separator]  DEFAULT ('') FOR [Separator]
GO

ALTER TABLE [dbo].[sysBillNo] ADD  CONSTRAINT [Default_sysBillNo_Prefix]  DEFAULT ('') FOR [Prefix]
GO

ALTER TABLE [dbo].[sysBillNo] ADD  CONSTRAINT [Default_sysBillNo_YearPart]  DEFAULT ('yyyy') FOR [YearFormat]
GO

ALTER TABLE [dbo].[sysBillNo] ADD  CONSTRAINT [Default_sysBillNo_MonthPart]  DEFAULT ('mm') FOR [MonthFormat]
GO

ALTER TABLE [dbo].[sysBillNo] ADD  CONSTRAINT [Default_sysBillNo_DayPart]  DEFAULT ('dd') FOR [DayFormat]
GO

ALTER TABLE [dbo].[sysBillNo] ADD  CONSTRAINT [Default_sysBillNo_Midfix]  DEFAULT ('') FOR [Midfix]
GO

ALTER TABLE [dbo].[sysBillNo] ADD  CONSTRAINT [Default_sysBillNo_CurrentMaxIden]  DEFAULT ((0)) FOR [CurrentIden]
GO

ALTER TABLE [dbo].[sysBillNo] ADD  CONSTRAINT [Default_sysBillNo_BillNoLength]  DEFAULT ((4)) FOR [IdenLength]
GO

ALTER TABLE [dbo].[sysBillNo] ADD  CONSTRAINT [Default_sysBillNo_CurrentMaxDate]  DEFAULT (GETDATE()) FOR [CurrentDate]
GO

ALTER TABLE [dbo].[sysBillNo] ADD  CONSTRAINT [Default_sysBillNo_Suffix]  DEFAULT ('') FOR [Suffix]
GO

ALTER TABLE [dbo].[sysBillNo]  WITH CHECK ADD  CONSTRAINT [chk_sysBillNo_CurrentDate] CHECK  (([ResetType]='' OR [ResetType]<>'' AND [CurrentDate] IS NOT NULL))
GO

ALTER TABLE [dbo].[sysBillNo] CHECK CONSTRAINT [chk_sysBillNo_CurrentDate]
GO

ALTER TABLE [dbo].[sysBillNo]  WITH CHECK ADD  CONSTRAINT [CHK_sysBillNo_DayFormat] CHECK  (([DayFormat]='' OR [DayFormat]='d' OR [DayFormat]='dd'))
GO

ALTER TABLE [dbo].[sysBillNo] CHECK CONSTRAINT [CHK_sysBillNo_DayFormat]
GO

ALTER TABLE [dbo].[sysBillNo]  WITH CHECK ADD  CONSTRAINT [CHK_sysBillNo_MonthFormat] CHECK  (([MonthFormat]='' OR [MonthFormat]='m' OR [MonthFormat]='mm'))
GO

ALTER TABLE [dbo].[sysBillNo] CHECK CONSTRAINT [CHK_sysBillNo_MonthFormat]
GO

ALTER TABLE [dbo].[sysBillNo]  WITH CHECK ADD  CONSTRAINT [CHK_sysBillNo_ResetType] CHECK  (([ResetType]='' OR [ResetType]='day' OR [ResetType]='month' OR [ResetType]='year'))
GO

ALTER TABLE [dbo].[sysBillNo] CHECK CONSTRAINT [CHK_sysBillNo_ResetType]
GO

ALTER TABLE [dbo].[sysBillNo]  WITH CHECK ADD  CONSTRAINT [CHK_sysBillNo_ResetType_Map] CHECK  (([ResetType]='' OR CHARINDEX(LEFT([ResetType],(1)),([YearFormat]+[MonthFormat])+[DayFormat])>(0)))
GO

ALTER TABLE [dbo].[sysBillNo] CHECK CONSTRAINT [CHK_sysBillNo_ResetType_Map]
GO

ALTER TABLE [dbo].[sysBillNo]  WITH CHECK ADD  CONSTRAINT [CHK_sysBillNo_YearFormat] CHECK  (([YearFormat]='' OR [YearFormat]='yy' OR [YearFormat]='yyyy'))
GO

ALTER TABLE [dbo].[sysBillNo] CHECK CONSTRAINT [CHK_sysBillNo_YearFormat]
GO


