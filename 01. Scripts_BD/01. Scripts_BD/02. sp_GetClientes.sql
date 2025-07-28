USE DB_IZUMU;
GO

CREATE PROCEDURE sp_GetClientes
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
			c.Id,
			c.TipoDocumentoId,
			td.NombreTipoDocumento,
			c.NumeroDocumento,
			FORMAT(c.FechaNacimiento, 'dd-MM-yyyy') AS FechaNacimiento,
			c.PrimerNombre,
			c.SegundoNombre,
			c.PrimerApellido,
			c.SegundoApellido,
			c.DireccionResidencia,
			c.NumeroCelular,
			c.Email,
			c.PlanId,
			p.Nombre_Plan
    FROM	tb_Clientes c
    INNER	JOIN tb_TipoDocumento td 
	ON		c.TipoDocumentoId = td.Id
    INNER	JOIN tb_Planes p 
	ON		c.PlanId = p.Id;
END;
GO
