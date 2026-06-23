using ServicioUsuarios.Modelos;

namespace ServicioUsuarios.Repositorios;

public interface IRepositorioEstudiantes
{
    IEnumerable<Estudiante> ObtenerTodos();

    Estudiante? ObtenerPorId(int idEstudiante);

    Estudiante Crear(EstudianteRequest estudiante);

    Estudiante? Actualizar(int idEstudiante, EstudianteRequest estudiante);

    bool Eliminar(int idEstudiante);
}