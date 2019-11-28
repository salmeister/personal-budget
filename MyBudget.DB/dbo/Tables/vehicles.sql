CREATE TABLE [dbo].[vehicles] (
    [vehicle_pk]      INT          IDENTITY (1, 1) NOT NULL,
    [vehicle_name]    VARCHAR (20) NULL,
    [vehicle_model]   VARCHAR (20) NULL,
    [vehicle_make]    VARCHAR (20) NULL,
    [vehicle_year_id] INT          NULL,
    [active]          BIT          NOT NULL,
    CONSTRAINT [PK_vehicles] PRIMARY KEY CLUSTERED ([vehicle_pk] ASC),
    CONSTRAINT [FK_vehicles_years] FOREIGN KEY ([vehicle_year_id]) REFERENCES [dbo].[years] ([year_pk])
);

