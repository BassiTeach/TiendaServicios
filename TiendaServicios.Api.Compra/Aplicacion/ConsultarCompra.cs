using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Compra.Modelo;
using TiendaServicios.Api.Compra.Persistencia;
using TiendaServicios.Api.Compra.Remote;
using TiendaServicios.Api.Compra.RemoteInterfaces;

namespace TiendaServicios.Api.Compra.Aplicacion
{
    public class ConsultarCompra
    {
        public class Ejecuta : IRequest<CarritoDTO>
        {
            public int CarritoId { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, CarritoDTO>
        {
            private readonly CompraContexto compraContexto;
            private readonly ILibrosService librosService;
            private readonly ILogger<Ejecuta> logger;
            private readonly IMapper mapper;
            public Manejador(ILibrosService librosService, CompraContexto compraContexto, ILogger<Ejecuta> logger, IMapper mapper)
            {
                this.librosService = librosService;
                this.compraContexto = compraContexto;
                this.logger = logger;
                this.mapper = mapper;
            }
            public async Task<CarritoDTO> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                try
                {
                    Carrito? carrito = await compraContexto.Carrito.Where(w => w.CarritoId == request.CarritoId).FirstOrDefaultAsync();

                    if (carrito == null)
                    {
                        throw new Exception("Carrito de compra no encontrado");
                    }

                    CarritoDTO carritoDTO = mapper.Map<Carrito, CarritoDTO>(carrito);

                    List<CarritoDetalle> carritoDetalle = await compraContexto.CarritoDetalle.Where(w => w.CarritoId == request.CarritoId).ToListAsync();

                    foreach (CarritoDetalle detalle in carritoDetalle)
                    {
                        var response = await librosService.GetLibro(new Guid(detalle.ProductSeleccionado));

                        if (!response.resultado)
                        {
                            throw new Exception($"No se encontró el libro {detalle.ProductSeleccionado}");
                        }

                        carritoDTO.ListaDetalleCompra.Add(
                                mapper.Map<LibroRemote, CarritoDetalleDTO>(response.Libro)
                            );
                    }

                    return carritoDTO;

                }
                catch (Exception ex)
                {
                    logger.LogError(ex.ToString());
                    throw ex;
                }
            }
        }
    }
}
