CREATE TABLE [dbo].[sysFile] (
    [Iden]          INT            NOT NULL,
    [Name]          NVARCHAR (200) NOT NULL,
    [FileName]      NVARCHAR (400) NOT NULL,
    [FileVersion]   NVARCHAR (20)  NOT NULL,
    [FileSize]      NVARCHAR (50)  NOT NULL,
    [FileData]      IMAGE          NULL,
    [LastWriteTime] DATETIME       NOT NULL,
    [Remark]        NVARCHAR (MAX) NULL,
    [IsActive]      BIT            CONSTRAINT [DF_SystemFile_IsActive] DEFAULT ((1)) NOT NULL,
	[IsSystem]      BIT            CONSTRAINT [DF_SystemFile_IsSystem] DEFAULT ((0)) NOT NULL,
    [CreatedBy]     INT            NULL,
    [CreatedOn]     DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    [ModifiedOn]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL,
    CONSTRAINT [PK_sysFile] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

