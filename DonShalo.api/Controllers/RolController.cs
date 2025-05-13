using DonShalo.api.Filter;
using DonShalo.Application.Personal.Query.VerPersonal;
using DonShalo.Application.Rol.Query.ObtenerRol;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DonShalo.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    [Authorize]
    public class RolController : AbstractController
    {
        [HttpGet]
        [Route("obtenerRoles/{termino?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerRoles(string? termino)
        {
            var response = await Mediator.Send(new ObtenerRolQuery()
            {
                Termino = termino
            });
            return Ok(response);
        }
    }
}
