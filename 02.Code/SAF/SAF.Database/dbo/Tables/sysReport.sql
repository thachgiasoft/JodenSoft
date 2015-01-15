CREATE TABLE [dbo].[sysReport] (
    [Iden]          INT            NOT NULL,
    [Name]          NVARCHAR (100) NULL,
    [SqlScript]     NVARCHAR (MAX) NULL,
    [IsDeleted]     BIT            CONSTRAINT [DF_sysReport_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Remark]        NVARCHAR (MAX) NULL,
    [CreateBy]      INT            NULL,
    [CreateTime]    DATETIME       NULL,
    [ModifyBy]      INT            NULL,
    [ModifyTime]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL,
    CONSTRAINT [PK_sysReport_Iden] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

