CREATE TABLE [dbo].[sysDataRole] (
    [Iden]          INT            NOT NULL,
    [Name]          NVARCHAR (50)  NULL,
    [IsSystem]      BIT            CONSTRAINT [DF_sysRole_IsSystem] DEFAULT ((0)) NOT NULL,
    [IsDeleted]     BIT            CONSTRAINT [DF_sysDataRole_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Remark]        NVARCHAR (500) NULL,
    [CreatedBy]     INT            NULL,
    [CreatedOn]     DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    [ModifiedOn]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL,
    CONSTRAINT [PK_sysDataRole] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

