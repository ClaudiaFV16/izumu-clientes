# 📋 Instrucciones para Actualizar Datos de Prueba

## 🎯 Objetivo
Actualizar los datos de prueba del proyecto IZUMU Clientes con información más variada y realista.

## 📁 Archivos Modificados

### 1. `02. Datos_Prueba_Actualizados.sql`
Este archivo contiene los nuevos datos de prueba con:
- **15 clientes** de diferentes perfiles profesionales
- **6 planes** de medicina prepagada más detallados
- **5 tipos de documento** (incluyendo Registro Civil)

## 🚀 Pasos para Aplicar los Cambios

### Paso 1: Ejecutar el Script de Datos Actualizados
```sql
-- En SQL Server Management Studio:
-- 1. Conectar a la base de datos DB_IZUMU
-- 2. Ejecutar el archivo: 02. Datos_Prueba_Actualizados.sql
```

### Paso 2: Verificar los Datos
El script incluye consultas de verificación que mostrarán:
- Lista de tipos de documento
- Lista de planes disponibles
- Lista completa de clientes con información detallada

## 👥 Nuevos Perfiles de Clientes

### Profesionales:
1. **Claudia Fernandez** - Ejecutivo empresarial
2. **Clara Fernandez** - Profesional independiente
3. **Dr. Norberto Suarez** - Médico especialista
4. **Ing. Felipe Caro** - Ingeniero
5. **Dr. Marcela Mendez** - Abogada
6. **Prof. Alejandro Mancero** - Profesor universitario
7. **Dr. Loraine Melendez** - Profesional de la salud

### Otros Perfiles:
8. **Kelly Villalobos** - Estudiante
9. **Rosenda Ramírez** - Adulto mayor
10. **Gilberto Berdejo** - Extranjero
11. **Lolilyz fernandez** - Familia
12. **Jesus Valdez** - Emprendedor
13. **Rodrigo Díaz** - Jubilado
14. **Catalina Monrron** - Ejecutiva
15. **Sr. Luis Navarro** - Empresario

## 📊 Nuevos Planes de Medicina Prepagada

1. **Plan Básico - Cobertura Individual**
2. **Plan Premium - Cobertura Familiar**
3. **Plan Platino - Cobertura Ejecutiva**
4. **Plan Familiar - Hasta 6 Integrantes**
5. **Plan Senior - Mayores de 60 años**
6. **Plan Empresarial - Corporativo**

## 🏢 Tipos de Documento

1. **CC** - Cédula de Ciudadanía
2. **PA** - Pasaporte
3. **TI** - Tarjeta de Identidad
4. **CE** - Cédula de Extranjería
5. **RC** - Registro Civil

## ✅ Beneficios de los Nuevos Datos

### Variedad de Perfiles:
- Diferentes rangos de edad (estudiante hasta jubilado)
- Variedad de profesiones y ocupaciones
- Diferentes tipos de documento
- Emails realistas con dominios apropiados

### Planes Más Detallados:
- Descripción clara de cada plan
- Coberturas específicas
- Planes para diferentes segmentos

### Direcciones Realistas:
- Direcciones de Bogotá
- Diferentes tipos de vivienda (apartamento, casa, oficina)
- Zonas variadas de la ciudad

## 🔄 Rollback (Si es necesario)

Si necesitas volver a los datos originales:
```sql
-- Ejecutar el archivo original: 01. Creacion_Objetos.sql
-- Este archivo contiene los datos originales
```

## 📝 Notas Importantes

- Los nuevos datos mantienen la integridad referencial
- Todos los clientes tienen emails únicos
- Los números de documento son únicos por tipo
- Las fechas de nacimiento son realistas
- Los números de celular siguen el formato colombiano

---

**¡Los nuevos datos harán que el proyecto se vea más profesional y realista!** 