# 🚀 Configuración del Repositorio Git

## 📋 Pasos para Subir el Proyecto a Git

### **Paso 1: Inicializar Repositorio Local**
```bash
# En la raíz del proyecto
git init
```

### **Paso 2: Agregar Archivos**
```bash
# Agregar todos los archivos
git add .

# Verificar qué se va a subir
git status
```

### **Paso 3: Primer Commit**
```bash
git commit -m "IZUMU Clientes - Sistema completo de gestión de clientes

- Frontend: Aplicación web ASP.NET Core con Razor Pages
- Backend: Microservicio API con .NET Core
- Base de datos: SQL Server con stored procedures
- Pruebas unitarias: NUnit para microservicio y frontend
- Documentación: README completo con instrucciones de instalación
- Arquitectura: Microservicios con separación de responsabilidades
- Validaciones: Frontend y backend con manejo de errores
- Componentes: Reutilizables y bien estructurados"
```

### **Paso 4: Crear Repositorio Remoto**

#### **GitHub:**
1. Ir a https://github.com
2. Crear nuevo repositorio público
3. Nombre: `izumu-clientes`
4. Descripción: "Sistema de gestión de clientes con arquitectura de microservicios"
5. **NO** inicializar con README (ya tenemos uno)

#### **GitLab:**
1. Ir a https://gitlab.com
2. Crear nuevo proyecto público
3. Nombre: `izumu-clientes`
4. Descripción: "Sistema de gestión de clientes con arquitectura de microservicios"

### **Paso 5: Conectar y Subir**
```bash
# Agregar origen remoto (reemplazar con tu URL)
git remote add origin https://github.com/ClaudiaFV16/izumu-clientes.git

# Subir al repositorio
git branch -M main
git push -u origin main
```

### **Paso 6: Verificar**
- ✅ Repositorio público visible
- ✅ README.md se muestra correctamente
- ✅ Estructura de carpetas visible
- ✅ Scripts de instalación accesibles

## 📁 Estructura que se Subirá

```
izumu-clientes/
├── README.md                    # Documentación principal
├── GIT_SETUP.md                # Este archivo
├── build.ps1                   # Script de compilación
├── run.ps1                     # Script de ejecución
├── INSTRUCCIONES_COMPILACION.md # Instrucciones detalladas
├── IzumuClientes/              # Aplicación web frontend
├── Microservice_Izumu/         # Microservicio API
├── MicroService_Izumu.Test/    # Pruebas unitarias
├── IzumuClientes.Tests/        # Pruebas del frontend
└── 01. Scripts_BD/             # Scripts de base de datos
```

## ✅ Checklist de Verificación

- [ ] Repositorio es público
- [ ] README.md se muestra correctamente
- [ ] Instrucciones de instalación claras
- [ ] Sin logos o nombres de Colmédica
- [ ] Proyecto se llama "IZUMU Clientes"
- [ ] Estructura de carpetas visible
- [ ] Scripts de base de datos incluidos
- [ ] Documentación completa

## 🎯 URLs de Acceso

Una vez subido, los evaluadores podrán:
1. **Clonar**: `git clone https://github.com/ClaudiaFV16/izumu-clientes.git`
2. **Seguir README.md** para instalación
3. **Ejecutar** el sistema completo
4. **Evaluar** todas las funcionalidades

---

**¡El proyecto está listo para ser evaluado!** 🏆 