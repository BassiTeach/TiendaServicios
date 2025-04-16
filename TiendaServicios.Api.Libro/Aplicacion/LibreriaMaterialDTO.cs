namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class LibreriaMaterialDTO
    {
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? AutorLibroGuid { get; set; }
        public string AutorNombre { get; set; } = string.Empty;
    }
}
