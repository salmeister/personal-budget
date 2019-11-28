CREATE TABLE [dbo].[loan_types] (
    [loan_type_pk]   INT          IDENTITY (1, 1) NOT NULL,
    [loan_type_name] VARCHAR (20) NULL,
    [active]         BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([loan_type_pk] ASC)
);

