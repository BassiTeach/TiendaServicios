using TiendaServicios.Api.Libro.Remote;

namespace TiendaServicios.Api.Libro.RemoteInterfaces
{
    public interface IAutorService
    {
        Task<(bool resultado, AutorRemote autorRemote, string ErrorMessage)> GetAutor(Guid autorId);
    }
}
