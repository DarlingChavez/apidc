/*
Script de implementación para dbjbg

Una herramienta generó este código.
Los cambios realizados en este archivo podrían generar un comportamiento incorrecto y se perderán si
se vuelve a generar el código.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "dbjbg"
:setvar DefaultFilePrefix "dbjbg"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detectar el modo SQLCMD y deshabilitar la ejecución del script si no se admite el modo SQLCMD.
Para volver a habilitar el script después de habilitar el modo SQLCMD, ejecute lo siguiente:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'El modo SQLCMD debe estar habilitado para ejecutar correctamente este script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'La operación de refactorización Cambiar nombre con la clave 625378f4-c753-419f-98e5-079229917fde se ha omitido; no se cambiará el nombre del elemento [dbo].[Autor].[Descripcion] (SqlSimpleColumn) a Nombre';


GO
PRINT N'Creando Tabla [dbo].[Autor]...';


GO
CREATE TABLE [dbo].[Autor] (
    [Id]     INT           NOT NULL,
    [Nombre] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando Tabla [dbo].[Libro]...';


GO
CREATE TABLE [dbo].[Libro] (
    [Id]      INT           NOT NULL,
    [Titulo]  NVARCHAR (50) NOT NULL,
    [AutorId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando Clave externa [dbo].[FK_Libro_Autor]...';


GO
ALTER TABLE [dbo].[Libro] WITH NOCHECK
    ADD CONSTRAINT [FK_Libro_Autor] FOREIGN KEY ([AutorId]) REFERENCES [dbo].[Autor] ([Id]);


GO
-- Paso de refactorización para actualizar el servidor de destino con los registros de transacciones implementadas

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '625378f4-c753-419f-98e5-079229917fde')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('625378f4-c753-419f-98e5-079229917fde')

GO

GO
PRINT N'Comprobando los datos existentes con las restricciones recién creadas';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Libro] WITH CHECK CHECK CONSTRAINT [FK_Libro_Autor];


GO
PRINT N'Actualización completada.';


GO
