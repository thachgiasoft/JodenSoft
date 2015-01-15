CREATE TABLE [dbo].[sysAppConfig] (
    [Iden]          INT            NOT NULL,
    [UserId]        INT            NULL,
    [AppConfig]     NVARCHAR (MAX) NULL,
    [CreatedBy]     INT            NULL,
    [CreatedOn]     DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    [ModifiedOn]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL,
    CONSTRAINT [PK_sysUserAppConfig] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

