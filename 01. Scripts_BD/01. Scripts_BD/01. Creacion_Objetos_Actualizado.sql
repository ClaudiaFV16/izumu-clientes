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

--------------------   DATOS DE PRUEBA ACTUALIZADOS ----------------------------------------------------------------------

-- Tipos de Documento
INSERT INTO tb_TipoDocumento (Cod_TipoDocumento,NombreTipoDocumento) VALUES ('CC','Cedula de Ciudadania');
INSERT INTO tb_TipoDocumento (Cod_TipoDocumento,NombreTipoDocumento) VALUES ('PA','Pasaporte');
INSERT INTO tb_TipoDocumento (Cod_TipoDocumento,NombreTipoDocumento) VALUES ('TI','Tarjeta de Identidad');
INSERT INTO tb_TipoDocumento (Cod_TipoDocumento,NombreTipoDocumento) VALUES ('CE','Cedula de Extranjeria');

-- Planes de Medicina Prepagada
INSERT INTO tb_Planes (Nombre_Plan) VALUES ('Plan Basico - Cobertura Individual');
INSERT INTO tb_Planes (Nombre_Plan) VALUES ('Plan Premium - Cobertura Familiar');
INSERT INTO tb_Planes (Nombre_Plan) VALUES ('Plan Platino - Cobertura Ejecutiva');
INSERT INTO tb_Planes (Nombre_Plan) VALUES ('Plan Familiar - Hasta 6 Integrantes');

-- Clientes de Prueba Actualizados
INSERT INTO tb_Clientes 
    (TipoDocumentoId, NumeroDocumento, FechaNacimiento, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, DireccionResidencia, NumeroCelular, Email, PlanId)
VALUES 
    (1, '1234567890', '1985-06-15', 'Claudia', 'Andrea', 'Fernandez', 'Herrera', 'Calle 85 # 12-45, Oficina 302, Bogota', '3101234567', 'claudia.fernandez@empresa.com', 2),
    (2, '9876543210', '1990-12-30', 'Clara', 'Isabel', 'Fernandez', 'Vargas', 'Carrera 15 # 93-47, Apto 501, Bogota', '3007654321', 'clara.fernandez@gmail.com', 3),
    (3, '1122334455', '1978-03-20', 'Kelly', 'Alejandra', 'Villalobos', 'Martinez', 'Calle 72 # 10-23, Bogota', '3209876543', 'kelly.villalobos@estudiante.edu.co', 1);

-- Verificar datos insertados
SELECT 'Tipos de Documento:' as Info;
SELECT * FROM tb_TipoDocumento;

SELECT 'Planes:' as Info;
SELECT * FROM tb_Planes;

SELECT 'Clientes:' as Info;
SELECT 
    c.Id,
    td.Cod_TipoDocumento + ' - ' + td.NombreTipoDocumento as TipoDocumento,
    c.NumeroDocumento,
    c.FechaNacimiento,
    c.PrimerNombre + ' ' + ISNULL(c.SegundoNombre, '') + ' ' + c.PrimerApellido + ' ' + ISNULL(c.SegundoApellido, '') as NombreCompleto,
    c.DireccionResidencia,
    c.NumeroCelular,
    c.Email,
    p.Nombre_Plan as Plan
FROM tb_Clientes c
INNER JOIN tb_TipoDocumento td ON c.TipoDocumentoId = td.Id
INNER JOIN tb_Planes p ON c.PlanId = p.Id
ORDER BY c.Id; 