using System.Net.Http.Json;
using ServicioDocumentos.Modelos;

namespace ServicioDocumentos.Clientes;

public class ClienteUsuarios : IClienteUsuarios
{
    private readonly HttpClient httpClient;

    public ClienteUsuarios(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<EstudianteResponse?> ObtenerEstudianteAsync(
    int idEstudiante)
{
    var response =
        await httpClient.GetAsync(
            $"api/usuarios/{idEstudiante}");

    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
    {
        return null;
    }

    response.EnsureSuccessStatusCode();

    return await response.Content
        .ReadFromJsonAsync<EstudianteResponse>();
}
}