CREATE TABLE [dbo].[sysReport]
(
	[Iden] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [SqlScript] NVARCHAR(MAX) NOT NULL, 
    [DataSetAlias] NVARCHAR(400) NOT NULL, 
    [ParamList] NVARCHAR(MAX) NULL, 
    [ParamValueList] NVARCHAR(MAX) NULL,
	[IsActive] BIT CONSTRAINT [DF_sysReport_IsActive] DEFAULT ((1)) NOT NULL,
	[CreatedBy]     INT        NULL,
    [CreatedOn]     DATETIME   NULL,
    [ModifiedBy]    INT        NULL,
    [ModifiedOn]    DATETIME   NULL,
    [VersionNumber] ROWVERSION NULL,
	CONSTRAINT [PK_sysReport_Iden] PRIMARY KEY CLUSTERED ([Iden] ASC)
)
