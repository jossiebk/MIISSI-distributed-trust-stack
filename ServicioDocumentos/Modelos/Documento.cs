namespace ServicioDocumentos.Modelos;

/// <summary>
/// Representa un documento generado para un estudiante.
/// </summary>
public class Documento
{
    public int IdDocumento { get; set; }

    public int IdEstudiante { get; set; }

    public string TipoDocumento { get; set; } = string.Empty;

    public string Titulo { get; set; } = string.Empty;

    public string Contenido { get; set; } = string.Empty;

    public DateTime FechaEmision { get; set; }

    public string Estado { get; set; } = string.Empty;

    public EstudianteDocumento Estudiante { get; set; } = new();
}