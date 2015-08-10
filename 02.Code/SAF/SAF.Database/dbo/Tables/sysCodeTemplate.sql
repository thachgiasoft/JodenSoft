CREATE TABLE [dbo].[sysCodeTemplate] (
    [Iden]          INT            NOT NULL,
    [Name]          NVARCHAR (400) NOT NULL,
    [Template]      NVARCHAR (MAX) NULL,
    [Remark]        NVARCHAR (400) NULL,
    [IsActive]      BIT            CONSTRAINT [DF_sysCodeTemplate_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]     INT            NULL,
    [CreatedOn]     DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    [ModifiedOn]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL,
    CONSTRAINT [PK_sysCodeTemplate_Iden] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

