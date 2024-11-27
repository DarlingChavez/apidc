CREATE TABLE [dbo].[Libro]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Titulo] NVARCHAR(50) NOT NULL, 
    [AutorId] INT NOT NULL, 
    CONSTRAINT [FK_Libro_Autor] FOREIGN KEY ([AutorId]) REFERENCES [Autor]([Id])
)
