using FluentValidation;
using MediatR;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta: IRequest<Unit>
        {
            public string Titulo { get; set; }
            public DateTime? FechaPublicacion { get; set; }
            public Guid? AutorLibroGuid { get; set; }
        }
        public class EjecutaValidacion: AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Titulo).NotEmpty().NotNull();
            }
        }
        public class Manejador : IRequestHandler<Ejecuta, Unit>
        {
            private readonly LibroContexto libroContexto;
            public Manejador(LibroContexto libroContexto)
            {
                this.libroContexto = libroContexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                LibreriaMaterial libreriaMaterial = new();
                libreriaMaterial.LibreriaMaterialGuid = Guid.NewGuid();
                libreriaMaterial.Titulo = request.Titulo;
                libreriaMaterial.FechaPublicacion = request.FechaPublicacion;
                libreriaMaterial.AutorLibroGuid = request.AutorLibroGuid;
                libroContexto.Add(libreriaMaterial);
                var valor = await libroContexto.SaveChangesAsync();

                if (valor == 0)
                {
                    throw new Exception("No se pudo crear el Libro");
                }

                return Unit.Value;
            }
        }
    }
}
