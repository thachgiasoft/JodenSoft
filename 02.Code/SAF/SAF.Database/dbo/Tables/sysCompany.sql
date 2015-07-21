CREATE TABLE [dbo].[sysCompany]
(
	[Iden] INT NOT NULL, 
    [Name] NVARCHAR(200) NULL, 
    [SplashImage] VARBINARY(MAX) NULL,
	[CreatedBy]     INT            NULL,
    [CreatedOn]     DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    [ModifiedOn]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL,
    CONSTRAINT [PK_sysCompany] PRIMARY KEY CLUSTERED ([Iden] ASC)
)
