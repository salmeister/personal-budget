CREATE TABLE [dbo].[income] (
    [income_pk]        INT             IDENTITY (1, 1) NOT NULL,
    [year_id]          INT             NOT NULL,
    [month_id]         INT             NOT NULL,
    [family_member_id] INT             NOT NULL,
    [income_source_id] INT             NOT NULL,
    [amount]           DECIMAL (10, 2) NULL,
    [received_date]    DATE            NULL,
    CONSTRAINT [PK_income] PRIMARY KEY CLUSTERED ([income_pk] ASC),
    CONSTRAINT [FK_income_family_members] FOREIGN KEY ([family_member_id]) REFERENCES [dbo].[family_members] ([family_member_pk]),
    CONSTRAINT [FK_income_income_sources] FOREIGN KEY ([income_source_id]) REFERENCES [dbo].[income_sources] ([income_source_pk]),
    CONSTRAINT [FK_income_months] FOREIGN KEY ([month_id]) REFERENCES [dbo].[months] ([month_pk]),
    CONSTRAINT [FK_income_years] FOREIGN KEY ([year_id]) REFERENCES [dbo].[years] ([year_pk])
);

