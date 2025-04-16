using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;
using TiendaServicios.Api.Libro.RemoteInterfaces;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class ConsultarPorId
    {
        public class ConsultarLibreriaMaterial : IRequest<LibreriaMaterialDTO>
        {
            public Guid LibreriaMaterialGuid { get; set; }
        }
        public class Ejecuta : IRequestHandler<ConsultarLibreriaMaterial, LibreriaMaterialDTO>
        {
            private readonly LibroContexto libroContexto;
            private readonly IMapper mapper;
            private readonly IAutorService autorService;
            public Ejecuta(LibroContexto libroContexto, IMapper mapper, IAutorService autorService)
            {
                this.libroContexto = libroContexto;
                this.mapper = mapper;
                this.autorService = autorService;
            }
            public async Task<LibreriaMaterialDTO> Handle(ConsultarLibreriaMaterial request, CancellationToken cancellationToken)
            {
                var libro = await libroContexto.LibreriaMaterial
                    .Where(w => w.LibreriaMaterialGuid == request.LibreriaMaterialGuid)
                    .FirstOrDefaultAsync();
                
                if(libro == null)
                {
                    throw new Exception("No se encontró el libro");
                }

                LibreriaMaterialDTO resultado = mapper.Map<LibreriaMaterial, LibreriaMaterialDTO>(libro);
                resultado.AutorNombre = await obtenerNombreAutor(libro.AutorLibroGuid);
                return resultado;
            }
            private async Task<string> obtenerNombreAutor(Guid? autorId)
            {
                var respuesta = await autorService.GetAutor(autorId.Value);

                if (!respuesta.resultado)
                {
                    return string.Empty;
                }

                return $"{respuesta.autorRemote.Nombre} {respuesta.autorRemote.Apellido}";
            }
        }
    }
}
