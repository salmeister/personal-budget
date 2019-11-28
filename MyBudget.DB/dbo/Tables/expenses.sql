CREATE TABLE [dbo].[expenses] (
    [expense_pk]      INT             IDENTITY (1, 1) NOT NULL,
    [year_id]         INT             NOT NULL,
    [month_id]        INT             NOT NULL,
    [expense_type_id] INT             NOT NULL,
    [amount]          DECIMAL (10, 2) NULL,
    [due_date]        DATE            NULL,
    CONSTRAINT [PK_expenses] PRIMARY KEY CLUSTERED ([expense_pk] ASC),
    CONSTRAINT [FK_expenses_expense_types] FOREIGN KEY ([expense_type_id]) REFERENCES [dbo].[expense_types] ([expense_type_pk]),
    CONSTRAINT [FK_expenses_months] FOREIGN KEY ([month_id]) REFERENCES [dbo].[months] ([month_pk]),
    CONSTRAINT [FK_expenses_years] FOREIGN KEY ([year_id]) REFERENCES [dbo].[years] ([year_pk])
);

