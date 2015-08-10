CREATE TABLE [dbo].[sysUser] (
    [Iden]          INT            NOT NULL,
    [UserName]      NVARCHAR (50)  NOT NULL,
    [UserFullName]  NVARCHAR (50)  NOT NULL,
    [Password]      NVARCHAR (500) NOT NULL,
    [Email]         NVARCHAR (200) NULL,
    [TelephoneNo]   NVARCHAR (20)  NULL,
    [UserImage]     IMAGE          NULL,
    [UserSignImage] IMAGE          NULL,
    [IsActive]      BIT            CONSTRAINT [DF_sysUser_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]     BIT            CONSTRAINT [DF_sysUser_IsDeleted] DEFAULT ((0)) NOT NULL,
    [IsSystem]      BIT            CONSTRAINT [DF_sysUser_IsSystem] DEFAULT ((0)) NOT NULL,
    [Remark]        NVARCHAR (500) NULL,
    [CreatedBy]     INT            NULL,
    [CreatedOn]     DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    [ModifiedOn]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL,
    CONSTRAINT [PK_sysUser_Iden] PRIMARY KEY CLUSTERED ([Iden] ASC),
    CONSTRAINT [UK_sysUser_UserNo] UNIQUE NONCLUSTERED ([UserName] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'sysUser', @level2type = N'COLUMN', @level2name = N'UserName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户姓名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'sysUser', @level2type = N'COLUMN', @level2name = N'UserFullName';

