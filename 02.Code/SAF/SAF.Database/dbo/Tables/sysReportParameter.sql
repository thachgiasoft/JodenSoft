CREATE TABLE [dbo].[sysReportParameter] (
    [Iden]          INT           NOT NULL,
    [ReportId]      INT           NULL,
    [Name]          NVARCHAR (50) NULL,
    [TestValue]     NVARCHAR (50) NULL,
    [CreateBy]      INT           NULL,
    [CreateTime]    DATETIME      NULL,
    [ModifyBy]      INT           NULL,
    [ModifyTime]    DATETIME      NULL,
    [VersionNumber] ROWVERSION    NULL,
    CONSTRAINT [PK_sysReportParameter] PRIMARY KEY CLUSTERED ([Iden] ASC),
    CONSTRAINT [FK_sysReportParameter_sysReport] FOREIGN KEY ([ReportId]) REFERENCES [dbo].[sysReport] ([Iden])
);

