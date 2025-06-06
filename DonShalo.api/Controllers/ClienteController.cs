using DonShalo.api.Filter;
using DonShalo.Application.Cliente.Command.AgregarCliente;
using DonShalo.Application.Cliente.Command.EditarCliente;
using DonShalo.Application.Cliente.Query.ObtenerClienteDoc;
using DonShalo.Application.Cliente.Query.VerCliente;
using DonShalo.Application.Mesa.Query.ObtenerEstadoMesas;
using Microsoft.AspNetCore.Mvc;

namespace DonShalo.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    public class ClienteController : AbstractController
    {
        [HttpGet]
        [Route("obtenerClienteDoc/{documento}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerClienteDoc(string documento)
        {
            var response = await Mediator.Send(new ObtenerClienteDocQuery()
            {
                NumeroDocumento = documento
            });
            return Ok(response);
        }

        [HttpGet]
        [Route("verCliente/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerCliente(int id)
        {
            var response = await Mediator.Send(new VerClienteQuery()
            {
                Id = id
            });
            return Ok(response);
        }

        [HttpPost]
        [Route("registrarCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RegistrarCliente(AgregarClienteCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Route("editarCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarCliente(EditarClienteCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
