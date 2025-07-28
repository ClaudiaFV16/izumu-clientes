USE DB_IZUMU;
GO

CREATE PROCEDURE sp_UpdateCliente
    @Id INT,
    @TipoDocumentoId INT,
    @NumeroDocumento NVARCHAR(50),
    @FechaNacimiento DATETIME,
    @PrimerNombre NVARCHAR(100),
    @SegundoNombre NVARCHAR(100) = NULL,
    @PrimerApellido NVARCHAR(100),
    @SegundoApellido NVARCHAR(100) = NULL,
    @DireccionResidencia NVARCHAR(200),
    @NumeroCelular NVARCHAR(15),
    @Email NVARCHAR(100),
    @PlanId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar si el cliente existe
    IF NOT EXISTS (SELECT 1 FROM tb_Clientes WHERE Id = @Id)
    BEGIN
        RAISERROR ('El cliente no existe.', 16, 1);
        RETURN;
    END
    
    -- Validar el formato del Email
    IF NOT (@Email LIKE '%_@__%.__%')
    BEGIN
        RAISERROR ('El formato del email no es válido.', 16, 1);
        RETURN;
    END

   
    -- Actualizar el cliente
	UPDATE	c
    SET		c.TipoDocumentoId = @TipoDocumentoId,
			c.NumeroDocumento = @NumeroDocumento,
			c.FechaNacimiento = @FechaNacimiento,
			c.PrimerNombre = @PrimerNombre,
			c.SegundoNombre = @SegundoNombre,
			c.PrimerApellido = @PrimerApellido,
			c.SegundoApellido = @SegundoApellido,
			c.DireccionResidencia = @DireccionResidencia,
			c.NumeroCelular = @NumeroCelular,
			c.Email = @Email,
			c.PlanId = @PlanId
    FROM	tb_Clientes c
    INNER	JOIN tb_TipoDocumento td 
	ON		c.TipoDocumentoId = td.Id
    INNER	JOIN tb_Planes p 
	ON		c.PlanId = p.Id
    WHERE	c.Id = @Id;
END;
GO
