CREATE TABLE [dbo].[contact_wpf] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [nom]       VARCHAR (50) NOT NULL,
    [prenom]    VARCHAR (50) NOT NULL,
    [telephone] VARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[email_wpf] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [mail]      VARCHAR (MAX) NOT NULL,
    [contactid] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

