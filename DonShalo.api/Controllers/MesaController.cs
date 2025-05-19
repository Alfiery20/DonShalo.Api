using DonShalo.api.Filter;
using DonShalo.Application.Mesa.Command.AgregarMesa;
using DonShalo.Application.Mesa.Command.EditarMesa;
using DonShalo.Application.Mesa.Command.EliminarMesa;
using DonShalo.Application.Mesa.Query.ObtenerMesa;
using DonShalo.Application.Mesa.Query.VerMesa;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DonShalo.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    public class MesaController : AbstractController
    {
        [HttpPost]
        [Route("registrarMesa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AgregarMesa(AgregarMesaCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        [Route("obtenerMesa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerMesa(ObtenerMesaQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("verMesa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerMesa(int id)
        {
            var response = await Mediator.Send(new VerMesaQuery()
            {
                IdMesa = id
            });
            return Ok(response);
        }

        [HttpPut]
        [Route("editarMesa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarMesa(EditarMesaCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("eliminarMesa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarMesa(int id)
        {
            var response = await Mediator.Send(new EliminarMesaCommand()
            {
                IdMesa = id
            });
            return Ok(response);
        }
    }
}
