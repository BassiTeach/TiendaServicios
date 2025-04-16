using System.Net.Http;
using System.Text.Json;
using TiendaServicios.Api.Compra.Remote;
using TiendaServicios.Api.Compra.RemoteInterfaces;

namespace TiendaServicios.Api.Compra.RemoteServices
{
    public class LibroService : ILibrosService
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<LibroService> logger;
        public LibroService(IHttpClientFactory httpClientFactory, ILogger<LibroService> logger)
        {
            httpClient = httpClientFactory.CreateClient("Libros");
            this.logger = logger;
        }
        public async Task<(bool resultado, LibroRemote Libro, string ErrorMessage)> GetLibro(Guid libroId)
        {
            try
            {
                logger.LogInformation("Consumiendo Endpoint");
                var response = await httpClient.GetAsync($"{libroId}");
                response.EnsureSuccessStatusCode();
                var contenido = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                };
                var resultado = JsonSerializer.Deserialize<LibroRemote>(contenido, options);
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
