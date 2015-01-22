CREATE TABLE [dbo].[sysBillRightDefine] (
    [Iden]          INT            NOT NULL,
    [BillTypeId]    INT            NOT NULL,
    [RightType]     NVARCHAR (50)  NOT NULL,
    [FieldName]     NVARCHAR (500) NOT NULL,
    [Caption]       NVARCHAR (500) NOT NULL,
    [Remark]        NVARCHAR (MAX) NULL,
    [IsActive]      BIT            CONSTRAINT [DF_sysBillRightDefine_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]     INT            NULL,
    [CreatedOn]     DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    [ModifiedOn]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL,
    CONSTRAINT [PK_sysBillRightDefine] PRIMARY KEY CLUSTERED ([Iden] ASC),
    CONSTRAINT [FK_SystemBillRightDefine_SystemBillType] FOREIGN KEY ([BillTypeId]) REFERENCES [dbo].[sysBillType] ([Iden])
);

