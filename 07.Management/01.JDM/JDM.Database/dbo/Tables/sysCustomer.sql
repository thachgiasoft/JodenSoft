CREATE TABLE [dbo].[sysCustomer]
(
	[Iden] INT NOT NULL , 
    [Name] NVARCHAR(200) NOT NULL, 
    [Address] NCHAR(200) NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [IsDeleted] BIT NOT NULL DEFAULT 0,
	[CreatedBy]           INT            NULL,
    [CreatedOn]           DATETIME       NULL,
    [ModifiedBy]          INT            NULL,
    [ModifiedOn]          DATETIME       NULL,
    [VersionNumber]       ROWVERSION     NULL,
	CONSTRAINT [PK_sysCustomer] PRIMARY KEY CLUSTERED ([Iden] ASC)
)
