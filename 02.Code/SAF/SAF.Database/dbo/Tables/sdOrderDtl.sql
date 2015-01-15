CREATE TABLE [dbo].[sdOrderDtl] (
    [Iden]    INT             NOT NULL,
    [OrderId] INT             NULL,
    [Qty]     DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([Iden] ASC)
);

