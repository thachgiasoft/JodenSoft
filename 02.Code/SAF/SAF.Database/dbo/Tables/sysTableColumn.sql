CREATE TABLE [dbo].[sysTableColumn] (
    [Iden]               INT            NOT NULL,
    [TableName]          NVARCHAR (100) NULL,
    [ColumnName]         NVARCHAR (100) NULL,
    [InsertDefaultValue] NVARCHAR (200) NULL,
    [UpdateDefaultValue] NVARCHAR (200) NULL,
	[CreatedBy]     INT          NULL,
    [CreatedOn]     DATETIME     NULL,
    [ModifiedBy]    INT          NULL,
    [ModifiedOn]    DATETIME     NULL,
    [VersionNumber] NUMERIC (18) NULL,
    CONSTRAINT [PK_sysTableColumn] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

