CREATE TABLE [dbo].[sysQueryConfig] (
    [Iden]        INT            NOT NULL,
    [ReportName]  NVARCHAR (100) NULL,
    [ReportType]  INT            NULL,
    [SqlCommand]  NVARCHAR (MAX) NULL,
    [ParamColumn] INT            CONSTRAINT [DF_sysReportConfig_ParamColumn] DEFAULT ((1)) NOT NULL,
    [CreateBy]    INT            NULL,
    [CreateTime]  DATETIME       NULL,
    [ModifyBy]    INT            NULL,
    [ModifyTime]  DATETIME       NULL,
    CONSTRAINT [PK_sysReportConfig] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

