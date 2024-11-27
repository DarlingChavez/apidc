CREATE PROCEDURE [dbo].[sp_ObtenerAutor]
AS
	SET NOCOUNT ON;
	SELECT id,Nombre from Autor with(nolock)
RETURN 0
