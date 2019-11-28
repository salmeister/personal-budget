CREATE TABLE [dbo].[tuition] (
    [tuition_pk]       INT          IDENTITY (1, 1) NOT NULL,
    [tuition_alias]    VARCHAR (50) NOT NULL,
    [family_member_id] INT          NOT NULL,
    [institution_id]   INT          NOT NULL,
    [active]           BIT          NOT NULL,
    CONSTRAINT [PK_tuition] PRIMARY KEY CLUSTERED ([tuition_pk] ASC),
    CONSTRAINT [FK_tuition_family_members] FOREIGN KEY ([family_member_id]) REFERENCES [dbo].[family_members] ([family_member_pk]),
    CONSTRAINT [FK_tuition_institutions] FOREIGN KEY ([institution_id]) REFERENCES [dbo].[institutions] ([institution_pk])
);

