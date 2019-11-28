CREATE TABLE [dbo].[months] (
    [month_pk]   INT          NOT NULL,
    [month_abbr] VARCHAR (3)  NOT NULL,
    [month_name] VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_months] PRIMARY KEY CLUSTERED ([month_pk] ASC)
);

