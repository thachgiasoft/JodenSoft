﻿CREATE TABLE [dbo].[sysMenuParam] (
    [Iden]          INT            NOT NULL,
    [MenuId]        INT            NOT NULL,
    [Name]          NVARCHAR (100) NOT NULL,
    [Value]         NVARCHAR (100) NULL,
    [Description]   NVARCHAR (MAX) NULL,
    [CreatedBy]     INT            NULL,
    [CreatedOn]     DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    [ModifiedOn]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL,
    CONSTRAINT [PK_sysMenuParam] PRIMARY KEY CLUSTERED ([Iden] ASC),
    CONSTRAINT [FK_sysMenuParam_sysMenu] FOREIGN KEY ([MenuId]) REFERENCES [dbo].[sysMenu] ([Iden]) ON DELETE CASCADE ON UPDATE CASCADE
);
