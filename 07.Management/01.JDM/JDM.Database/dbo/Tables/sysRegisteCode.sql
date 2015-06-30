CREATE TABLE [dbo].[sysRegisteCode]
(
	[Iden] INT NOT NULL ,
	[CustomerId] INT NOT NULL ,
	[MachineName] NVARCHAR(100) NOT NULL,
	[MachineCode] NVARCHAR(500) NOT NULL,
	[Version] NVARCHAR(50) NOT NULL,
	[RegisteDate] DATETIME NOT NULL,
	[ExpiredDate] DATETIME NOT NULL,
	[OnLineLimit] INT NOT NULL DEFAULT(0),
	[CreatedBy]           INT            NULL,
    [CreatedOn]           DATETIME       NULL,
    [ModifiedBy]          INT            NULL,
    [ModifiedOn]          DATETIME       NULL,
    [VersionNumber]       ROWVERSION     NULL,
	CONSTRAINT [PK_sysRegisteCode] PRIMARY KEY CLUSTERED ([Iden] ASC),
	CONSTRAINT [FK_sysRegisteCode_sysCustomer] FOREIGN KEY (CustomerId) REFERENCES [dbo].[sysCustomer]([Iden]) ON DELETE CASCADE ON UPDATE CASCADE
)
