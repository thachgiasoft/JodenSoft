CREATE TABLE [dbo].[sysMenu] (
    [Iden]           INT            NOT NULL,
    [Name]           NVARCHAR (200) NOT NULL,
    [ParentId]       INT            CONSTRAINT [DF_sysMenu_ParentId] DEFAULT ((-1)) NOT NULL,
    [BusinessViewId] INT            NULL,
    [MenuOrder]      INT            NOT NULL,
    [Remark]         NVARCHAR (MAX) NULL,
    [IsSystem]       BIT            CONSTRAINT [DF_SystemMenu_IsSystem] DEFAULT ((0)) NOT NULL,
    [IsAutoOpen]     BIT            CONSTRAINT [DF_sysMenu_IsAutoOpen] DEFAULT ((0)) NOT NULL,
    [CreatedBy]      INT            NULL,
    [CreatedOn]      DATETIME       NULL,
    [ModifiedBy]     INT            NULL,
    [ModifiedOn]     DATETIME       NULL,
    [VersionNumber]  ROWVERSION     NULL,
    [MenuType]       INT            NULL,
    [FileName]       NVARCHAR (MAX) NULL,
    [FileParameter]  NVARCHAR (MAX) NULL,
    [IsShowDialog]   BIT            CONSTRAINT [DF_sysMenu_WaitForExit] DEFAULT ((0)) NOT NULL,
    --[Pinyin] AS ([dbo].[ConvertToPinyin]([Name])),
    CONSTRAINT [PK_sysMenu] PRIMARY KEY CLUSTERED ([Iden] ASC),
    CONSTRAINT [FK_SystemMenu_SystemBusinessView] FOREIGN KEY ([BusinessViewId]) REFERENCES [dbo].[sysBusinessView] ([Iden])
);

