using DonShalo.api.Filter;
using DonShalo.Application.Pedido.Query.ObtenerPedidoMesa;
using DonShalo.Application.Personal.Query.VerPersonal;
using Microsoft.AspNetCore.Mvc;

namespace DonShalo.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    public class PedidoController : AbstractController
    {

        [HttpGet]
        [Route("obtenerPedidoMesa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPedidoMesa(int id)
        {
            var response = await Mediator.Send(new ObtenerPedidoMesaQuery()
            {
                IdMesa = id
            });
            return Ok(response);
        }
    }
}
