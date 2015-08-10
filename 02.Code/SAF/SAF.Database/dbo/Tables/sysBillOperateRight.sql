﻿CREATE TABLE [dbo].[sysBillOperateRight] (
    [Iden]          INT          NOT NULL,
    [BillTypeId]    INT          NOT NULL,
    [DataRoleId]    INT          NOT NULL,
    [AddNew]        BIT          CONSTRAINT [DF_sysBillOperateRight_AddNew] DEFAULT ((0)) NOT NULL,
    [ExtendRight1]  BIT          CONSTRAINT [DF_sysBillOperateRight_ExtendRight1] DEFAULT ((0)) NOT NULL,
    [ExtendRight2]  BIT          CONSTRAINT [DF_sysBillOperateRight_ExtendRight2] DEFAULT ((0)) NOT NULL,
    [ExtendRight3]  BIT          CONSTRAINT [DF_sysBillOperateRight_ExtendRight3] DEFAULT ((0)) NOT NULL,
    [ExtendRight4]  BIT          CONSTRAINT [DF_sysBillOperateRight_ExtendRight4] DEFAULT ((0)) NOT NULL,
    [ExtendRight5]  BIT          CONSTRAINT [DF_sysBillOperateRight_ExtendRight5] DEFAULT ((0)) NOT NULL,
    [ExtendRight6]  BIT          CONSTRAINT [DF_sysBillOperateRight_ExtendRight6] DEFAULT ((0)) NOT NULL,
    [ExtendRight7]  BIT          CONSTRAINT [DF_sysBillOperateRight_ExtendRight7] DEFAULT ((0)) NOT NULL,
    [ExtendRight8]  BIT          CONSTRAINT [DF_sysBillOperateRight_ExtendRight8] DEFAULT ((0)) NOT NULL,
    [ExtendRight9]  BIT          CONSTRAINT [DF_sysBillOperateRight_ExtendRight9] DEFAULT ((0)) NOT NULL,
    [ExtendRight10] BIT          CONSTRAINT [DF_sysBillOperateRight_ExtendRight10] DEFAULT ((0)) NOT NULL,
    [IsActive]      BIT          CONSTRAINT [DF_sysBillOperateRight_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]     INT          NULL,
    [CreatedOn]     DATETIME     NULL,
    [ModifiedBy]    INT          NULL,
    [ModifiedOn]    DATETIME     NULL,
    [VersionNumber] NUMERIC (18) NULL,
    CONSTRAINT [PK_sysBillOperateRight] PRIMARY KEY CLUSTERED ([Iden] ASC),
    CONSTRAINT [FK_SystemBillOperateRight_SystemBillType] FOREIGN KEY ([BillTypeId]) REFERENCES [dbo].[sysBillType] ([Iden]),
    CONSTRAINT [FK_SystemBillOperateRight_SystemRole] FOREIGN KEY ([DataRoleId]) REFERENCES [dbo].[sysDataRole] ([Iden])
);

