CREATE TABLE [dbo].[sysTableColumn] (
    [Iden]               INT            NOT NULL,
    [TableName]          NVARCHAR (100) NULL,
    [ColumnName]         NVARCHAR (100) NULL,
    [InsertDefaultValue] NVARCHAR (200) NULL,
    [UpdateDefaultValue] NVARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([Iden] ASC)
);

