using ServicioDocumentos.Modelos;

namespace ServicioDocumentos.Datos;

public static class DatosIniciales
{
    public static List<Documento> Documentos { get; } =
    [
        new()
        {
            IdDocumento = 1,
            IdEstudiante = 1,
            TipoDocumento = "CONSTANCIA",
            Titulo = "Constancia de inscripción",
            Contenido = "El estudiante se encuentra inscrito en el ciclo académico 2026.",
            FechaEmision = new DateTime(2026, 1, 15),
            Estado = "EMITIDO",
            Estudiante = new EstudianteDocumento
            {
                IdEstudiante = 1,
                Carnet = "20200001",
                Nombre = "Juan Pérez",
                Correo = "juan.perez@universidad.edu",
                Carrera = "Ingeniería en Sistemas",
                Facultad = "Ingeniería",
                Estado = "ACTIVO",
                FechaIngreso = new DateTime(2020, 1, 15)
            }
        },
        new()
        {
            IdDocumento = 2,
            IdEstudiante = 2,
            TipoDocumento = "CERTIFICACION",
            Titulo = "Certificación de cursos",
            Contenido = "El estudiante ha aprobado los cursos requeridos.",
            FechaEmision = new DateTime(2026, 2, 10),
            Estado = "EMITIDO",
            Estudiante = new EstudianteDocumento
            {
                IdEstudiante = 2,
                Carnet = "20200002",
                Nombre = "María López",
                Correo = "maria.lopez@universidad.edu",
                Carrera = "Ingeniería Industrial",
                Facultad = "Ingeniería",
                Estado = "ACTIVO",
                FechaIngreso = new DateTime(2020, 1, 15)
            }
        },
        new()
        {
            IdDocumento = 3,
            IdEstudiante = 3,
            TipoDocumento = "SOLICITUD",
            Titulo = "Solicitud de equivalencia",
            Contenido = "Solicitud para reconocimiento de cursos externos.",
            FechaEmision = new DateTime(2026, 3, 5),
            Estado = "PENDIENTE",
            Estudiante = new EstudianteDocumento
            {
                IdEstudiante = 3,
                Carnet = "20200003",
                Nombre = "Carlos Ramírez",
                Correo = "carlos.ramirez@universidad.edu",
                Carrera = "Arquitectura",
                Facultad = "Arquitectura",
                Estado = "ACTIVO",
                FechaIngreso = new DateTime(2021, 1, 15)
            }
        }
    ];
}