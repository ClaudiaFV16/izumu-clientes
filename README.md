# 🏥 IZUMU Clientes - Sistema de Gestión de Clientes

## 📋 Descripción del Proyecto

Sistema completo para la gestión de clientes de medicina prepagada, desarrollado como prueba técnica. El proyecto incluye una aplicación web ASP.NET Core que consume un microservicio API para administrar la información de clientes.

## 🏗️ Arquitectura del Sistema

### Componentes Principales:
- **Frontend**: Aplicación web ASP.NET Core con Razor Pages
- **Backend**: Microservicio API en .NET Core
- **Base de Datos**: SQL Server con stored procedures
- **Pruebas**: Suite de pruebas unitarias con NUnit

### Tecnologías Utilizadas:
- **.NET Core 6/8**
- **ASP.NET Core Razor Pages**
- **Entity Framework Core**
- **SQL Server**
- **Bootstrap 5**
- **NUnit** (Pruebas unitarias)
- **Swagger** (Documentación API)

## 📁 Estructura del Proyecto

```
izumu-clientes/
├── IzumuClientes/                 # Aplicación Web Frontend
│   ├── Components/                # Componentes reutilizables
│   ├── Services/                  # Servicios de negocio
│   ├── Models/                    # Modelos de datos
│   ├── Pages/                     # Páginas Razor
│   └── wwwroot/                   # Archivos estáticos
├── Microservice_Izumu/            # Microservicio API
│   └── Microservice_Izumu/        # Proyecto del microservicio
│       ├── Controllers/           # Controladores API
│       ├── Models/                # Modelos DTO
│       └── Data/                  # Contexto de base de datos
├── MicroService_Izumu.Test/       # Pruebas unitarias del microservicio
├── IzumuClientes.Tests/           # Pruebas unitarias del frontend
├── 01. Scripts_BD/                # Scripts de base de datos
│   └── 01. Scripts_BD/            # Scripts organizados
├── README.md                      # Documentación principal
├── GIT_SETUP.md                   # Instrucciones de Git
├── INSTRUCCIONES_COMPILACION.md   # Instrucciones de compilación
├── build.ps1                      # Script de compilación
└── run.ps1                        # Script de ejecución
```

## ✅ Criterios de Aceptación Cumplidos

### Funcionales:
- ✅ **CRUD completo** de clientes
- ✅ **Validación de cliente duplicado** (tipo + número documento)
- ✅ **Validación de email** con formato correcto
- ✅ **Formato de fecha** dd-MM-yyyy
- ✅ **Calendario** para selección de fechas
- ✅ **Mensajes informativos** de resultado
- ✅ **Confirmación** antes de eliminar

### Técnicos:
- ✅ **Scripts de base de datos** completos
- ✅ **Códigos HTTP** apropiados (200, 500, 404)
- ✅ **Métodos HTTP** correctos (GET, POST, PUT, DELETE)
- ✅ **Pruebas unitarias** implementadas (microservicio + frontend)
- ✅ **Componentes** reutilizables
- ✅ **Servicios** separados en frontend

## 🚀 Características Implementadas

### Frontend:
- **Componentes reutilizables**: Formulario y tabla de clientes
- **Servicios de negocio**: Separación de lógica de comunicación con API
- **Validaciones en tiempo real**: Email, celular, campos requeridos
- **Interfaz responsive**: Diseño adaptativo con Bootstrap
- **Manejo de errores**: Mensajes informativos para el usuario

### Backend:
- **API RESTful**: Endpoints bien estructurados
- **Validaciones robustas**: En stored procedures
- **Manejo de excepciones**: Códigos de respuesta apropiados
- **Documentación**: Swagger integrado
- **CORS configurado**: Para comunicación frontend-backend

### Base de Datos:
- **Scripts completos**: Creación de tablas y stored procedures
- **Constraints**: Llaves primarias, foráneas y únicas
- **Validaciones**: Cliente duplicado, email válido
- **Datos de prueba**: 15 clientes con perfiles variados y 6 planes detallados

## 🛠️ Instalación y Configuración

### Prerrequisitos:
- .NET Core 6.0 o superior
- SQL Server
- Visual Studio 2022 o VS Code

### Pasos de Instalación:

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/ClaudiaFV16/izumu-clientes.git
   cd izumu-clientes
   ```

2. **Configurar Base de Datos**
   ```sql
   -- Ejecutar scripts en orden:
   -- 1. 01. Creacion_Objetos.sql (estructura básica)
   -- 2. 02. sp_GetClientes.sql
   -- 3. 03. sp_InsertCliente.sql
   -- 4. 04. sp_UpdateCliente.sql
   -- 5. 05. sp_DeleteCliente.sql
   -- 6. 06. sp_GetTipoDocumento.sql
   -- 7. 07. sp_GetPlan.sql
   -- 8. 02. Datos_Prueba_Actualizados.sql (datos mejorados)
   ```

3. **Configurar Connection String**
   - Copiar `Microservice_Izumu/appsettings.example.json` a `appsettings.json`
   - Editar `Microservice_Izumu/appsettings.json`
   - Actualizar `Bd_Izumu_Cx` con tu servidor SQL

4. **Ejecutar Microservicio**
   ```bash
   cd Microservice_Izumu/Microservice_Izumu
   dotnet run
   ```

5. **Ejecutar Aplicación Web**
   ```bash
   cd IzumuClientes
   dotnet run
   ```

## 📊 Funcionalidades

### Gestión de Clientes:
- **Listar**: Vista de todos los clientes registrados
- **Crear**: Formulario para agregar nuevos clientes
- **Editar**: Modificar información existente
- **Eliminar**: Borrar clientes con confirmación

### Validaciones Implementadas:
- **Campos requeridos**: Validación de obligatoriedad
- **Email válido**: Formato correcto de correo electrónico
- **Cliente duplicado**: Prevención de registros duplicados
- **Fecha de nacimiento**: Validación de edad razonable
- **Número de celular**: Formato de 10 dígitos

### Datos de Prueba Mejorados:
- **15 clientes** con perfiles profesionales variados
- **6 planes** de medicina prepagada con descripciones detalladas
- **5 tipos de documento** incluyendo Registro Civil
- **Direcciones realistas** de Bogotá
- **Emails profesionales** con dominios apropiados

## 🧪 Pruebas

### Ejecutar Pruebas Unitarias:
```bash
cd MicroService_Izumu.Test
dotnet test
```

### Pruebas Implementadas:
- **ClienteServicesTest**: Pruebas del servicio de clientes del microservicio
- **ClienteServiceTests**: Pruebas del servicio de clientes del frontend
- **Validaciones**: Pruebas de lógica de negocio
- **Manejo de errores**: Pruebas de excepciones
- **Modelos**: Pruebas de propiedades de todos los modelos

## 🔧 Configuración de Desarrollo

### Variables de Entorno:
- **Connection String**: Configurar en `appsettings.json`
- **URL del Microservicio**: Configurar en `appsettings.json` del frontend

### Puertos por Defecto:
- **Frontend**: http://localhost:5000
- **Microservicio**: http://localhost:5020
- **Swagger**: http://localhost:5020/swagger

## 📝 Notas de Desarrollo

### Mejoras Implementadas:
1. **Refactoring de código**: Eliminación de código comentado
2. **Separación de responsabilidades**: Servicios y componentes
3. **Validaciones mejoradas**: Frontend y backend
4. **Seguridad**: Uso de POST en lugar de GET para datos sensibles
5. **Mantenibilidad**: Código más limpio y organizado

### Patrones Utilizados:
- **Repository Pattern**: Para acceso a datos
- **Service Layer**: Para lógica de negocio
- **Component Pattern**: Para reutilización de UI
- **Dependency Injection**: Para inyección de dependencias

## 🤝 Contribución

Para contribuir al proyecto:
1. Fork el repositorio
2. Crear una rama para tu feature
3. Commit tus cambios
4. Push a la rama
5. Crear un Pull Request

---

**Desarrollado como prueba técnica para el área de Sistemas de Información**
