CREATE TABLE [dbo].[family_members] (
    [family_member_pk] INT          IDENTITY (1, 1) NOT NULL,
    [first_name]       VARCHAR (20) NULL,
    [middle_name]      VARCHAR (20) NULL,
    [last_name]        VARCHAR (20) NULL,
    [active]           BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([family_member_pk] ASC)
);

