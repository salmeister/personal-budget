CREATE TABLE [dbo].[institutions] (
    [institution_pk]       INT           IDENTITY (1, 1) NOT NULL,
    [institution_name]     VARCHAR (20)  NULL,
    [institution_address1] VARCHAR (100) NULL,
    [institution_address2] VARCHAR (100) NULL,
    [institution_city]     VARCHAR (100) NULL,
    [institution_state]    VARCHAR (2)   NULL,
    [institution_zip]      VARCHAR (10)  NULL,
    [active]               BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([institution_pk] ASC)
);

