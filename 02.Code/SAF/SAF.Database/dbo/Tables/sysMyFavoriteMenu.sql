CREATE TABLE [dbo].[sysMyFavoriteMenu] (
    [Iden]          INT        NOT NULL,
    [MenuId]        INT        NULL,
    [UserId]        INT        NULL,
    [RowNumber]     INT        NULL,
    [CreatedBy]     INT        NULL,
    [CreatedOn]     DATETIME   NULL,
    [ModifiedBy]    INT        NULL,
    [ModifiedOn]    DATETIME   NULL,
    [VersionNumber] ROWVERSION NULL,
    CONSTRAINT [PK_sysMyFavoriteMenu] PRIMARY KEY CLUSTERED ([Iden] ASC)
);

