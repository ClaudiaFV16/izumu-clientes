# Script de compilación y ejecución para IZUMU Clientes
# Autor: Sistema de Gestión de Clientes
# Fecha: $(Get-Date -Format "yyyy-MM-dd")

Write-Host "🏥 IZUMU Clientes - Sistema de Gestión de Clientes" -ForegroundColor Cyan
Write-Host "================================================================" -ForegroundColor Cyan
Write-Host ""

# Verificar que .NET esté instalado
Write-Host "🔍 Verificando instalación de .NET..." -ForegroundColor Yellow
try {
    $dotnetVersion = dotnet --version
    Write-Host "✅ .NET versión: $dotnetVersion" -ForegroundColor Green
} catch {
    Write-Host "❌ Error: .NET no está instalado. Por favor instala .NET 8.0 o superior." -ForegroundColor Red
    exit 1
}

# Restaurar dependencias
Write-Host ""
Write-Host "📦 Restaurando dependencias..." -ForegroundColor Yellow
dotnet restore IzumuClientes/IzumuClientes.sln
if ($LASTEXITCODE -ne 0) {
    Write-Host "❌ Error al restaurar dependencias" -ForegroundColor Red
    exit 1
}
Write-Host "✅ Dependencias restauradas correctamente" -ForegroundColor Green

# Compilar la solución
Write-Host ""
Write-Host "🔨 Compilando la solución..." -ForegroundColor Yellow
dotnet build IzumuClientes/IzumuClientes.sln --configuration Release --no-restore
if ($LASTEXITCODE -ne 0) {
    Write-Host "❌ Error al compilar la solución" -ForegroundColor Red
    exit 1
}
Write-Host "✅ Solución compilada correctamente" -ForegroundColor Green

# Ejecutar pruebas unitarias
Write-Host ""
Write-Host "🧪 Ejecutando pruebas unitarias..." -ForegroundColor Yellow
dotnet test IzumuClientes/IzumuClientes.sln --configuration Release --no-build --verbosity normal
if ($LASTEXITCODE -ne 0) {
    Write-Host "❌ Algunas pruebas fallaron" -ForegroundColor Red
} else {
    Write-Host "✅ Todas las pruebas pasaron correctamente" -ForegroundColor Green
}

Write-Host ""
Write-Host "🎉 ¡Compilación completada exitosamente!" -ForegroundColor Green
Write-Host ""
Write-Host "📋 Próximos pasos:" -ForegroundColor Cyan
Write-Host "1. Configurar la base de datos SQL Server" -ForegroundColor White
Write-Host "2. Ejecutar los scripts de base de datos" -ForegroundColor White
Write-Host "3. Configurar las cadenas de conexión" -ForegroundColor White
Write-Host "4. Ejecutar el microservicio: dotnet run --project Microservice_Izumu/Microservice_Izumu" -ForegroundColor White
Write-Host "5. Ejecutar la aplicación web: dotnet run --project IzumuClientes" -ForegroundColor White
Write-Host ""
Write-Host "📚 Para más información, consulta el README.md" -ForegroundColor Cyan 