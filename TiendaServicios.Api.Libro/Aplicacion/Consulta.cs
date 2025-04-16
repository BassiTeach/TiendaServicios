using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class Consulta
    {
        public class ListaLibreriaMaterial : IRequest<List<LibreriaMaterialDTO>>
        {

        }

        public class Ejecuta : IRequestHandler<ListaLibreriaMaterial, List<LibreriaMaterialDTO>>
        {
            private readonly LibroContexto libroContexto;
            private readonly IMapper mapper;
            public Ejecuta(LibroContexto libroContexto, IMapper mapper)
            {
                this.libroContexto = libroContexto;
                this.mapper = mapper;
            }
            public async Task<List<LibreriaMaterialDTO>> Handle(ListaLibreriaMaterial request, CancellationToken cancellationToken)
            {
                var libros = await libroContexto.LibreriaMaterial.ToListAsync();
                return mapper.Map<List<LibreriaMaterial>, List<LibreriaMaterialDTO>>(libros);
            }
        }
    }
}
