CREATE TABLE [dbo].[medecin]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [NomMedecin] VARCHAR(50) NOT NULL, 
    [TelMedecin] VARCHAR(50) NOT NULL, 
    [DateEmbauche] DATE NOT NULL, 
    [SpecialiteMedecin] VARCHAR(50) NOT NULL,

)
CREATE TABLE [dbo].[RDV]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [DateRDV] DATE NOT NULL, 
    [HeureRDV] VARCHAR(50) NOT NULL, 
    [CodeMedecin] INT NOT NULL, 
    [CodePatient] INT NOT NULL,

)
CREATE TABLE [dbo].[Patient]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),  
    [NomPatient] VARCHAR(50) NOT NULL, 
    [AdressePatient] VARCHAR(50) NOT NULL, 
    [dateNaissance] DATE NOT NULL, 
    [sexePatient] VARCHAR(50) NOT NULL,
)
