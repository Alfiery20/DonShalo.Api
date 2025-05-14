using DonShalo.api.Filter;
using DonShalo.Application.Personal.Query.VerPersonal;
using DonShalo.Application.Rol.Command.EditarRol;
using DonShalo.Application.Rol.Command.EliminarRol;
using DonShalo.Application.Rol.Command.RegistrarRol;
using DonShalo.Application.Rol.Query.ObtenerRol;
using DonShalo.Application.Rol.Query.VerRol;
using DonShalo.Application.Sucursal.Command.AgregarSucursal;
using DonShalo.Application.Sucursal.Command.EditarSucursal;
using DonShalo.Application.Sucursal.Command.EliminarSucursal;
using DonShalo.Application.Sucursal.Query.ObtenerSucursal;
using DonShalo.Application.Sucursal.Query.VerSucursal;
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

        [HttpPost]
        [Route("registrarRol")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AgregarSucursal(RegistrarRolCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("verRol/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerSucursal(int id)
        {
            var response = await Mediator.Send(new VerRolQuery()
            {
                IdRol = id
            });
            return Ok(response);
        }

        [HttpPut]
        [Route("editarRol")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarSucursal(EditarRolCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("eliminarRol/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarSucursal(int id)
        {
            var response = await Mediator.Send(new EliminarRolCommand()
            {
                IdRol = id
            });
            return Ok(response);
        }
    }
}
