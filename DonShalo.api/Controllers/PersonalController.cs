using DonShalo.api.Filter;
using DonShalo.Application.Personal.Command.AsignarResponsable;
using DonShalo.Application.Personal.Command.EditarPersonal;
using DonShalo.Application.Personal.Command.EliminarPersonal;
using DonShalo.Application.Personal.Command.RegistrarUsuario;
using DonShalo.Application.Personal.Query.ObtenerMenuPersonal;
using DonShalo.Application.Personal.Query.ObtenerPersonal;
using DonShalo.Application.Personal.Query.VerPersonal;
using DonShalo.Application.Sucursal.Command.EliminarSucursal;
using DonShalo.Application.Sucursal.Query.ObtenerMenuSucursal;
using DonShalo.Application.Sucursal.Query.VerSucursal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DonShalo.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    public class PersonalController : AbstractController
    {
        [HttpPost]
        [Route("registrarPersonal")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RegistrarUsuario(RegistrarUsuarioCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        [Route("obtenerPersonal")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerUsuario(ObtenerPersonalQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("verPersonal/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerPersonal(int id)
        {
            var response = await Mediator.Send(new VerPersonalQuery()
            {
                IdPersonal = id
            });
            return Ok(response);
        }

        [HttpPut]
        [Route("editarPersonal")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarUsuario(EditarPersonalCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("eliminarPersonal/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarSucursal(int id)
        {
            var response = await Mediator.Send(new EliminarPersonalCommand()
            {
                IdPersonal = id
            });
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerMenuPersonal/{termino?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerMenuPersonal(string? termino)
        {
            var response = await Mediator.Send(new ObtenerMenuPersonalQuery()
            {
                Termino = termino
            });
            return Ok(response);
        }

        [HttpPost]
        [Route("asignarPersonal")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AsignarPersonal(AsignarResponsableCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
