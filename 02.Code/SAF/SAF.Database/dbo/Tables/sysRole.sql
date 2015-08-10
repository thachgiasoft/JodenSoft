CREATE TABLE [dbo].[sysRole] (
    [Iden]            INT            NOT NULL,
    [Name]            NVARCHAR (100) NOT NULL,
    [Remark]          NVARCHAR (MAX) NULL,
    [IsSystem]        BIT            CONSTRAINT [DF_sysRole_IsSystem_1] DEFAULT ((0)) NOT NULL,
    [IsDeleted]       INT            CONSTRAINT [DF_sysRole_IsDeleted] DEFAULT ((0)) NOT NULL,
    [IsAdministrator] BIT            CONSTRAINT [DF_sysRole_IsAdministrator] DEFAULT ((0)) NOT NULL,
    [CreatedBy]       INT            NULL,
    [CreatedOn]       DATETIME       NULL,
    [ModifiedBy]      INT            NULL,
    [ModifiedOn]      DATETIME       NULL,
    [VersionNumber]   ROWVERSION     NULL,
    CONSTRAINT [PK_sysRole] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

