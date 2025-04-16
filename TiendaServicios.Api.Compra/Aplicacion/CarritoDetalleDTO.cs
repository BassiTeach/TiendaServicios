namespace TiendaServicios.Api.Compra.Aplicacion
{
    public class CarritoDetalleDTO
    {
        public Guid? LibroId { get; set; }
        public string TituloLibro { get; set; } = string.Empty;
        public string AutorLibro { get; set; } = string.Empty;
        public DateTime? FechaPublicacion { get; set; }
    }
}
