-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ObtenerCategorias
AS
BEGIN
    SELECT Id, Nombre
    FROM Categorias;
END