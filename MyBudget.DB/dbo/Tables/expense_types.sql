CREATE TABLE [dbo].[expense_types] (
    [expense_type_pk]   INT           IDENTITY (1, 1) NOT NULL,
    [expense_type]      VARCHAR (250) NOT NULL,
    [expense_type_abbr] VARCHAR (20)  NULL,
    CONSTRAINT [PK_expense_types] PRIMARY KEY CLUSTERED ([expense_type_pk] ASC)
);

