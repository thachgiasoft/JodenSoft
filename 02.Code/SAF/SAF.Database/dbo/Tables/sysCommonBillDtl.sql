CREATE TABLE [dbo].[sysCommonBillDtl] (
    [Iden]          INT            NOT NULL,
    [HdrId]         INT            NOT NULL,
    [QuerySql]      NVARCHAR (MAX) NOT NULL,
    [Remark]        NVARCHAR (MAX) NULL,
    [CreatedBy]     INT            NULL,
    [CreatedOn]     DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    [ModifiedOn]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL,
    CONSTRAINT [PK_sysCommonBillDtl] PRIMARY KEY CLUSTERED ([Iden] ASC),
    CONSTRAINT [FK_sysCommonBillDtl_sysCommonBillHdr] FOREIGN KEY ([HdrId]) REFERENCES [dbo].[sysCommonBillHdr] ([Iden])
);

