using FluentValidation;
using MediatR;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta: IRequest<Unit>
        {
            public string Nombre { get; set; } = string.Empty;
            public string Apellido { get; set; } = string.Empty;
            public DateTime? FechaNacimiento { get; set; }
        }
        public class EjecutaValidacion: AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty().NotNull()
                    .WithMessage("El nombre del autor es requerido")
                    .WithName("nombre_required")
                    .WithErrorCode("1001");

                RuleFor(x => x.Apellido).NotEmpty().NotNull()
                    .WithMessage("El apellido del autor es requerido")
                    .WithName("apellido_required")
                    .WithErrorCode("1001");
            }
        }
        public class Manejador : IRequestHandler<Ejecuta, Unit>
        {
            private readonly ContextoAutor contextoAutor;

            public Manejador(ContextoAutor contextoAutor)
            {
                this.contextoAutor = contextoAutor;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                AutorLibro autorLibro = new AutorLibro();
                autorLibro.AutorLibroGuid = Guid.NewGuid().ToString();
                autorLibro.Nombre = request.Nombre;
                autorLibro.Apellido = request.Apellido;
                autorLibro.FechaNacimiento = DateTime.SpecifyKind(request.FechaNacimiento.Value, DateTimeKind.Utc);
                contextoAutor.AutorLibro.Add(autorLibro);
                var valor = await contextoAutor.SaveChangesAsync();

                if(valor == 0)
                {
                    throw new Exception("No se pudo crear el autor");
                }

                return Unit.Value;
            }

        }
    }
}
