using MediatR;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Compra.Aplicacion;

namespace TiendaServicios.Api.Compra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly IMediator mediator;
        public CompraController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> crear(Nuevo.Ejecuta data)
        {
            return await mediator.Send(data);
        }

        [HttpGet("{id}")]
        public async Task<CarritoDTO> consultarCompra(int id)
        {
            return await mediator.Send(new ConsultarCompra.Ejecuta
            {
                CarritoId = id
            });
        }
    }
}
