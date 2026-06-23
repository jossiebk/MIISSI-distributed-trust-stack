using ServicioUsuarios.Modelos;
using ServicioUsuarios.Repositorios;

namespace ServicioUsuarios.Servicios;

public class ServicioEstudiantes : IServicioEstudiantes
{
    private readonly IRepositorioEstudiantes repositorioEstudiantes;

    public ServicioEstudiantes(
        IRepositorioEstudiantes repositorioEstudiantes)
    {
        this.repositorioEstudiantes = repositorioEstudiantes;
    }

    public IEnumerable<Estudiante> ObtenerTodos()
    {
        return repositorioEstudiantes.ObtenerTodos();
    }

    public Estudiante? ObtenerPorId(int idEstudiante)
    {
        return repositorioEstudiantes.ObtenerPorId(idEstudiante);
    }

    public Estudiante Crear(EstudianteRequest estudiante)
    {
        return repositorioEstudiantes.Crear(estudiante);
    }

    public Estudiante? Actualizar(
        int idEstudiante,
        EstudianteRequest estudiante)
    {
        return repositorioEstudiantes.Actualizar(
            idEstudiante,
            estudiante);
    }

    public bool Eliminar(int idEstudiante)
    {
        return repositorioEstudiantes.Eliminar(idEstudiante);
    }
}