CREATE TABLE [dbo].[Veiculo]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Placa] VARCHAR(7) NOT NULL, 
    [Renavam] VARCHAR(12) NOT NULL, 
    [NomeProprietario] VARCHAR(60) NOT NULL, 
    [CPFProprietario] VARCHAR(11) NOT NULL, 
    [Bloqueado] BIT NOT NULL
)
