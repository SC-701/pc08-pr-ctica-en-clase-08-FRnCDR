CREATE PROCEDURE [dbo].[ObtenerSubCategorias]
	@IdCategoria UNIQUEIDENTIFIER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Consultar las subcategorías para el IdCategoria proporcionado
    SELECT 
        sc.Id,
        sc.Nombre AS Nombre,
        sc.IdCategoria
    FROM dbo.SubCategorias sc
    WHERE sc.IdCategoria = @IdCategoria;
END