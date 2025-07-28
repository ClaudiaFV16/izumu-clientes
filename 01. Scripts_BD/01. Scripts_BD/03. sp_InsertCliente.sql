USE DB_IZUMU;
GO

CREATE PROCEDURE sp_InsertCliente
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
    
    -- Validar campos requeridos no sean NULL
    IF @NumeroDocumento IS NULL or @NumeroDocumento = ''
    BEGIN
        RAISERROR ('El campo NumeroDocumento es obligatorio.', 16, 1);
        RETURN;
    END

    IF @FechaNacimiento IS NULL  or @FechaNacimiento = ''
    BEGIN
        RAISERROR ('El campo FechaNacimiento es obligatorio.', 16, 1);
        RETURN;
    END

    IF @PrimerNombre IS NULL  or @PrimerNombre = ''
    BEGIN
        RAISERROR ('El campo PrimerNombre es obligatorio.', 16, 1);
        RETURN;
    END

    IF @PrimerApellido IS NULL  or @PrimerApellido = ''
    BEGIN
        RAISERROR ('El campo PrimerApellido es obligatorio.', 16, 1);
        RETURN;
    END

    IF @DireccionResidencia IS NULL  or @DireccionResidencia = ''
    BEGIN
        RAISERROR ('El campo DireccionResidencia es obligatorio.', 16, 1);
        RETURN;
    END

    IF @NumeroCelular IS NULL  or @NumeroCelular = ''
    BEGIN
        RAISERROR ('El campo NumeroCelular es obligatorio.', 16, 1);
        RETURN;
    END

    IF @Email IS NULL  or @Email = ''
    BEGIN
        RAISERROR ('El campo Email es obligatorio.', 16, 1);
        RETURN;
    END

	IF EXISTS (
    SELECT 1 FROM tb_Clientes 
    WHERE Email = @Email
	)
	BEGIN
		RAISERROR ('El email ya existe en la base de datos.', 16, 1);
		RETURN;
	END

    -- Validar si el cliente ya existe
    IF EXISTS (
        SELECT 1 FROM tb_Clientes 
        WHERE TipoDocumentoId = @TipoDocumentoId AND NumeroDocumento = @NumeroDocumento
    )
    BEGIN
        RAISERROR ('El cliente con este tipo y número de documento ya está registrado.', 16, 1);
        RETURN;
    END
    
    -- Validar el formato del Email
    IF NOT (@Email LIKE '%_@__%.__%')
    BEGIN
        RAISERROR ('El formato del email no es válido.', 16, 1);
        RETURN;
    END

    -- Insertar el cliente si las validaciones son correctas
    INSERT INTO tb_Clientes (
        TipoDocumentoId,
        NumeroDocumento,
        FechaNacimiento,
        PrimerNombre,
        SegundoNombre,
        PrimerApellido,
        SegundoApellido,
        DireccionResidencia,
        NumeroCelular,
        Email,
        PlanId
    )
    VALUES (
        @TipoDocumentoId,
        @NumeroDocumento,
        @FechaNacimiento,
        @PrimerNombre,
        @SegundoNombre,
        @PrimerApellido,
        @SegundoApellido,
        @DireccionResidencia,
        @NumeroCelular,
        @Email,
        @PlanId
    );

END;
GO
