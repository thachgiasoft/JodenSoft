CREATE TABLE [dbo].[sdOrder] (
    [Iden]            INT           NOT NULL,
    [OrderNo]         NVARCHAR (50) NULL,
    [OrganizationId] INT           NULL,
    [Remark] NVARCHAR(MAX) NULL,
	[CreatedBy]     INT            NULL,
    [CreatedOn]     DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    [ModifiedOn]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL

    CONSTRAINT [PK_sdOrder]PRIMARY KEY CLUSTERED ([Iden] ASC)
);

