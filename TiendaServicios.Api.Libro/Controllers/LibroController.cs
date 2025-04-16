using MediatR;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Libro.Aplicacion;

namespace TiendaServicios.Api.Libro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IMediator mediator;
        public LibroController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> crear(Nuevo.Ejecuta data)
        {
            return await mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<LibreriaMaterialDTO>>> consulta()
        {
            return await mediator.Send(new Consulta.ListaLibreriaMaterial());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibreriaMaterialDTO>> consultarPorId(Guid id)
        {
            return await mediator.Send(new ConsultarPorId.ConsultarLibreriaMaterial
            {
                LibreriaMaterialGuid = id
            });
        }
    }
}
