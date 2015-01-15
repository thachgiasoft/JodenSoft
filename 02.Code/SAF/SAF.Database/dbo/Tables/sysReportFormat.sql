CREATE TABLE [dbo].[sysReportFormat] (
    [Iden]          INT            NOT NULL,
    [ReportId]      INT            NULL,
    [Name]          NVARCHAR (100) NULL,
    [ReportData]    IMAGE          NULL,
    [IsDeleted]     BIT            NULL,
    [Remark]        NVARCHAR (MAX) NULL,
    [CreateBy]      INT            NULL,
    [CreateTime]    DATETIME       NULL,
    [ModifyBy]      INT            NULL,
    [ModifyTime]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL,
    CONSTRAINT [PK_sysReportFormat] PRIMARY KEY CLUSTERED ([Iden] ASC),
    CONSTRAINT [FK_sysReportFormat_sysReport] FOREIGN KEY ([ReportId]) REFERENCES [dbo].[sysReport] ([Iden])
);

