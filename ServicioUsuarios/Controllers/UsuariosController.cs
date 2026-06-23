using Microsoft.AspNetCore.Mvc;
using ServicioUsuarios.Modelos;
using ServicioUsuarios.Servicios;

namespace ServicioUsuarios.Controllers;

/// <summary>
/// Controlador para gestionar estudiantes
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IServicioEstudiantes servicioEstudiantes;

    /// <summary>
    /// Inicializa una nueva instancia del controlador
    /// </summary>
    /// <param name="servicioEstudiantes">Servicio de estudiantes</param>
    public UsuariosController(IServicioEstudiantes servicioEstudiantes)
    {
        this.servicioEstudiantes = servicioEstudiantes;
    }

    /// <summary>
    /// Obtiene todos los estudiantes
    /// </summary>
    /// <returns>Lista de estudiantes</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Estudiante>> ObtenerTodos()
    {
        return Ok(servicioEstudiantes.ObtenerTodos());
    }

    /// <summary>
    /// Obtiene un estudiante por su ID
    /// </summary>
    /// <param name="idEstudiante">ID del estudiante</param>
    /// <returns>Estudiante encontrado</returns>
    [HttpGet("{idEstudiante:int}")]
    public ActionResult<Estudiante> ObtenerPorId(int idEstudiante)
    {
        var estudiante = servicioEstudiantes.ObtenerPorId(idEstudiante);

        if (estudiante is null)
        {
            return NotFound();
        }

        return Ok(estudiante);
    }

    /// <summary>
    /// Crea un nuevo estudiante
    /// </summary>
    /// <param name="estudiante">Datos del estudiante a crear</param>
    /// <returns>Estudiante creado</returns>
    [HttpPost]
    public ActionResult<Estudiante> Crear(
        EstudianteRequest estudiante)
    {
        var estudianteCreado =
            servicioEstudiantes.Crear(estudiante);

        return CreatedAtAction(
            nameof(ObtenerPorId),
            new { idEstudiante = estudianteCreado.IdEstudiante },
            estudianteCreado);
    }

    /// <summary>
    /// Actualiza un estudiante existente
    /// </summary>
    /// <param name="idEstudiante">ID del estudiante a actualizar</param>
    /// <param name="estudiante">Nuevos datos del estudiante</param>
    /// <returns>Estudiante actualizado</returns>
    [HttpPut("{idEstudiante:int}")]
    public ActionResult<Estudiante> Actualizar(
        int idEstudiante,
        EstudianteRequest estudiante)
    {
        var estudianteActualizado =
            servicioEstudiantes.Actualizar(
                idEstudiante,
                estudiante);

        if (estudianteActualizado is null)
        {
            return NotFound();
        }

        return Ok(estudianteActualizado);
    }

    /// <summary>
    /// Elimina un estudiante
    /// </summary>
    /// <param name="idEstudiante">ID del estudiante a eliminar</param>
    /// <returns>No content si se eliminó correctamente</returns>
    [HttpDelete("{idEstudiante:int}")]
    public IActionResult Eliminar(int idEstudiante)
    {
        var eliminado =
            servicioEstudiantes.Eliminar(idEstudiante);

        if (!eliminado)
        {
            return NotFound();
        }

        return NoContent();
    }
}