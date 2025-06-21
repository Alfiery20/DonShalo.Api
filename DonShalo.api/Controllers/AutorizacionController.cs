using DonShalo.api.Filter;
using DonShalo.Application.Autorizacion.Command.ObtenerMenu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DonShalo.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    public class AutorizacionController : AbstractController
    {
        [HttpGet]
        [Authorize]
        [Route("UserInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UserInfo()
        {
            return Ok(CurrentUser);
        }

        [HttpGet]
        [Authorize]
        [Route("obtenerMenu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerMenu()
        {
            var response = await Mediator.Send(new ObtenerMenuCommand()
            {
                IdRol = Convert.ToInt32(CurrentUser.RolId),
                IdUsuario = Convert.ToInt32(CurrentUser.Identifier)
            });
            return Ok(response);
        }

        [HttpGet("token-check")]
        public IActionResult TokenCheck()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            return Ok($"Header recibido: {authHeader}");
        }

    }
}
