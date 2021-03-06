﻿CREATE TABLE [dbo].[sysBillType] (
    [Iden]                INT            NOT NULL,
    [Name]                NVARCHAR (50)  NOT NULL,
    [Remark]              NVARCHAR (MAX) NULL,
    [IsDeleted]           BIT            CONSTRAINT [DF_sysBillType_IsDeleted] DEFAULT ((0)) NOT NULL,
    [IsActive]            BIT            CONSTRAINT [DF_sysBillType_IsActive] DEFAULT ((1)) NOT NULL,
    [IsSystem]            BIT            CONSTRAINT [DF_sysBillType_IsSystem] DEFAULT ((0)) NOT NULL,
    [UseBillDataRight]    BIT            NOT NULL,
    [UseBillOperateRight] BIT            NOT NULL,
    [CreatedBy]           INT            NULL,
    [CreatedOn]           DATETIME       NULL,
    [ModifiedBy]          INT            NULL,
    [ModifiedOn]          DATETIME       NULL,
    [VersionNumber]       ROWVERSION     NULL,
    CONSTRAINT [PK_sysBillType] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

