namespace TiendaServicios.Api.Compra.Modelo
{
    public class CarritoDetalle
    {
        public int CarritoDetalleId { get; set; }
        public string CarritoDetalleGuid { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ProductSeleccionado { get; set; }
        public int CarritoId { get; set; }
        public Carrito Carrito { get; set; }
    }
}
