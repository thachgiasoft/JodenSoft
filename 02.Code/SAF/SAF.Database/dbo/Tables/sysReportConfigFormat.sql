CREATE TABLE [dbo].[sysReportConfigFormat]
(
	[Iden]           INT NOT NULL,
	[ReportConfigId] INT NOT NULL,
	[RowNo]          INT NOT NULL,
	[Name]           NVARCHAR(50) NOT NULL,
	[IsDefault]      BIT cONSTRAINT [DF_sysReportConfigFormat_IsDefault] DEFAULT((0)) NOT NULL,
	[IsActive]       BIT CONSTRAINT [DF_sysReportConfigFormat_IsActive] DEFAULT ((1)) NOT NULL,
	[Remark]         NVARCHAR(MAX) NULL,
	[CreatedBy]      INT        NULL,
    [CreatedOn]      DATETIME   NULL,
    [ModifiedBy]     INT        NULL,
    [ModifiedOn]     DATETIME   NULL,
    [VersionNumber]  ROWVERSION NULL,
	CONSTRAINT [PK_sysReportConfigFormat_Iden] PRIMARY KEY CLUSTERED ([Iden] ASC),
	CONSTRAINT [FK_sysReportConfigFormat_ReportConfigId_sysReportConfig_Iden] FOREIGN KEY (ReportConfigId) REFERENCES dbo.sysReportConfig(Iden)
)
