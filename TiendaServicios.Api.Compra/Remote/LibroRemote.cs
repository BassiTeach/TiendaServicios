namespace TiendaServicios.Api.Compra.Remote
{
    public class LibroRemote
    {
        public int LibreriaMaterialId { get; set; }
        public Guid? LibreriaMaterialGuid { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public DateTime? FechaPublicacion { get; set; }
        public Guid? AutorLibroGuid { get; set; }
        public string AutorNombre { get; set; } = string.Empty;
    }
}
