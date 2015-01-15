CREATE TABLE [dbo].[sysCommonBillHdr] (
    [Iden]            INT            NOT NULL,
    [Name]            NVARCHAR (100) NOT NULL,
    [IsSystem]        BIT            NOT NULL,
    [IsDeleted]       BIT            NOT NULL,
    [IndexQuerySql]   NVARCHAR (MAX) NOT NULL,
    [IndexColumnName] NVARCHAR (MAX) NOT NULL,
    [MainQuerySql]    NVARCHAR (MAX) NOT NULL,
    [Remark]          NVARCHAR (MAX) NULL,
    [CreatedBy]       INT            NULL,
    [CreatedOn]       DATETIME       NULL,
    [ModifiedBy]      INT            NULL,
    [ModifiedOn]      DATETIME       NULL,
    [VersionNumber]   ROWVERSION     NULL,
    CONSTRAINT [PK_sysCommonBillHdr] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

