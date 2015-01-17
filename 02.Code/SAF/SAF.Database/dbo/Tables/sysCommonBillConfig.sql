CREATE TABLE [dbo].[sysCommonBillConfig]
(
	[Iden] INT NOT NULL, 
    [Config] NVARCHAR(MAX) NOT NULL,
	[CreatedBy]     INT            NULL,
    [CreatedOn]     DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    [ModifiedOn]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL,
    CONSTRAINT [PK_sysCommonBillConfig] PRIMARY KEY CLUSTERED ([Iden] ASC)
)
