namespace TiendaServicios.Api.Libro.Remote
{
    public class AutorRemote
    {
        public int AutorLibroId { get; set; }
        public string AutorLibroGuid { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; }
    }
}
