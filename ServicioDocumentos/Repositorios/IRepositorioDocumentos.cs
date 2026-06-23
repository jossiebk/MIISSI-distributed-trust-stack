using ServicioDocumentos.Modelos;

namespace ServicioDocumentos.Repositorios;

public interface IRepositorioDocumentos
{
    IEnumerable<Documento> ObtenerTodos();

    Documento? ObtenerPorId(int idDocumento);

    Documento Crear(Documento documento);

    Documento? Actualizar(
        int idDocumento,
        DocumentoRequest documento);

    bool Eliminar(int idDocumento);
}