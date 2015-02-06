CREATE TABLE [dbo].[sysCommonBillConfig]
(
	[Iden] INT NOT NULL, 
	[Name] NVARCHAR(200) NOT NULL,
	[Layout] INT CONSTRAINT [Default_sysCommonBillConfig_Layout] DEFAULT (1) NOT NULL ,
    [Config] NVARCHAR(MAX) CONSTRAINT [Default_sysCommonBillConfig_Config] DEFAULT ('') NOT NULL,
	[CreatedBy]     INT            NULL,
    [CreatedOn]     DATETIME       NULL,
    [ModifiedBy]    INT            NULL,
    [ModifiedOn]    DATETIME       NULL,
    [VersionNumber] ROWVERSION     NULL,
    CONSTRAINT [PK_sysCommonBillConfig] PRIMARY KEY CLUSTERED ([Iden] ASC)
)
