CREATE TABLE [dbo].[sysBillType] (
    [Iden]                INT            NOT NULL,
    [Name]                NVARCHAR (50)  NOT NULL,
    [Remark]              NVARCHAR (MAX) NULL,
    [IsDeleted]           BIT            CONSTRAINT [DF_sysBillType_IsDeleted] DEFAULT ((0)) NOT NULL,
    [IsActive]            BIT            CONSTRAINT [DF__SystemBil__IsDel__5C6CB6D7] DEFAULT ((1)) NOT NULL,
    [IsSystem]            BIT            CONSTRAINT [DF__SystemBil__IsSys__5D60DB10] DEFAULT ((0)) NOT NULL,
    [UseBillDataRight]    BIT            NOT NULL,
    [UseBillOperateRight] BIT            NOT NULL,
    [CreatedBy]           INT            NULL,
    [CreatedOn]           DATETIME       NULL,
    [ModifiedBy]          INT            NULL,
    [ModifiedOn]          DATETIME       NULL,
    [VersionNumber]       ROWVERSION     NULL,
    CONSTRAINT [PK__SystemBi__B77084575A846E65] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

