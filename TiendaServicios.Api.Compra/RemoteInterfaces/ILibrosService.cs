using TiendaServicios.Api.Compra.Remote;

namespace TiendaServicios.Api.Compra.RemoteInterfaces
{
    public interface ILibrosService
    {
        Task<(bool resultado, LibroRemote Libro, string ErrorMessage)> GetLibro(Guid libroId);
    }
}
