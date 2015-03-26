CREATE TABLE [dbo].[sysReportConfig]
(
	[Iden] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [SqlScript] NVARCHAR(MAX) NOT NULL, 
    [TableList] NVARCHAR(200) NOT NULL, 
    [ParamList] NVARCHAR(MAX) NULL, 
    [ParamValueList] NVARCHAR(MAX) NULL,
	[IsActive] BIT CONSTRAINT [DF_sysReportConfig_IsActive] DEFAULT ((1)) NOT NULL,
	[CreatedBy]     INT        NULL,
    [CreatedOn]     DATETIME   NULL,
    [ModifiedBy]    INT        NULL,
    [ModifiedOn]    DATETIME   NULL,
    [VersionNumber] ROWVERSION NULL,
	CONSTRAINT [PK_sysReportConfig_Iden] PRIMARY KEY CLUSTERED ([Iden] ASC)
)
