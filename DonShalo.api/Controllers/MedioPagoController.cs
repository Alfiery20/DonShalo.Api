using DonShalo.api.Filter;
using DonShalo.Application.MedioPago.Command.AgregarMedioPago;
using DonShalo.Application.MedioPago.Command.EditarMedioPago;
using DonShalo.Application.MedioPago.Command.EliminarMedioPago;
using DonShalo.Application.MedioPago.Query.ObtenerMedioPago;
using DonShalo.Application.MedioPago.Query.VerMedioPago;
using Microsoft.AspNetCore.Mvc;

namespace DonShalo.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    public class MedioPagoController : AbstractController
    {
        [HttpPost]
        [Route("registrarMedioPago")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AgregarMedioPago(AgregarMedioPagoCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerMedioPago/{termino?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerMedioPago(string? termino)
        {
            var response = await Mediator.Send(new ObtenerMedioPagoQuery
            {
                Termino = termino
            });
            return Ok(response);
        }

        [HttpGet]
        [Route("verMedioPago/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerMedioPago(int id)
        {
            var response = await Mediator.Send(new VerMedioPagoQuery()
            {
                Id = id
            });
            return Ok(response);
        }

        [HttpPut]
        [Route("editarMedioPago")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarMedioPago(EditarMedioPagoCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("eliminarMedioPago/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarMedioPago(int id)
        {
            var response = await Mediator.Send(new EliminarMedioPagoCommand()
            {
                Id = id
            });
            return Ok(response);
        }
    }
}
