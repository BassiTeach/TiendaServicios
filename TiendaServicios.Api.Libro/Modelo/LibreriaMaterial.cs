namespace TiendaServicios.Api.Libro.Modelo
{
    public class LibreriaMaterial
    {
        public int LibreriaMaterialId { get; set; }
        public Guid? LibreriaMaterialGuid { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public DateTime? FechaPublicacion { get; set; }
        public Guid? AutorLibroGuid { get; set; }
    }
}
