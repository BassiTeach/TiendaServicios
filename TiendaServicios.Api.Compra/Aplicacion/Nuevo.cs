using FluentValidation;
using MediatR;
using TiendaServicios.Api.Compra.Modelo;
using TiendaServicios.Api.Compra.Persistencia;

namespace TiendaServicios.Api.Compra.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta: IRequest<Unit>
        {
            public DateTime FechaCreacion { get; set; }
            public List<string> CarritoDetalle { get; set; } = new List<string>();
        }
        public class Manejador : IRequestHandler<Ejecuta, Unit>
        {
            private readonly CompraContexto compraContexto;
            public Manejador(CompraContexto compraContexto)
            {
                this.compraContexto = compraContexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                try
                {
                    var carrito = new Carrito
                    {
                        CarritoGuid = Guid.NewGuid().ToString(),
                        FechaCreacion = request.FechaCreacion,
                    };

                    compraContexto.Carrito.Add(carrito);
                    await compraContexto.SaveChangesAsync(cancellationToken);

                    var detalles = request.CarritoDetalle.Select(item => new CarritoDetalle
                    {
                        CarritoDetalleGuid = Guid.NewGuid().ToString(),
                        CarritoId = carrito.CarritoId,
                        FechaCreacion = request.FechaCreacion,
                        ProductSeleccionado = item
                    }).ToList();

                    await compraContexto.CarritoDetalle.AddRangeAsync(detalles, cancellationToken);
                    await compraContexto.SaveChangesAsync(cancellationToken);

                    return Unit.Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la transacción: " + ex.Message);
                }
            }
        }
    }
}
