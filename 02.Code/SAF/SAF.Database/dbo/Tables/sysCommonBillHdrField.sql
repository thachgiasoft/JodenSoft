CREATE TABLE [dbo].[sysCommonBillHdrField] (
    [Iden]            INT            NOT NULL,
    [HdrId]           INT            NOT NULL,
    [FieldName]       NVARCHAR (50)  NOT NULL,
    [Caption]         NVARCHAR (50)  NOT NULL,
    [ControlType]     INT            NOT NULL,
    [ControlFillSql]  NVARCHAR (MAX) NULL,
    [ValueMember]     NVARCHAR (50)  NULL,
    [DisplayMember]   NVARCHAR (50)  NULL,
    [KeyFieldName]    NVARCHAR (50)  NULL,
    [ParentFeildName] NVARCHAR (50)  NULL,
    [Remark]          NVARCHAR (MAX) NULL,
    [CreatedBy]       INT            NULL,
    [CreatedOn]       DATETIME       NULL,
    [ModifiedBy]      INT            NULL,
    [ModifiedOn]      DATETIME       NULL,
    [VersionNumber]   ROWVERSION     NULL,
    CONSTRAINT [PK_sysCommonBillHdrField] PRIMARY KEY CLUSTERED ([Iden] ASC),
    CONSTRAINT [FK_sysCommonBillHdrField_sysCommonBillHdr] FOREIGN KEY ([HdrId]) REFERENCES [dbo].[sysCommonBillHdr] ([Iden])
);

