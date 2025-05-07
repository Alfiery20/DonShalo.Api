using DonShalo.api.Filter;
using DonShalo.Application.Autenticacion.Command.IniciarSesion;
using DonShalo.Application.Sucursal.Command.AgregarSucursal;
using DonShalo.Application.Sucursal.Command.EditarSucursal;
using DonShalo.Application.Sucursal.Command.EliminarSucursal;
using DonShalo.Application.Sucursal.Query.ObtenerSucursal;
using DonShalo.Application.Sucursal.Query.VerSucursal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DonShalo.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    [Authorize]
    public class SucursalController : AbstractController
    {
        [HttpPost]
        [Route("registrarSucursal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AgregarSucursal(AgregarSucursalCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerSucursal/{termino?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerSucursal(string? termino)
        {
            var response = await Mediator.Send(new ObtenerSucursalQuery()
            {
                Termino = termino
            });
            return Ok(response);
        }

        [HttpGet]
        [Route("verSucursal/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerSucursal(int id)
        {
            var response = await Mediator.Send(new VerSucursalQuery()
            {
                Id = id
            });
            return Ok(response);
        }

        [HttpPut]
        [Route("editarSucursal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarSucursal(EditarSucursalCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("eliminarSucursal/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarSucursal(int id)
        {
            var response = await Mediator.Send(new EliminarSucursalCommand()
            {
                Id = id
            });
            return Ok(response);
        }
    }
}
