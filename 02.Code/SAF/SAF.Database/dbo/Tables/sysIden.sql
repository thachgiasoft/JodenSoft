CREATE TABLE [dbo].[sysIden] (
    [Iden]      INT            IDENTITY (1, 1) NOT NULL,
    [GroupName] NVARCHAR (100) NOT NULL,
    [MaxIden]   INT            NOT NULL,
    CONSTRAINT [PK_sysIden] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

