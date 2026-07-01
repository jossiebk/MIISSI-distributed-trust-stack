# ServicioUsuarios

Es el microservicio encargado de la gestion de estudiantes dentro del entorno experimental. Brinda operaciones basicas para registrar, consultar, actualizar y eliminar informacion mediante el consumo de una API REST. Ademas, expone endpoins de verificacion de estado (health checks) y actua como fuente de informacion para el microservicio de documentos durante la validacion de estudiantes.

## Informacion general

- Version: .NET 8
- Puerto expuesto: 6001

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
http://localhost:6001/swagger
```

## Endpoints

| Endpoint | Método | Descripción |
| ---------- | :------: | ------------- |
| `/swagger` | GET | Muestra la documentación interactiva de la API mediante Swagger. |
| `/api/usuarios` | GET | Obtiene el listado completo de estudiantes registrados. |
| `/api/usuarios/{id}` | GET | Obtiene la información de un estudiante específico según su identificador. |
| `/api/usuarios` | POST | Registra un nuevo estudiante. |
| `/api/usuarios/{id}` | PUT | Actualiza la información de un estudiante existente. |
| `/api/usuarios/{id}` | DELETE | Elimina un estudiante utilizando su identificador. |
| `/health/usuarios/live` | GET | Verifica que el servicio se encuentra en ejecución. |
| `/health/usuarios/ready` | GET | Verifica que el servicio está preparado para recibir solicitudes. |

## Ejemplos de uso

### 1. Obtener todos los estudiantes

```bash
GET http://localhost:6001/api/usuarios
```

### 2. Obtener un estudiante

```bash
GET http://localhost:6001/api/usuarios/1
```

### 3. Registrar un estudiante

```bash
POST http://localhost:6001/api/usuarios
```

#### Body

```bash
{
  "carnet": "20250001",
  "nombre": "Luis Gómez",
  "correo": "luis.gomez@universidad.edu",
  "carrera": "Ingeniería en Sistemas",
  "facultad": "Ingeniería",
  "estado": "ACTIVO",
  "fechaIngreso": "2025-01-15T00:00:00"
}
```

### 4. Actualizar un estudiante

```bash
PUT http://localhost:6001/api/usuarios/1
```

#### Body

```bash
{
  "carnet": "20250001",
  "nombre": "Luis Gómez",
  "correo": "luis.gomez@universidad.edu",
  "carrera": "Ingeniería en Sistemas",
  "facultad": "Ingeniería",
  "estado": "INACTIVO",
  "fechaIngreso": "2025-01-15T00:00:00"
}
```

### 5. Eliminar un estudiante

```bash
DELETE http://localhost:6001/api/usuarios/1
```

## Health Checks

### Live

```bash
GET http://localhost:6001/health/usuarios/live
```

### Ready

```bash
GET http://localhost:6001/health/usuarios/ready
```
