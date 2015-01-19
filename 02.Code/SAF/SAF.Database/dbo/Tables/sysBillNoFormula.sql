CREATE TABLE [dbo].[sysBillNoFormula] (
    [Iden]        INT          NOT NULL,
    [BillNoType]  VARCHAR (50) NOT NULL,
    [ResetType]   VARCHAR (50) CONSTRAINT [Default_sysBillNoFormula_ResetType] DEFAULT ('day') NOT NULL,
    [Separator]   VARCHAR (50) CONSTRAINT [Default_sysBillNoFormula_Separator] DEFAULT ('') NOT NULL,
    [Prefix]      VARCHAR (50) CONSTRAINT [Default_sysBillNoFormula_Prefix] DEFAULT ('') NOT NULL,
    [YearFormat]  VARCHAR (50) CONSTRAINT [Default_sysBillNoFormula_YearPart] DEFAULT ('yyyy') NOT NULL,
    [MonthFormat] VARCHAR (50) CONSTRAINT [Default_sysBillNoFormula_MonthPart] DEFAULT ('mm') NOT NULL,
    [DayFormat]   VARCHAR (50) CONSTRAINT [Default_sysBillNoFormula_DayPart] DEFAULT ('dd') NOT NULL,
    [Midfix]      VARCHAR (50) CONSTRAINT [Default_sysBillNoFormula_Midfix] DEFAULT ('') NOT NULL,
    [CurrentIden] INT          CONSTRAINT [Default_sysBillNoFormula_CurrentMaxIden] DEFAULT ((0)) NOT NULL,
    [IdenLength]  INT          CONSTRAINT [Default_sysBillNoFormula_BillNoLength] DEFAULT ((4)) NOT NULL,
    [CurrentDate] DATETIME     CONSTRAINT [Default_sysBillNoFormula_CurrentMaxDate] DEFAULT (getdate()) NULL,
    [Suffix]      VARCHAR (50) CONSTRAINT [Default_sysBillNoFormula_Suffix] DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_sysBillNoFormula_Iden] PRIMARY KEY CLUSTERED ([Iden] ASC),
    CONSTRAINT [chk_sysBillNoFormula_CurrentDate] CHECK ([ResetType]='None' OR( [ResetType]<>'None' AND [CurrentDate] IS NOT NULL)),
    CONSTRAINT [CHK_sysBillNoFormula_DayFormat] CHECK ([DayFormat]='' OR [DayFormat]='d' OR [DayFormat]='dd'),
    CONSTRAINT [CHK_sysBillNoFormula_MonthFormat] CHECK ([MonthFormat]='' OR [MonthFormat]='m' OR [MonthFormat]='mm'),
    CONSTRAINT [CHK_sysBillNoFormula_ResetType] CHECK ([ResetType]='None' OR [ResetType]='day' OR [ResetType]='month' OR [ResetType]='year'),
    CONSTRAINT [CHK_sysBillNoFormula_ResetType_Map] CHECK ([ResetType]='None' OR charindex(left([ResetType],(1)),([YearFormat]+[MonthFormat])+[DayFormat])>(0)),
    CONSTRAINT [CHK_sysBillNoFormula_YearFormat] CHECK ([YearFormat]='' OR [YearFormat]='yy' OR [YearFormat]='yyyy'),
    CONSTRAINT [UQ_sysBillNoFormula_BillNoType] UNIQUE NONCLUSTERED ([BillNoType] ASC)
);

