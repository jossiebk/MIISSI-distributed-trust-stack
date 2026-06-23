using ServicioDocumentos.Modelos;

namespace ServicioDocumentos.Servicios
{
    public interface IServicioGestionDocumentos
    {
        IEnumerable<Documento> ObtenerTodos();

        Documento? ObtenerPorId(int idDocumento);

        Task<Documento> CrearAsync(DocumentoRequest documento);

        Documento? Actualizar(int idDocumento, DocumentoRequest documento);

        bool Eliminar(int idDocumento);
    }
}