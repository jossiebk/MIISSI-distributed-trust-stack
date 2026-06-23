using ServicioDocumentos.Datos;
using ServicioDocumentos.Modelos;

namespace ServicioDocumentos.Repositorios;

public class RepositorioDocumentos : IRepositorioDocumentos
{
    public IEnumerable<Documento> ObtenerTodos()
    {
        return DatosIniciales.Documentos;
    }

    public Documento? ObtenerPorId(int idDocumento)
    {
        return DatosIniciales.Documentos
            .FirstOrDefault(d => d.IdDocumento == idDocumento);
    }

    public Documento Crear(Documento documento)
    {
        var nuevoId = DatosIniciales.Documentos.Any()
            ? DatosIniciales.Documentos.Max(d => d.IdDocumento) + 1
            : 1;

        documento.IdDocumento = nuevoId;

        DatosIniciales.Documentos.Add(documento);

        return documento;
    }

    public Documento? Actualizar(int idDocumento, DocumentoRequest documento)
    {
        var documentoExistente = ObtenerPorId(idDocumento);

        if (documentoExistente is null)
        {
            return null;
        }

        documentoExistente.TipoDocumento = documento.TipoDocumento;
        documentoExistente.Titulo = documento.Titulo;
        documentoExistente.Contenido = documento.Contenido;
        documentoExistente.FechaEmision = documento.FechaEmision;
        documentoExistente.Estado = documento.Estado;

        return documentoExistente;
    }

    public bool Eliminar(int idDocumento)
    {
        var documento = ObtenerPorId(idDocumento);

        if (documento is null)
        {
            return false;
        }

        DatosIniciales.Documentos.Remove(documento);

        return true;
    }
}