CREATE TABLE [dbo].[sysBusinessView] (
    [Iden]          INT            NOT NULL,
    [ClassName]     NVARCHAR (500) NULL,
    [Description]   NVARCHAR (200) NULL,
    [FileId]        INT            NULL,
    [Remark]        NVARCHAR (MAX) NULL,
    [IsDeleted]     BIT            CONSTRAINT [DF_SystemBusinessView_IsDeleted] DEFAULT ((0)) NOT NULL,
    [CreatedBy]     INT            NULL,
    [CreatedOn]     DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    [ModifiedOn]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL,
    CONSTRAINT [PK_SystemBusinessView] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

