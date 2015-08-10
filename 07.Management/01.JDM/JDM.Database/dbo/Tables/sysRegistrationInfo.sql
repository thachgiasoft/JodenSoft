CREATE TABLE [dbo].[sysRegistrationInfo]
(
	[Iden] INT NOT NULL ,
	[CustomerId] INT NOT NULL ,
	[MachineName] NVARCHAR(100) NOT NULL,
	[MachineCode] NVARCHAR(500) NOT NULL,
	[Version] INT NOT NULL,
	[RegistrationDate] DATETIME NOT NULL,
	[ExpiredDate] DATETIME NOT NULL,
	[OnLineLimit] INT NOT NULL DEFAULT(0),
	[IsDeleted] BIT NOT NULL DEFAULT(0),
	[ActivationResponse] NVARCHAR(MAX) NULL,
	[CreatedBy]           INT            NULL,
    [CreatedOn]           DATETIME       NULL,
    [ModifiedBy]          INT            NULL,
    [ModifiedOn]          DATETIME       NULL,
    [VersionNumber]       ROWVERSION     NULL,
	CONSTRAINT [PK_sysRegistrationInfo] PRIMARY KEY CLUSTERED ([Iden] ASC),
	CONSTRAINT [FK_sysRegistrationInfo_sysCustomer] FOREIGN KEY (CustomerId) REFERENCES [dbo].[sysCustomer]([Iden]) ON DELETE CASCADE ON UPDATE CASCADE
)
