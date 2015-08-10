CREATE TABLE [dbo].[wfBill] (
    [Iden]           INT           NOT NULL,
    [BillTypeId]     INT           NOT NULL,
    [BillId]         INT           CONSTRAINT [DF_wfBill_BillId] DEFAULT ((0)) NOT NULL,
    [BillNo]         NVARCHAR (20) CONSTRAINT [DF_wfBill_BillNo] DEFAULT ('') NOT NULL,
    [OrganizationId] INT           CONSTRAINT [DF_wfBill_OrganizationId] DEFAULT ((0)) NOT NULL,
    [OwnerId]        NVARCHAR (50) CONSTRAINT [DF_wfBill_OwnerId] DEFAULT ('') NOT NULL,
    [BillState]      TINYINT       CONSTRAINT [DF_wfBill_BillState] DEFAULT ((1)) NOT NULL,
    [CurrStepId]     INT           NOT NULL,
    [AuditTimes]     SMALLINT      CONSTRAINT [DF_wfBill_AuditTimes] DEFAULT ((1)) NOT NULL,
    [IsComplete]     BIT           CONSTRAINT [DF_wfBill_IsComplete] DEFAULT ((0)) NOT NULL,
    [FinishTime]     DATETIME      NULL,
    [WorkFlowId]     INT           NOT NULL,
    [CreatedBy]      INT           NULL,
    [CreatedOn]      DATETIME      NULL,
    [ModifiedBy]     INT           NULL,
    [ModifiedOn]     DATETIME      NULL,
    [VersionNumber]  ROWVERSION    NULL,
    CONSTRAINT [PK_wfBill] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

