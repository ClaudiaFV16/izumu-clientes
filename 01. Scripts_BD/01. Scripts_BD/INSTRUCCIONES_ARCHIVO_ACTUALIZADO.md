# 📋 Instrucciones para Usar el Archivo Actualizado

## 🎯 Objetivo
Usar el archivo `01. Creacion_Objetos_Actualizado.sql` que contiene los datos de prueba con los nuevos nombres.

## 📁 Archivo Creado

### `01. Creacion_Objetos_Actualizado.sql`
Este archivo contiene:
- **Estructura completa** de la base de datos
- **Datos de prueba actualizados** con los nuevos nombres
- **Consultas de verificación** incluidas

## 🚀 Pasos para Usar el Archivo Actualizado

### Opción 1: Usar el Archivo Actualizado (Recomendado)
```sql
-- En SQL Server Management Studio:
-- 1. Conectar a la base de datos DB_IZUMU
-- 2. Ejecutar el archivo: 01. Creacion_Objetos_Actualizado.sql
-- 3. Este archivo incluye todo: estructura + datos actualizados
```

### Opción 2: Usar los Archivos Originales + Datos Extendidos
```sql
-- 1. Ejecutar: 01. Creacion_Objetos.sql (estructura básica)
-- 2. Ejecutar: 02. sp_GetClientes.sql
-- 3. Ejecutar: 03. sp_InsertCliente.sql
-- 4. Ejecutar: 04. sp_UpdateCliente.sql
-- 5. Ejecutar: 05. sp_DeleteCliente.sql
-- 6. Ejecutar: 06. sp_GetTipoDocumento.sql
-- 7. Ejecutar: 07. sp_GetPlan.sql
-- 8. Ejecutar: 02. Datos_Prueba_Actualizados.sql (15 clientes)
```

## 👥 Datos Incluidos en el Archivo Actualizado

### Clientes Básicos (3):
1. **Claudia Andrea Fernandez Herrera** - Ejecutivo empresarial
2. **Clara Isabel Fernandez Vargas** - Profesional independiente
3. **Kelly Alejandra Villalobos Martinez** - Estudiante

### Planes Mejorados:
1. **Plan Básico - Cobertura Individual**
2. **Plan Premium - Cobertura Familiar**
3. **Plan Platino - Cobertura Ejecutiva**
4. **Plan Familiar - Hasta 6 Integrantes**

### Tipos de Documento:
1. **CC** - Cédula de Ciudadanía
2. **PA** - Pasaporte
3. **TI** - Tarjeta de Identidad
4. **CE** - Cédula de Extranjería

## ✅ Ventajas del Archivo Actualizado

### Simplicidad:
- **Un solo archivo** para crear toda la estructura
- **Datos incluidos** automáticamente
- **Verificación automática** con consultas incluidas

### Datos Mejorados:
- **Nombres actualizados** con los nuevos clientes
- **Direcciones realistas** de Bogotá
- **Emails profesionales** apropiados
- **Planes descriptivos** con detalles de cobertura

## 🔄 Comparación de Archivos

| Archivo | Clientes | Planes | Características |
|---------|----------|--------|-----------------|
| `01. Creacion_Objetos.sql` | 3 básicos | 4 básicos | Datos originales |
| `01. Creacion_Objetos_Actualizado.sql` | 3 actualizados | 4 mejorados | Datos nuevos |
| `02. Datos_Prueba_Actualizados.sql` | 15 completos | 6 completos | Datos extendidos |

## 📝 Recomendación

**Usar `01. Creacion_Objetos_Actualizado.sql`** para:
- **Instalación rápida** y simple
- **Datos básicos** pero actualizados
- **Verificación automática** incluida

**Usar `02. Datos_Prueba_Actualizados.sql`** para:
- **Datos completos** (15 clientes)
- **Más variedad** de perfiles
- **Demostración profesional**

---

**¡El archivo actualizado está listo para usar!** 