namespace ServicioDocumentos.Modelos;

/// <summary>
/// Respuesta obtenida desde ServicioUsuarios.
/// </summary>
public class EstudianteResponse
{
    public int IdEstudiante { get; set; }

    public string Carnet { get; set; } = string.Empty;

    public string Nombre { get; set; } = string.Empty;

    public string Correo { get; set; } = string.Empty;

    public string Carrera { get; set; } = string.Empty;

    public string Facultad { get; set; } = string.Empty;

    public string Estado { get; set; } = string.Empty;

    public DateTime FechaIngreso { get; set; }
}