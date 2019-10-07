DROP TABLE [banque_operation];
DROP TABLE [banque_compte];
DROP TABLE [banque_client];

CREATE TABLE [dbo].[banque_operation] (
    [id]           INT      IDENTITY (1, 1) NOT NULL,    
    [date_operation] DATETIME NOT NULL,
    [montant]      DECIMAL (10, 2)  NOT NULL,
	[compteId]	   INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[banque_compte] (
    [id]           INT          IDENTITY (1, 1) NOT NULL,
    [numero_compte]VARCHAR (50) NOT NULL,
    [ClientId]     INT          NOT NULL,
    [solde]        DECIMAL (10, 2) NOT NULL,
    [date_creation] DATETIME     NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


CREATE TABLE [dbo].[banque_client] (
    [id]        INT   IDENTITY (1, 1) NOT NULL,
    [nom]       VARCHAR (50) NOT NULL,
    [prenom]    VARCHAR (50) NOT NULL,
    [telephone] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
