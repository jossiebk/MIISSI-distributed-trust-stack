using ServicioDocumentos.Modelos;

namespace ServicioDocumentos.Clientes;

public interface IClienteUsuarios
{
    Task<EstudianteResponse?> ObtenerEstudianteAsync(int idEstudiante);
}