CREATE TABLE [dbo].[properties] (
    [property_pk]       INT           IDENTITY (1, 1) NOT NULL,
    [property_name]     VARCHAR (20)  NULL,
    [property_address1] VARCHAR (100) NULL,
    [property_address2] VARCHAR (100) NULL,
    [property_city]     VARCHAR (100) NULL,
    [property_state]    VARCHAR (2)   NULL,
    [property_zip]      VARCHAR (10)  NULL,
    [active]            BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([property_pk] ASC)
);

