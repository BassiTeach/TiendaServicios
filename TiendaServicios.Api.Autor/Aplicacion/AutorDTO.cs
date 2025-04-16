namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class AutorDto
    {
        public string AutorLibroGuid { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; }
    }
}
