CREATE TABLE [dbo].[sysRoleMenu] (
    [Iden]          INT        NOT NULL,
    [RoleId]        INT        NOT NULL,
    [MenuId]        INT        NOT NULL,
    [CreatedBy]     INT        NULL,
    [CreatedOn]     DATETIME   NULL,
    [ModifiedBy]    INT        NULL,
    [ModifiedOn]    DATETIME   NULL,
    [VersionNumber] ROWVERSION NULL,
    CONSTRAINT [PK_sysRoleMenu] PRIMARY KEY CLUSTERED ([Iden] ASC),
    CONSTRAINT [FK_sysRoleMenu_sysMenu_MenuId] FOREIGN KEY ([MenuId]) REFERENCES [dbo].[sysMenu] ([Iden]),
    CONSTRAINT [FK_sysRoleMenu_sysRole] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[sysRole] ([Iden])
);

