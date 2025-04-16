namespace TiendaServicios.Api.Compra.Aplicacion
{
    public class CarritoDTO
    {
        public int CarritoId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public List<CarritoDetalleDTO> ListaDetalleCompra { get; set; } = new List<CarritoDetalleDTO>();
    }
}
