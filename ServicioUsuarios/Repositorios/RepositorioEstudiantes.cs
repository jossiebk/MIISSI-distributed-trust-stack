using ServicioUsuarios.Datos;
using ServicioUsuarios.Modelos;

namespace ServicioUsuarios.Repositorios;

public class RepositorioEstudiantes : IRepositorioEstudiantes
{
    public IEnumerable<Estudiante> ObtenerTodos()
    {
        return DatosIniciales.Estudiantes;
    }

    public Estudiante? ObtenerPorId(int idEstudiante)
    {
        return DatosIniciales.Estudiantes
            .FirstOrDefault(e => e.IdEstudiante == idEstudiante);
    }

    public Estudiante Crear(EstudianteRequest estudiante)
    {
        var nuevoId = DatosIniciales.Estudiantes.Any()
            ? DatosIniciales.Estudiantes.Max(e => e.IdEstudiante) + 1
            : 1;

        var nuevoEstudiante = new Estudiante
        {
            IdEstudiante = nuevoId,
            Carnet = estudiante.Carnet,
            Nombre = estudiante.Nombre,
            Correo = estudiante.Correo,
            Carrera = estudiante.Carrera,
            Facultad = estudiante.Facultad,
            Estado = estudiante.Estado,
            FechaIngreso = estudiante.FechaIngreso
        };

        DatosIniciales.Estudiantes.Add(nuevoEstudiante);

        return nuevoEstudiante;
    }

    public Estudiante? Actualizar(
        int idEstudiante,
        EstudianteRequest estudiante)
    {
        var estudianteExistente = ObtenerPorId(idEstudiante);

        if (estudianteExistente is null)
        {
            return null;
        }

        estudianteExistente.Carnet = estudiante.Carnet;
        estudianteExistente.Nombre = estudiante.Nombre;
        estudianteExistente.Correo = estudiante.Correo;
        estudianteExistente.Carrera = estudiante.Carrera;
        estudianteExistente.Facultad = estudiante.Facultad;
        estudianteExistente.Estado = estudiante.Estado;
        estudianteExistente.FechaIngreso = estudiante.FechaIngreso;

        return estudianteExistente;
    }

    public bool Eliminar(int idEstudiante)
    {
        var estudiante = ObtenerPorId(idEstudiante);

        if (estudiante is null)
        {
            return false;
        }

        DatosIniciales.Estudiantes.Remove(estudiante);

        return true;
    }
}