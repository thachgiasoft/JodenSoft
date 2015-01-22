CREATE TABLE [dbo].[sdOrderDtl] (
    [Iden]    INT             NOT NULL,
    [OrderId] INT             NULL,
    [Qty]     DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_sdOrderDtl]  PRIMARY KEY CLUSTERED ([Iden] ASC)
);

