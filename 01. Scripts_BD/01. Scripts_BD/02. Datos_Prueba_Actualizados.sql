USE DB_IZUMU;
GO

-- Limpiar datos existentes
DELETE FROM tb_Clientes;
DELETE FROM tb_Planes;
DELETE FROM tb_TipoDocumento;

-- Resetear identity
DBCC CHECKIDENT ('tb_TipoDocumento', RESEED, 0);
DBCC CHECKIDENT ('tb_Planes', RESEED, 0);
DBCC CHECKIDENT ('tb_Clientes', RESEED, 0);

--------------------   DATOS DE PRUEBA ACTUALIZADOS ----------------------------------------------------------------------

-- Tipos de Documento
INSERT INTO tb_TipoDocumento (Cod_TipoDocumento,NombreTipoDocumento) VALUES ('CC','Cedula de Ciudadania');
INSERT INTO tb_TipoDocumento (Cod_TipoDocumento,NombreTipoDocumento) VALUES ('PA','Pasaporte');
INSERT INTO tb_TipoDocumento (Cod_TipoDocumento,NombreTipoDocumento) VALUES ('TI','Tarjeta de Identidad');
INSERT INTO tb_TipoDocumento (Cod_TipoDocumento,NombreTipoDocumento) VALUES ('CE','Cedula de Extranjeria');
INSERT INTO tb_TipoDocumento (Cod_TipoDocumento,NombreTipoDocumento) VALUES ('RC','Registro Civil');

-- Planes de Medicina Prepagada
INSERT INTO tb_Planes (Nombre_Plan) VALUES ('Plan Basico - Cobertura Individual');
INSERT INTO tb_Planes (Nombre_Plan) VALUES ('Plan Premium - Cobertura Familiar');
INSERT INTO tb_Planes (Nombre_Plan) VALUES ('Plan Platino - Cobertura Ejecutiva');
INSERT INTO tb_Planes (Nombre_Plan) VALUES ('Plan Familiar - Hasta 6 Integrantes');
INSERT INTO tb_Planes (Nombre_Plan) VALUES ('Plan Senior - Mayores de 60 anos');
INSERT INTO tb_Planes (Nombre_Plan) VALUES ('Plan Empresarial - Corporativo');

-- Clientes de Prueba
INSERT INTO tb_Clientes 
    (TipoDocumentoId, NumeroDocumento, FechaNacimiento, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, DireccionResidencia, NumeroCelular, Email, PlanId)
VALUES 
    -- Cliente 1: Ejecutivo
    (1, '80123456', '1982-03-15', 'Claudia', 'Andrea', 'Fernandez', 'Herrera', 'Calle 85 # 12-45, Oficina 302, Bogota', '3001234567', 'claudia.fernandez@empresa.com', 3),
    
    -- Cliente 2: Profesional independiente
    (1, '52123456', '1991-07-22', 'Clara', 'Isabel', 'Fernandez', 'Vargas', 'Carrera 15 # 93-47, Apto 501, Bogota', '3159876543', 'clara.fernandez@gmail.com', 2),
    
    -- Cliente 3: Estudiante
    (3, '1012345678', '2005-11-08', 'Kelly', 'Alejandra', 'Villalobos', 'Martinez', 'Calle 72 # 10-23, Bogota', '3204567890', 'kelly.villalobos@estudiante.edu.co', 1),
    
    -- Cliente 4: Adulto mayor
    (1, '23456789', '1958-12-03', 'Rosenda', 'Elena', 'Ramirez', 'Gutierrez', 'Carrera 7 # 26-20, Apto 1201, Bogota', '3108765432', 'rosenda.ramirez@hotmail.com', 5),
    
    -- Cliente 5: Extranjero
    (4, 'X123456789', '1988-04-18', 'Gilberto', 'Miguel', 'Berdejo', 'Johnson', 'Calle 116 # 7-15, Apto 302, Bogota', '3001112222', 'gilberto.berdejo@company.com', 3),
    
    -- Cliente 6: Familia
    (1, '98765432', '1985-09-30', 'Lolilyz', 'Sofia', 'Fernandez', 'Garcia', 'Carrera 19 # 90-47, Casa 25, Bogota', '3153334444', 'lolilyz.fernandez@familia.com', 4),
    
    -- Cliente 7: Emprendedor
    (1, '45678901', '1993-02-14', 'Jesus', 'Fernando', 'Valdez', 'Silva', 'Calle 100 # 8-60, Local 15, Bogota', '3205556666', 'jesus.valdez@startup.co', 2),
    
    -- Cliente 8: Profesional de la salud
    (1, '78901234', '1987-06-25', 'Dr. Loraine', 'Patricia', 'Melendez', 'Mendoza', 'Carrera 11 # 93-94, Apto 801, Bogota', '3007778888', 'loraine.melendez@medico.com', 3),
    
    -- Cliente 9: Jubilado
    (1, '34567890', '1960-08-12', 'Rodrigo', 'Carlos', 'Diaz', 'Moreno', 'Calle 127 # 15-30, Apto 502, Bogota', '3109990000', 'rodrigo.diaz@jubilado.com', 5),
    
    -- Cliente 10: Ejecutiva
    (1, '56789012', '1989-12-05', 'Catalina', 'Alejandra', 'Monrron', 'Rojas', 'Carrera 13 # 85-32, Oficina 1501, Bogota', '3152223333', 'catalina.monrron@ejecutiva.com', 3),
    
    -- Cliente 11: Medico especialista
    (1, '12345678', '1980-05-20', 'Dr. Norberto', 'Jose', 'Suarez', 'Pineda', 'Calle 93 # 14-20, Consultorio 405, Bogota', '3004445555', 'norberto.suarez@medico.com', 3),
    
    -- Cliente 12: Ingeniero
    (1, '87654321', '1986-10-12', 'Ing. Felipe', 'Alejandro', 'Caro', 'Rojas', 'Carrera 50 # 17-23, Apto 1203, Bogota', '3156667777', 'felipe.caro@ingeniero.com', 2),
    
    -- Cliente 13: Abogado
    (1, '65432109', '1983-07-08', 'Dr. Marcela', 'Carmen', 'Mendez', 'Lopez', 'Calle 76 # 11-34, Oficina 201, Bogota', '3208889999', 'marcela.mendez@abogado.com', 3),
    
    -- Cliente 14: Profesor universitario
    (1, '43210987', '1975-11-25', 'Prof. Alejandro', 'Alberto', 'Mancero', 'Gomez', 'Carrera 30 # 45-67, Apto 601, Bogota', '3101113333', 'alejandro.mancero@profesor.edu.co', 2),
    
    -- Cliente 15: Empresario
    (1, '21098765', '1970-04-30', 'Sr. Luis', 'Manuel', 'Navarro', 'Torres', 'Calle 100 # 19-54, Casa 8, Bogota', '3154446666', 'luis.navarro@empresario.com', 6);

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