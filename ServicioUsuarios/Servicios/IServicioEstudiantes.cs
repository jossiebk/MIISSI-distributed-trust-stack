using ServicioUsuarios.Modelos;

namespace ServicioUsuarios.Servicios;

public interface IServicioEstudiantes
{
    IEnumerable<Estudiante> ObtenerTodos();

    Estudiante? ObtenerPorId(int idEstudiante);

    Estudiante Crear(EstudianteRequest estudiante);

    Estudiante? Actualizar(
        int idEstudiante,
        EstudianteRequest estudiante);

    bool Eliminar(int idEstudiante);
}