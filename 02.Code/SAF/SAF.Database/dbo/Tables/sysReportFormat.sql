CREATE TABLE [dbo].[sysReportFormat]
(
	[Iden]           INT NOT NULL,
	[ReportId]		 INT NOT NULL,
	[Name]           NVARCHAR(50) NOT NULL,
	[FormatData]     VARBINARY(MAX) NULL,
	[OrderIndex]	 INT CONSTRAINT [DF_sysReportFormat_OrderIndex] DEFAULT((0)) NOT NULL,
	[IsDefault]      BIT CONSTRAINT [DF_sysReportFormat_IsDefault] DEFAULT((0)) NOT NULL,
	[IsActive]       BIT CONSTRAINT [DF_sysReportFormat_IsActive] DEFAULT ((1)) NOT NULL,
	[Remark]         NVARCHAR(MAX) NULL,
	[CreatedBy]      INT        NULL,
    [CreatedOn]      DATETIME   NULL,
    [ModifiedBy]     INT        NULL,
    [ModifiedOn]     DATETIME   NULL,
    [VersionNumber]  ROWVERSION NULL,
	CONSTRAINT [PK_sysReportFormat_Iden] PRIMARY KEY CLUSTERED ([Iden] ASC),
	CONSTRAINT [FK_sysReportFormat_ReportId_sysReport_Iden] FOREIGN KEY (ReportId) REFERENCES dbo.sysReport(Iden)
)
