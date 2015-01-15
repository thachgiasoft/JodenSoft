CREATE TABLE [dbo].[sysOrganization] (
    [Iden]          INT            NOT NULL,
    [Name]          NVARCHAR (50)  NULL,
    [ParentId]      INT            CONSTRAINT [DF_SystemOrganization_ParentId] DEFAULT ((0)) NOT NULL,
    [Code]          NVARCHAR (MAX) CONSTRAINT [DF_SystemOrganization_Code] DEFAULT ('') NOT NULL,
    [IsActive]      BIT            CONSTRAINT [DF_sysOrganization_IsDeleted] DEFAULT ((1)) NOT NULL,
    [Remark]        NVARCHAR (500) NULL,
    [CreatedBy]     INT            NULL,
    [CreatedOn]     DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    [ModifiedOn]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL,
    CONSTRAINT [PK_sysOrganization] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

