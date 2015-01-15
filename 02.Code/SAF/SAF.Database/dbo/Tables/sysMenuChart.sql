CREATE TABLE [dbo].[sysMenuChart] (
    [Iden]          INT            NOT NULL,
    [Name]          NVARCHAR (50)  NOT NULL,
    [Remark]        NVARCHAR (MAX) NULL,
    [FileData]      IMAGE          NULL,
    [CreatedBy]     INT            NULL,
    [CreatedOn]     DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    [ModifiedOn]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL,
    CONSTRAINT [PK_sysMenuChart] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

