using DonShalo.api.Filter;
using DonShalo.Application.Pedido.Command.AgregarPedido;
using DonShalo.Application.Pedido.Command.EditarPedido;
using DonShalo.Application.Pedido.Command.EliminarPedido;
using DonShalo.Application.Pedido.Query.ObtenerDetallePedido;
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

        [HttpPost]
        [Route("agregarPedido")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AgregarPedido(AgregarPedidoCommand command)
        {
            command.IdPersonal = Convert.ToInt32(CurrentUser.Identifier);
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerDetallePedido/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerDetallePedido(int id)
        {
            var response = await Mediator.Send(new ObtenerDetallePedidoQuery()
            {
                IdPedido = id
            });
            return Ok(response);
        }

        [HttpPut]
        [Route("editarPedido")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarPedido(EditarPedidoCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("eliminarPedido/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarPedido(int id)
        {
            var response = await Mediator.Send(new EliminarPedidoCommand()
            {
                IdPedido = id
            });
            return Ok(response);
        }
    }
}
