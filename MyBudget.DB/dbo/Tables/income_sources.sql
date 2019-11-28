CREATE TABLE [dbo].[income_sources] (
    [income_source_pk]   INT           IDENTITY (1, 1) NOT NULL,
    [income_source_acro] VARCHAR (5)   NULL,
    [income_source_name] VARCHAR (100) NULL,
    [active]             BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([income_source_pk] ASC)
);

