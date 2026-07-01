# ServicioDocumentos

Es el microservicio responsable de la administracion de documentos asociados a los estudiantes. Implementa operaciones basicas para consultar, crear, actualizar o eliminar documentos mediante una API REST y realiza consultas al microservicio de usuarios para validar la existencia del estudiantes antes de registrar un documento, por lo que es necesario tener activo ServicioUsuarios para el correcto funcionamiento. Tambien incorpora endpoints de health checks par supervisar el estado de ejecucion.

## Informacion general

- Version: .NET 8
- Puerto expuesto: 6002

## Instalacion y Ejecución

### Restaurar dependencias del proyecto

```bash
dotnet restore
```

### Compilar la aplicacion

```bash
dotnet build
```

### Ejecutar el microservicio en modo Development (para habilitar Swagger)

#### Windows (Powershell)

```bash
$env:ASPNETCORE_ENVIRONMENT="Development"; dotnet run
```

#### Linux/MacOS

```bash
ASPNETCORE_ENVIRONMENT=Development dotnet run
```

#### Una vez iniciada la aplicación, la documentación Swagger estará disponible en

```bash
http://localhost:6002/swagger
```

## Endpoints

| Endpoint | Método | Descripción |
| ---------- | :------: | ------------- |
| `/swagger` | GET | Muestra la documentación interactiva de la API mediante Swagger. |
| `/api/documentos` | GET | Obtiene el listado completo de documentos registrados. |
| `/api/documentos/{id}` | GET | Obtiene la información de un documento específico según su identificador. |
| `/api/documentos` | POST | Registra un nuevo documento validando previamente la existencia del estudiante asociado. |
| `/api/documentos/{id}` | PUT | Actualiza la información de un documento existente. |
| `/api/documentos/{id}` | DELETE | Elimina un documento del sistema utilizando su identificador. |
| `/health/documentos/live` | GET | Verifica que el servicio se encuentra en ejecución. |
| `/health/documentos/ready` | GET | Verifica que el servicio está preparado para recibir solicitudes. |

## Ejemplos de uso

### 1. Obtener todos los documentos

```bash
GET http://localhost:6002/api/documentos
```

### 2. Obtener un documento

```bash
GET http://localhost:6002/api/documentos/1
```

### 3. Registrar un documento

```bash
POST http://localhost:6002/api/documentos
```

#### Body

```bash
{
  "idEstudiante": 1,
  "tipoDocumento": "CONSTANCIA",
  "titulo": "Constancia de prácticas",
  "contenido": "El estudiante realizó prácticas supervisadas.",
  "fechaEmision": "2026-06-24T00:00:00",
  "estado": "EMITIDO"
}
```

### 4. Actualizar un documento

```bash
PUT http://localhost:6002/api/documentos/1
```

#### Body

```bash
{
  "idEstudiante": 1,
  "tipoDocumento": "CONSTANCIA",
  "titulo": "Constancia de prácticas profesionales",
  "contenido": "El estudiante completó satisfactoriamente las prácticas supervisadas.",
  "fechaEmision": "2026-06-24T00:00:00",
  "estado": "ACTUALIZADO"
}
```

### 5. Eliminar un documento

```bash
DELETE http://localhost:6002/api/documentos/1
```

## Health Checks

### Live

```bash
GET http://localhost:6002/health/documentos/live
```

### Ready

```bash
GET http://localhost:6002/health/documentos/ready
```
