CREATE TABLE [dbo].[sysIden] (
    [Iden]      INT            IDENTITY (1, 1) NOT NULL,
    [GroupName] NVARCHAR (100) NOT NULL,
    [MaxIden]   INT            NOT NULL,
	[CreatedBy]     INT          NULL,
    [CreatedOn]     DATETIME     NULL,
    [ModifiedBy]    INT          NULL,
    [ModifiedOn]    DATETIME     NULL,
    [VersionNumber] NUMERIC (18) NULL,
    CONSTRAINT [PK_sysIden] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

