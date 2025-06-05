using DonShalo.api.Filter;
using DonShalo.Application.Cliente.Query.ObtenerClienteDoc;
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
        public async Task<IActionResult> ObtenerEstadoMesas(string documento)
        {
            var response = await Mediator.Send(new ObtenerClienteDocQuery()
            {
                NumeroDocumento = documento
            });
            return Ok(response);
        }
    }
}
