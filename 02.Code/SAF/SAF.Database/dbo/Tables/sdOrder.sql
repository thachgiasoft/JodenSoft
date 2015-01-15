CREATE TABLE [dbo].[sdOrder] (
    [Iden]            INT           NOT NULL,
    [OrderNo]         NVARCHAR (50) NULL,
    [OrganiaztionId] INT           NULL,
    [Remark] NVARCHAR(MAX) NULL, 
    PRIMARY KEY CLUSTERED ([Iden] ASC)
);

