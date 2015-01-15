CREATE TABLE [dbo].[sysRegInfo] (
    [Iden]             INT            NOT NULL,
    [ProductId]        NVARCHAR (100) NOT NULL,
    [RegInfo]          NVARCHAR (MAX) NOT NULL,
    [ComputerName]     NVARCHAR (500) NULL,
    [ComputerUserName] NVARCHAR (500) NULL,
    [LastLoginTime]    DATETIME       NULL,
    [Remark]           NVARCHAR (MAX) NULL,
    [CreatedBy]        INT            NULL,
    [CreatedOn]        DATETIME       NULL,
    [ModifiedBy]       INT            NULL,
    [ModifiedOn]       DATETIME       NULL,
    [VersionNumber]    ROWVERSION     NULL,
    CONSTRAINT [PK_sysRegInfo] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

