using Microsoft.AspNetCore.Mvc;
using ServicioDocumentos.Modelos;
using ServicioDocumentos.Servicios;

namespace ServicioDocumentos.Controllers
{
    /// <summary>
    /// Controlador para gestionar documentos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentosController : ControllerBase
    {
        private readonly IServicioGestionDocumentos servicioDocumentos;

        /// <summary>
        /// Inicializa una nueva instancia del controlador.
        /// </summary>
        /// <param name="servicioDocumentos">Servicio de documentos.</param>
        public DocumentosController(
            IServicioGestionDocumentos servicioDocumentos)
        {
            this.servicioDocumentos = servicioDocumentos;
        }

        /// <summary>
        /// Obtiene todos los documentos.
        /// </summary>
        /// <returns>Lista de documentos.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Documento>> ObtenerTodos()
        {
            return Ok(servicioDocumentos.ObtenerTodos());
        }

        /// <summary>
        /// Obtiene un documento por su identificador.
        /// </summary>
        /// <param name="idDocumento">Identificador del documento.</param>
        /// <returns>Documento encontrado.</returns>
        [HttpGet("{idDocumento:int}")]
        public ActionResult<Documento> ObtenerPorId(
            int idDocumento)
        {
            var documento =
                servicioDocumentos.ObtenerPorId(idDocumento);

            if (documento is null)
            {
                return NotFound(new
                {
                    mensaje =
                        $"No existe un documento con el id {idDocumento}."
                });
            }

            return Ok(documento);
        }

        /// <summary>
        /// Crea un nuevo documento.
        /// </summary>
        /// <param name="documento">Datos del documento.</param>
        /// <returns>Documento creado.</returns>
        [HttpPost]
        public async Task<ActionResult<Documento>> Crear(
            DocumentoRequest documento)
        {
            try
            {
                var documentoCreado =
                    await servicioDocumentos.CrearAsync(
                        documento);

                return CreatedAtAction(
                    nameof(ObtenerPorId),
                    new
                    {
                        idDocumento =
                            documentoCreado.IdDocumento
                    },
                    documentoCreado);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new
                {
                    mensaje = ex.Message
                });
            }
        }

        /// <summary>
        /// Actualiza un documento existente.
        /// </summary>
        /// <param name="idDocumento">Identificador del documento.</param>
        /// <param name="documento">Datos actualizados.</param>
        /// <returns>Documento actualizado.</returns>
        [HttpPut("{idDocumento:int}")]
        public ActionResult<Documento> Actualizar(
            int idDocumento,
            DocumentoRequest documento)
        {
            var documentoActualizado =
                servicioDocumentos.Actualizar(
                    idDocumento,
                    documento);

            if (documentoActualizado is null)
            {
                return NotFound(new
                {
                    mensaje =
                        $"No existe un documento con el id {idDocumento}."
                });
            }

            return Ok(documentoActualizado);
        }

        /// <summary>
        /// Elimina un documento.
        /// </summary>
        /// <param name="idDocumento">Identificador del documento.</param>
        /// <returns>NoContent si se elimina correctamente.</returns>
        [HttpDelete("{idDocumento:int}")]
        public IActionResult Eliminar(
            int idDocumento)
        {
            var eliminado =
                servicioDocumentos.Eliminar(idDocumento);

            if (!eliminado)
            {
                return NotFound(new
                {
                    mensaje =
                        $"No existe un documento con el id {idDocumento}."
                });
            }

            return NoContent();
        }
    }
}