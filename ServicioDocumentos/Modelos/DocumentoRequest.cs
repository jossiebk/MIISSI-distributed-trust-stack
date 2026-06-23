namespace ServicioDocumentos.Modelos;

/// <summary>
/// Datos requeridos para crear o actualizar un documento.
/// </summary>
public class DocumentoRequest
{
    public int IdEstudiante { get; set; }

    public string TipoDocumento { get; set; } = string.Empty;

    public string Titulo { get; set; } = string.Empty;

    public string Contenido { get; set; } = string.Empty;

    public DateTime FechaEmision { get; set; }

    public string Estado { get; set; } = string.Empty;
}