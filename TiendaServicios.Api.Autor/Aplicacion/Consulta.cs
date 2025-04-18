﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Consulta
    {
        public class ListaAutor : IRequest<List<AutorDto>>
        {

        }

        public class Manejador : IRequestHandler<ListaAutor, List<AutorDto>>
        {
            private readonly ContextoAutor contextoAutor;
            private readonly IMapper mapper;
            public Manejador(ContextoAutor contextoAutor, IMapper mapper)
            {
                this.contextoAutor = contextoAutor;
                this.mapper = mapper;
            }
            public async Task<List<AutorDto>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await contextoAutor.AutorLibro.AsNoTracking().ToListAsync(cancellationToken);

                return mapper.Map<List<AutorLibro>, List<AutorDto>>(autores);
            }
        }
    }
}
