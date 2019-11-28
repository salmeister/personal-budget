CREATE TABLE [dbo].[insurance] (
    [insurance_pk]      INT          IDENTITY (1, 1) NOT NULL,
    [insurance_alias]   VARCHAR (50) NOT NULL,
    [insurance_type_id] INT          NOT NULL,
    [family_member_id]  INT          NULL,
    [property_id]       INT          NULL,
    [vehicle_id]        INT          NULL,
    [active]            BIT          NOT NULL,
    CONSTRAINT [PK_insurance] PRIMARY KEY CLUSTERED ([insurance_pk] ASC),
    CONSTRAINT [FK_insurance_family_members] FOREIGN KEY ([family_member_id]) REFERENCES [dbo].[family_members] ([family_member_pk]),
    CONSTRAINT [FK_insurance_insurance_types] FOREIGN KEY ([insurance_type_id]) REFERENCES [dbo].[insurance_types] ([insur_type_pk]),
    CONSTRAINT [FK_insurance_properties] FOREIGN KEY ([property_id]) REFERENCES [dbo].[properties] ([property_pk]),
    CONSTRAINT [FK_insurance_vehicles] FOREIGN KEY ([vehicle_id]) REFERENCES [dbo].[vehicles] ([vehicle_pk])
);

