namespace TiendaServicios.Api.Compra.Modelo
{
    public class Carrito
    {
        public int CarritoId { get; set; }
        public string CarritoGuid { get; set; }
        public DateTime FechaCreacion { get; set; }
        public ICollection<CarritoDetalle> ListaDetalleCompra { get; set; }
    }
}
