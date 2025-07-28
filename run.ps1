# Script de ejecución para IZUMU Clientes
# Autor: Sistema de Gestión de Clientes

Write-Host "🚀 Iniciando IZUMU Clientes..." -ForegroundColor Cyan
Write-Host ""

# Verificar que la solución esté compilada
Write-Host "🔍 Verificando compilación..." -ForegroundColor Yellow
if (-not (Test-Path "IzumuClientes/bin/Release/net8.0")) {
    Write-Host "❌ La solución no está compilada. Ejecuta primero: .\build.ps1" -ForegroundColor Red
    exit 1
}
Write-Host "✅ Solución compilada encontrada" -ForegroundColor Green

# Iniciar el microservicio en segundo plano
Write-Host ""
Write-Host "🔧 Iniciando microservicio..." -ForegroundColor Yellow
Start-Process -FilePath "dotnet" -ArgumentList "run", "--project", "Microservice_Izumu/Microservice_Izumu", "--configuration", "Release" -WindowStyle Minimized
Write-Host "✅ Microservicio iniciado en http://localhost:5020" -ForegroundColor Green

# Esperar un momento para que el microservicio se inicie
Write-Host "⏳ Esperando que el microservicio se inicie..." -ForegroundColor Yellow
Start-Sleep -Seconds 5

# Iniciar la aplicación web
Write-Host ""
Write-Host "🌐 Iniciando aplicación web..." -ForegroundColor Yellow
Start-Process -FilePath "dotnet" -ArgumentList "run", "--project", "IzumuClientes", "--configuration", "Release"
Write-Host "✅ Aplicación web iniciada en http://localhost:5000" -ForegroundColor Green

Write-Host ""
Write-Host "🎉 ¡Sistema iniciado correctamente!" -ForegroundColor Green
Write-Host ""
Write-Host "📱 URLs de acceso:" -ForegroundColor Cyan
Write-Host "• Aplicación Web: http://localhost:5000" -ForegroundColor White
Write-Host "• Microservicio API: http://localhost:5020" -ForegroundColor White
Write-Host "• Swagger API: http://localhost:5020/swagger" -ForegroundColor White
Write-Host ""
Write-Host "💡 Para detener los servicios, cierra las ventanas de terminal" -ForegroundColor Yellow 