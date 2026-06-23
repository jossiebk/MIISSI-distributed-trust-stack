using ServicioDocumentos.Clientes;
using ServicioDocumentos.Modelos;
using ServicioDocumentos.Repositorios;

namespace ServicioDocumentos.Servicios
{
    public class ServicioGestionDocumentos : IServicioGestionDocumentos
    {
        private readonly IRepositorioDocumentos repositorioDocumentos;
        private readonly IClienteUsuarios clienteUsuarios;

        public ServicioGestionDocumentos(
            IRepositorioDocumentos repositorioDocumentos,
            IClienteUsuarios clienteUsuarios)
        {
            this.repositorioDocumentos = repositorioDocumentos;
            this.clienteUsuarios = clienteUsuarios;
        }

        public IEnumerable<Documento> ObtenerTodos()
        {
            return repositorioDocumentos.ObtenerTodos();
        }

        public Documento? ObtenerPorId(int idDocumento)
        {
            return repositorioDocumentos.ObtenerPorId(idDocumento);
        }

        public async Task<Documento> CrearAsync(DocumentoRequest documento)
        {
            var estudiante =
                await clienteUsuarios.ObtenerEstudianteAsync(
                    documento.IdEstudiante);

            if (estudiante is null)
            {
                throw new InvalidOperationException(
                    $"No existe un estudiante con el id {documento.IdEstudiante}.");
            }

            var nuevoDocumento = new Documento
            {
                IdEstudiante = estudiante.IdEstudiante,
                TipoDocumento = documento.TipoDocumento,
                Titulo = documento.Titulo,
                Contenido = documento.Contenido,
                FechaEmision = documento.FechaEmision,
                Estado = documento.Estado,
                Estudiante = new EstudianteDocumento
                {
                    IdEstudiante = estudiante.IdEstudiante,
                    Carnet = estudiante.Carnet,
                    Nombre = estudiante.Nombre,
                    Correo = estudiante.Correo,
                    Carrera = estudiante.Carrera,
                    Facultad = estudiante.Facultad,
                    Estado = estudiante.Estado,
                    FechaIngreso = estudiante.FechaIngreso
                }
            };

            return repositorioDocumentos.Crear(
                nuevoDocumento);
        }

        public Documento? Actualizar(
            int idDocumento,
            DocumentoRequest documento)
        {
            return repositorioDocumentos.Actualizar(
                idDocumento,
                documento);
        }

        public bool Eliminar(int idDocumento)
        {
            return repositorioDocumentos.Eliminar(idDocumento);
        }
    }
}