using DonShalo.api.Filter;
using DonShalo.Application.Personal.Command.RegistrarUsuario;
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
    }
}
