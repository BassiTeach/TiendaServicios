using Microsoft.Extensions.Logging;
using System.Text.Json;
using TiendaServicios.Api.Libro.Remote;
using TiendaServicios.Api.Libro.RemoteInterfaces;

namespace TiendaServicios.Api.Libro.RemoteServices
{
    public class AutorService : IAutorService
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<AutorService> logger;
        public AutorService(IHttpClientFactory httpClientFactory, ILogger<AutorService> logger)
        {
            this.httpClient = httpClientFactory.CreateClient("Autor");
            this.logger = logger;
        }
        public async Task<(bool resultado, AutorRemote autorRemote, string ErrorMessage)> GetAutor(Guid autorId)
        {
            try
            {
                logger.LogInformation("Consumiendo Endpoint");
                var response = await httpClient.GetAsync($"{autorId}");
                response.EnsureSuccessStatusCode();
                var contenido = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                };
                var resultado = JsonSerializer.Deserialize<AutorRemote>(contenido, options);
                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
