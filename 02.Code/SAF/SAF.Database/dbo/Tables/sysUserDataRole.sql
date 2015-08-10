CREATE TABLE [dbo].[sysUserDataRole] (
    [Iden]           INT        NOT NULL,
    [UserId]         INT        NOT NULL,
    [OrganizationId] INT        NOT NULL,
    [DataRoleId]     INT        NOT NULL,
    [CreatedBy]      INT        NULL,
    [CreatedOn]      DATETIME   NULL,
    [ModifiedBy]     INT        NULL,
    [ModifiedOn]     DATETIME   NULL,
    [VersionNumber]  ROWVERSION NULL,
    CONSTRAINT [PK_sysUserDataRole] PRIMARY KEY CLUSTERED ([Iden] ASC),
    CONSTRAINT [FK_sysUserDataRole_SystemOrganization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[sysOrganization] ([Iden]),
    CONSTRAINT [FK_sysUserDataRole_sysRole_RoleId] FOREIGN KEY ([DataRoleId]) REFERENCES [dbo].[sysDataRole] ([Iden]),
    CONSTRAINT [FK_sysUserDataRole_sysUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[sysUser] ([Iden])
);

