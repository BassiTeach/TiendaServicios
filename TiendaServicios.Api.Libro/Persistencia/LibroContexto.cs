using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Persistencia
{
    public class LibroContexto: DbContext
    {
        public LibroContexto(DbContextOptions<LibroContexto> options): base(options)
        {
            
        }
        public DbSet<LibreriaMaterial> LibreriaMaterial { get; set; }
    }
}
