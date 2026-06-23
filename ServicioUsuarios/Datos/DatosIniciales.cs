using ServicioUsuarios.Modelos;

namespace ServicioUsuarios.Datos;

public static class DatosIniciales
{
    public static List<Estudiante> Estudiantes { get; } =
    [
        new()
        {
            IdEstudiante = 1,
            Carnet = "20200001",
            Nombre = "Juan Pérez",
            Correo = "juan.perez@universidad.edu",
            Carrera = "Ingeniería en Sistemas",
            Facultad = "Ingeniería",
            Estado = "ACTIVO",
            FechaIngreso = new DateTime(2020, 1, 15)
        },
        new()
        {
            IdEstudiante = 2,
            Carnet = "20200002",
            Nombre = "María López",
            Correo = "maria.lopez@universidad.edu",
            Carrera = "Ingeniería Industrial",
            Facultad = "Ingeniería",
            Estado = "ACTIVO",
            FechaIngreso = new DateTime(2020, 1, 15)
        },
        new()
        {
            IdEstudiante = 3,
            Carnet = "20200003",
            Nombre = "Carlos Ramírez",
            Correo = "carlos.ramirez@universidad.edu",
            Carrera = "Arquitectura",
            Facultad = "Arquitectura",
            Estado = "ACTIVO",
            FechaIngreso = new DateTime(2021, 1, 15)
        },
        new()
        {
            IdEstudiante = 4,
            Carnet = "20200004",
            Nombre = "Ana Rodríguez",
            Correo = "ana.rodriguez@universidad.edu",
            Carrera = "Administración de Empresas",
            Facultad = "Ciencias Económicas",
            Estado = "INACTIVO",
            FechaIngreso = new DateTime(2019, 1, 15)
        },
        new()
        {
            IdEstudiante = 5,
            Carnet = "20200005",
            Nombre = "Pedro Morales",
            Correo = "pedro.morales@universidad.edu",
            Carrera = "Derecho",
            Facultad = "Ciencias Jurídicas",
            Estado = "ACTIVO",
            FechaIngreso = new DateTime(2022, 1, 15)
        }
    ];
}