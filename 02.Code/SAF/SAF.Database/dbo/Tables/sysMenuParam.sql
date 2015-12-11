CREATE TABLE [dbo].[sysMenuParam] (
    [Iden]          INT            NOT NULL,
    [MenuId]        INT            NOT NULL,
    [Name]          NVARCHAR (200) NOT NULL,
	[Category]		NVARCHAR(200)  NOT NULL CONSTRAINT [DF_SysMenuParam_Category] DEFAULT '',
	[ControlType]	INT NOT NULL CONSTRAINT [DF_sysMenuParam_ControlType] DEFAULT 0,
    [Value]         NVARCHAR(MAX) NULL,
    [Description]   NVARCHAR (MAX) NULL,
    [CreatedBy]     INT            NULL,
    [CreatedOn]     DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    [ModifiedOn]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL,
    CONSTRAINT [PK_sysMenuParam] PRIMARY KEY CLUSTERED ([Iden] ASC),
    CONSTRAINT [FK_sysMenuParam_sysMenu] FOREIGN KEY ([MenuId]) REFERENCES [dbo].[sysMenu] ([Iden]) ON DELETE CASCADE ON UPDATE CASCADE
);

