CREATE TABLE [dbo].[loans] (
    [loan_pk]          INT          IDENTITY (1, 1) NOT NULL,
    [loan_alias]       VARCHAR (50) NOT NULL,
    [loan_type_id]     INT          NOT NULL,
    [family_member_id] INT          NULL,
    [property_id]      INT          NULL,
    [vehicle_id]       INT          NULL,
    [active]           BIT          NOT NULL,
    CONSTRAINT [PK_loans] PRIMARY KEY CLUSTERED ([loan_pk] ASC),
    CONSTRAINT [FK_loans_family_members] FOREIGN KEY ([family_member_id]) REFERENCES [dbo].[family_members] ([family_member_pk]),
    CONSTRAINT [FK_loans_loan_types] FOREIGN KEY ([loan_type_id]) REFERENCES [dbo].[loan_types] ([loan_type_pk]),
    CONSTRAINT [FK_loans_properties] FOREIGN KEY ([property_id]) REFERENCES [dbo].[properties] ([property_pk]),
    CONSTRAINT [FK_loans_vehicles] FOREIGN KEY ([vehicle_id]) REFERENCES [dbo].[vehicles] ([vehicle_pk])
);

