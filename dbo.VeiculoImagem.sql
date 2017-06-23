CREATE TABLE [dbo].[VeiculoImagem]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IDVeiculo] INT NOT NULL, 
    [CaminhoImagem] VARCHAR(150) NOT NULL
)
