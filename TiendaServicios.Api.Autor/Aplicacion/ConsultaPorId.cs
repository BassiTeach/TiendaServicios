using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class ConsultaPorId
    {
        public class ConsultaAutor : IRequest<AutorDto>
        {
            public string AutorLibroGuid { get; set; } = null!;
        }

        public class Manejador : IRequestHandler<ConsultaAutor, AutorDto>
        {
            private readonly ContextoAutor contextoAutor;
            private readonly IMapper mapper;
            public Manejador(ContextoAutor contextoAutor, IMapper mapper)
            {
                this.contextoAutor = contextoAutor;
                this.mapper = mapper;
            }
            public async Task<AutorDto> Handle(ConsultaAutor request, CancellationToken cancellationToken)
            {
                var autor = await contextoAutor.AutorLibro
                    .Where(w => w.AutorLibroGuid == request.AutorLibroGuid)
                    .FirstOrDefaultAsync();

                if (autor == null)
                {
                    throw new Exception("No se encontró el autor");
                }

                return mapper.Map<AutorLibro, AutorDto>(autor);
            }
        }
    }
}
