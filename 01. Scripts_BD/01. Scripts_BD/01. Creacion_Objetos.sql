
Use DB_IZUMU;
go


-- TipoDocumento 
CREATE TABLE tb_TipoDocumento (
    Id INT PRIMARY KEY IDENTITY(1,1),
	Cod_TipoDocumento   VARCHAR(2),
    NombreTipoDocumento NVARCHAR(50) NOT NULL
);

-- Plan
CREATE TABLE tb_Planes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre_Plan NVARCHAR(100) NOT NULL
);

-- Clientes
CREATE TABLE tb_Clientes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TipoDocumentoId INT NOT NULL,
    NumeroDocumento NVARCHAR(50) NOT NULL,
    FechaNacimiento DATETIME NOT NULL,
    PrimerNombre NVARCHAR(100) NOT NULL,
    SegundoNombre NVARCHAR(100),
    PrimerApellido NVARCHAR(100) NOT NULL,
    SegundoApellido NVARCHAR(100),
    DireccionResidencia NVARCHAR(200) NOT NULL,
    NumeroCelular NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PlanId INT NOT NULL,
    CONSTRAINT FK_Clientes_TipoDocumento FOREIGN KEY (TipoDocumentoId) REFERENCES tb_TipoDocumento(Id),
    CONSTRAINT FK_Clientes_Plan FOREIGN KEY (PlanId) REFERENCES tb_Planes(Id),
    CONSTRAINT UQ_Clientes_NumeroDocumento UNIQUE (TipoDocumentoId, NumeroDocumento),
    CONSTRAINT UQ_Clientes_Email UNIQUE (Email)
);



--SELECT * FROM tb_TipoDocumento;
--SELECT * FROM tb_Planes;
--SELECT * FROM tb_Clientes;





--Drop table tb_Clientes;
--Drop table tb_TipoDocumento;
--Drop table tb_Planes;

--DROP PROCEDURE sp_GetClientes;
--DROP PROCEDURE sp_InsertCliente;
--DROP PROCEDURE sp_UpdateCliente;
--DROP PROCEDURE sp_DeleteCliente;
--DROP PROCEDURE sp_GetTipoDocumento;
--DROP PROCEDURE sp_GetPlan;


-- exec sp_GetClientes;
-- exec sp_GetTipoDocumento;
-- exec sp_GetPlan;
-- exec sp_DeleteCliente 5;


--------------------   datos de prueba ----------------------------------------------------------------------

INSERT INTO tb_TipoDocumento (Cod_TipoDocumento,NombreTipoDocumento) VALUES ('CC','Cédula de Ciudadanía');
INSERT INTO tb_TipoDocumento (Cod_TipoDocumento,NombreTipoDocumento) VALUES ('PA','Pasaporte');
INSERT INTO tb_TipoDocumento (Cod_TipoDocumento,NombreTipoDocumento) VALUES ('TI','Tarjeta de Identidad');
INSERT INTO tb_TipoDocumento (Cod_TipoDocumento,NombreTipoDocumento) VALUES ('CE','Cédula de Extranjería');


-----------------

INSERT INTO tb_Planes (Nombre_Plan) VALUES ('Plan Básico');
INSERT INTO tb_Planes (Nombre_Plan) VALUES ('Plan Premium');
INSERT INTO tb_Planes (Nombre_Plan) VALUES ('Plan Platino');
INSERT INTO tb_Planes (Nombre_Plan) VALUES ('Plan Familiar');
------

INSERT INTO tb_Clientes 
    (TipoDocumentoId, NumeroDocumento, FechaNacimiento, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, DireccionResidencia, NumeroCelular, Email, PlanId)
VALUES 
    (1, '1234567890', '1985-06-15', 'Juan', 'Carlos', 'Pérez', 'García', 'Calle 123, Bogotá', '3101234567', 'juan.perez@example.com', 2),
    (2, '9876543210', '1990-12-30', 'Ana', 'Maria', 'Sánchez', 'Rodríguez', 'Avenida 456, Medellín', '3007654321', 'ana.sanchez@example.com', 3),
    (3, '1122334455', '1978-03-20', 'Luis', NULL, 'Martínez', 'López', 'Carrera 789, Cali', '3209876543', 'luis.martinez@example.com', 1);
