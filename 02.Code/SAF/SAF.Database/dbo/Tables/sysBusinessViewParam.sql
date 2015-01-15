CREATE TABLE [dbo].[sysBusinessViewParam] (
    [Iden]           INT            NOT NULL,
    [BusinessViewId] INT            NOT NULL,
    [Name]           NVARCHAR (100) NOT NULL,
    [Description]    NVARCHAR (MAX) NULL,
    [CreatedBy]      INT            NULL,
    [CreatedOn]      DATETIME       NULL,
    [ModifiedBy]     INT            NULL,
    [ModifiedOn]     DATETIME       NULL,
    [VersionNumber]  ROWVERSION     NULL,
    CONSTRAINT [PK_sysBusinessViewParam] PRIMARY KEY CLUSTERED ([Iden] ASC),
    CONSTRAINT [FK_sysBusinessViewParam_sysBusinessView] FOREIGN KEY ([BusinessViewId]) REFERENCES [dbo].[sysBusinessView] ([Iden]) ON DELETE CASCADE ON UPDATE CASCADE
);

