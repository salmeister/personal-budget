CREATE TABLE [dbo].[payments] (
    [payment_pk]   INT             IDENTITY (1, 1) NOT NULL,
    [year_id]      INT             NOT NULL,
    [month_id]     INT             NOT NULL,
    [loan_id]      INT             NULL,
    [insurance_id] INT             NULL,
    [tuition_id]   INT             NULL,
    [vehicle_id]   INT             NULL,
    [amount]       DECIMAL (10, 2) NOT NULL,
    [due_date]     DATE            NULL,
    CONSTRAINT [PK_payments] PRIMARY KEY CLUSTERED ([payment_pk] ASC),
    CONSTRAINT [FK_payments_insurance] FOREIGN KEY ([insurance_id]) REFERENCES [dbo].[insurance] ([insurance_pk]),
    CONSTRAINT [FK_payments_loans] FOREIGN KEY ([loan_id]) REFERENCES [dbo].[loans] ([loan_pk]),
    CONSTRAINT [FK_payments_months] FOREIGN KEY ([month_id]) REFERENCES [dbo].[months] ([month_pk]),
    CONSTRAINT [FK_payments_tuition] FOREIGN KEY ([tuition_id]) REFERENCES [dbo].[tuition] ([tuition_pk]),
    CONSTRAINT [FK_payments_vehicles] FOREIGN KEY ([vehicle_id]) REFERENCES [dbo].[vehicles] ([vehicle_pk]),
    CONSTRAINT [FK_payments_years] FOREIGN KEY ([year_id]) REFERENCES [dbo].[years] ([year_pk])
);

