using DonShalo.Application.Autenticacion.Command.IniciarSesion;
using DonShalo.Application.Autenticacion.Command.RegistrarUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DonShalo.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AutenticacionController : AbstractController
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
        [Route("iniciarSesion")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IniciarSesion(IniciarSesionCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
