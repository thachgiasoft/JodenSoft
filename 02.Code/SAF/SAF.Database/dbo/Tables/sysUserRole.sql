CREATE TABLE [dbo].[sysUserRole] (
    [Iden]          INT        NOT NULL,
    [UserId]        INT        NOT NULL,
    [RoleId]        INT        NOT NULL,
    [CreatedBy]     INT        NULL,
    [CreatedOn]     DATETIME   NULL,
    [ModifiedBy]    INT        NULL,
    [ModifiedOn]    DATETIME   NULL,
    [VersionNumber] ROWVERSION NULL,
    CONSTRAINT [PK_sysUserRole] PRIMARY KEY CLUSTERED ([Iden] ASC),
    CONSTRAINT [FK_sysUserRole_sysRole] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[sysRole] ([Iden]),
    CONSTRAINT [FK_sysUserRole_sysUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[sysUser] ([Iden])
);

