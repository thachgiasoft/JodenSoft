CREATE TABLE [dbo].[sysQueryParam] (
    [Iden]           INT            NOT NULL,
    [ReportId]       INT            NULL,
    [ParamName]      NVARCHAR (100) NULL,
    [ParamCaption]   NVARCHAR (50)  NULL,
    [SortIndex]      INT            NULL,
    [ControlType]    INT            NULL,
    [DefaultValue]   NVARCHAR (100) NULL,
    [IsVisible]      BIT            CONSTRAINT [DF_sysReportParam_Visible] DEFAULT ((1)) NOT NULL,
    [SqlScript]      NVARCHAR (MAX) NULL,
    [ParamValues]    NVARCHAR (MAX) NULL,
    [ValueMember]    NVARCHAR (500) NULL,
    [DisplayMember]  NVARCHAR (500) NULL,
    [VisibleColumns] NVARCHAR (500) NULL,
    [CreateBy]       INT            NULL,
    [CreateTime]     DATETIME       NULL,
    [ModifyBy]       INT            NULL,
    [ModifyTime]     DATETIME       NULL,
    CONSTRAINT [PK_sysReportParam] PRIMARY KEY CLUSTERED ([Iden] ASC),
    CONSTRAINT [FK_sysReportParam_sysReportConfig] FOREIGN KEY ([ReportId]) REFERENCES [dbo].[sysQueryConfig] ([Iden])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'在界面上是否可见', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'sysQueryParam', @level2type = N'COLUMN', @level2name = N'IsVisible';

