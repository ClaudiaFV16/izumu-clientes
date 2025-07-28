# 🚀 Instrucciones de Compilación y Ejecución

## 📋 Prerrequisitos

### Software Requerido:
- **.NET 8.0 SDK** o superior
- **SQL Server** (Express, Developer o Enterprise)
- **SQL Server Management Studio** (opcional, para ejecutar scripts)
- **Visual Studio 2022** o **VS Code** (opcional)

### Verificar Instalación:
```powershell
dotnet --version
# Debe mostrar 8.0.x o superior
```

## 🔨 Compilación Automática

### Opción 1: Script Automático (Recomendado)
```powershell
# En PowerShell, desde la raíz del proyecto:
.\build.ps1
```

### Opción 2: Comandos Manuales
```powershell
# 1. Restaurar dependencias
dotnet restore IzumuClientes/IzumuClientes.sln

# 2. Compilar la solución
dotnet build IzumuClientes/IzumuClientes.sln --configuration Release

# 3. Ejecutar pruebas
dotnet test IzumuClientes/IzumuClientes.sln --configuration Release
```

## 🗄️ Configuración de Base de Datos

### Paso 1: Crear Base de Datos
```sql
-- En SQL Server Management Studio:
CREATE DATABASE DB_IZUMU;
GO
USE DB_IZUMU;
GO
```

### Paso 2: Ejecutar Scripts de Base de Datos
```sql
-- Opción A: Script completo (recomendado)
-- Ejecutar: 01. Scripts_BD/01. Scripts_BD/01. Creacion_Objetos_Actualizado.sql

-- Opción B: Scripts separados
-- 1. 01. Creacion_Objetos.sql
-- 2. 02. sp_GetClientes.sql
-- 3. 03. sp_InsertCliente.sql
-- 4. 04. sp_UpdateCliente.sql
-- 5. 05. sp_DeleteCliente.sql
-- 6. 06. sp_GetTipoDocumento.sql
-- 7. 07. sp_GetPlan.sql
-- 8. 02. Datos_Prueba_Actualizados.sql
```

### Paso 3: Configurar Connection String
Editar `Microservice_Izumu/Microservice_Izumu/appsettings.json`:
```json
{
  "ConnectionStrings": {
    "Bd_Izumu_Cx": "Server=localhost;Database=DB_IZUMU;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

## 🚀 Ejecución del Sistema

### Opción 1: Script Automático
```powershell
# Ejecutar después de la compilación:
.\run.ps1
```

### Opción 2: Ejecución Manual

#### Terminal 1 - Microservicio:
```powershell
cd Microservice_Izumu/Microservice_Izumu
dotnet run --configuration Release
```

#### Terminal 2 - Aplicación Web:
```powershell
cd IzumuClientes
dotnet run --configuration Release
```

## 📱 URLs de Acceso

Una vez ejecutado el sistema:

- **🌐 Aplicación Web**: http://localhost:5000
- **🔧 Microservicio API**: http://localhost:5020
- **📚 Swagger API**: http://localhost:5020/swagger

## 🧪 Ejecutar Pruebas

### Todas las Pruebas:
```powershell
dotnet test IzumuClientes/IzumuClientes.sln --configuration Release
```

### Pruebas Específicas:
```powershell
# Pruebas del microservicio
dotnet test MicroService_Izumu.Test --configuration Release

# Pruebas del frontend
dotnet test IzumuClientes.Tests --configuration Release
```

## 🔧 Solución de Problemas

### Error: "No se puede encontrar el proyecto"
```powershell
# Verificar que estás en el directorio correcto
pwd
# Debe mostrar: ...\New_IzumuClientes
```

### Error: "Connection string no válida"
- Verificar que SQL Server esté ejecutándose
- Verificar que la base de datos DB_IZUMU exista
- Verificar el connection string en appsettings.json

### Error: "Puerto en uso"
```powershell
# Cambiar puertos en:
# - IzumuClientes/Properties/launchSettings.json
# - Microservice_Izumu/Properties/launchSettings.json
```

### Error: "Dependencias no encontradas"
```powershell
# Limpiar y restaurar:
dotnet clean IzumuClientes/IzumuClientes.sln
dotnet restore IzumuClientes/IzumuClientes.sln
dotnet build IzumuClientes/IzumuClientes.sln
```

## 📊 Verificación de Instalación

### 1. Verificar Compilación:
```powershell
# Debe mostrar "Build succeeded"
dotnet build IzumuClientes/IzumuClientes.sln --configuration Release
```

### 2. Verificar Pruebas:
```powershell
# Debe mostrar "Test Run Successful"
dotnet test IzumuClientes/IzumuClientes.sln --configuration Release
```

### 3. Verificar Base de Datos:
```sql
-- En SQL Server Management Studio:
USE DB_IZUMU;
SELECT COUNT(*) FROM tb_Clientes;
-- Debe mostrar 3 o 15 clientes (dependiendo del script usado)
```

### 4. Verificar APIs:
- Abrir http://localhost:5020/swagger
- Probar endpoint GET /api/Cliente/GetClientes

## 🎯 Comandos Rápidos

```powershell
# Compilar y ejecutar todo
.\build.ps1
.\run.ps1

# Solo compilar
dotnet build IzumuClientes/IzumuClientes.sln --configuration Release

# Solo pruebas
dotnet test IzumuClientes/IzumuClientes.sln --configuration Release

# Limpiar todo
dotnet clean IzumuClientes/IzumuClientes.sln
```

## 📞 Soporte

Si encuentras problemas:
1. Verificar que .NET 8.0 esté instalado
2. Verificar que SQL Server esté ejecutándose
3. Verificar los connection strings
4. Revisar los logs de error en la consola

---

**¡El sistema está listo para usar!** 🎉 