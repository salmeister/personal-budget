CREATE TABLE [dbo].[insurance_types] (
    [insur_type_pk]   INT          IDENTITY (1, 1) NOT NULL,
    [insur_type_name] VARCHAR (20) NULL,
    [active]          BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([insur_type_pk] ASC)
);

