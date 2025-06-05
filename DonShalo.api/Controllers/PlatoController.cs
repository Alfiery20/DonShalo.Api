using DonShalo.api.Filter;
using DonShalo.Application.Plato.Command.AgregarPlato;
using DonShalo.Application.Plato.Command.EditarPlato;
using DonShalo.Application.Plato.Command.EliminarPlato;
using DonShalo.Application.Plato.Query.ObtenerMenuPlato;
using DonShalo.Application.Plato.Query.ObtenerPlato;
using DonShalo.Application.Plato.Query.VerPlato;
using Microsoft.AspNetCore.Mvc;

namespace DonShalo.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    public class PlatoController : AbstractController
    {
        [HttpPost]
        [Route("registrarPlato")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AgregarPlato(AgregarPlatoCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        [Route("obtenerPlato")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPlato(ObtenerPlatoQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("verPlato/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerPlato(int id)
        {
            var response = await Mediator.Send(new VerPlatoQuery()
            {
                IdPlato = id
            });
            return Ok(response);
        }

        [HttpPut]
        [Route("editarPlato")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarPlato(EditarPlatoCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("eliminarPlato/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarPlato(int id)
        {
            var response = await Mediator.Send(new EliminarPlatoCommand()
            {
                Id = id
            });
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerMenuPlato/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerMenuPlato(int id)
        {
            var response = await Mediator.Send(new ObtenerMenuPlatoQuery()
            {
                IdCategoria = id
            });
            return Ok(response);
        }
    }
}
