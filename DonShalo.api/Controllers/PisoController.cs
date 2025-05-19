using DonShalo.api.Filter;
using DonShalo.Application.Piso.Command.EditarPiso;
using DonShalo.Application.Piso.Query.ObtenerPiso;
using DonShalo.Application.Piso.Query.VerPiso;
using DonShalo.Application.Piso.Command.AgregarPiso;
using Microsoft.AspNetCore.Mvc;
using DonShalo.Application.Piso.Command.EilminarPiso;

namespace DonShalo.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    public class PisoController : AbstractController
    {
        [HttpPost]
        [Route("registrarPiso")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AgregarPiso(AgregarPisoCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        [Route("obtenerPiso")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPiso(ObtenerPisoQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("verPiso/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerPiso(int id)
        {
            var response = await Mediator.Send(new VerPisoQuery()
            {
                IdPiso = id
            });
            return Ok(response);
        }

        [HttpPut]
        [Route("editarPiso")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarPiso(EditarPisoCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("eliminarPiso/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarPiso(int id)
        {
            var response = await Mediator.Send(new EliminarPisoCommand()
            {
                IdPiso = id
            });
            return Ok(response);
        }
    }
}
