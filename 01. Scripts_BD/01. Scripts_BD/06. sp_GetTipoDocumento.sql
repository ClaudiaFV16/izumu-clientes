USE DB_IZUMU;
GO

CREATE PROCEDURE sp_GetTipoDocumento
AS
BEGIN
    SET NOCOUNT ON;

    SELECT	Id, Cod_TipoDocumento, NombreTipoDocumento			
    FROM	tb_TipoDocumento;
END;
GO