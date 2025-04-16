using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Compra.Modelo;

namespace TiendaServicios.Api.Compra.Persistencia
{
    public class CompraContexto: DbContext
    {
        public CompraContexto(DbContextOptions<CompraContexto> options): base(options)
        {
            
        }
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<CarritoDetalle> CarritoDetalle { get; set; }
    }
}
