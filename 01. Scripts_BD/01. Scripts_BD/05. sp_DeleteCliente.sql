USE DB_IZUMU;
GO

CREATE PROCEDURE sp_DeleteCliente
    @Id INT,
    @Resultado INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    
    IF EXISTS (SELECT 1 FROM tb_Clientes WHERE Id = @Id)
    BEGIN
        
        DELETE FROM tb_Clientes
        WHERE Id = @Id;
        
        
        SET @Resultado = 1;
    END
    ELSE
    BEGIN
        
        SET @Resultado = 0;
    END
END;
GO
