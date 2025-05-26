using DonShalo.api.Filter;
using DonShalo.Application.Categoria.Command.AgregarCategoria;
using DonShalo.Application.Categoria.Command.EditarCategoria;
using DonShalo.Application.Categoria.Command.EliminarCategoria;
using DonShalo.Application.Categoria.Query.ObtenerCategoria;
using DonShalo.Application.Categoria.Query.VerCategoria;
using Microsoft.AspNetCore.Mvc;

namespace DonShalo.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    public class CategoriaController : AbstractController
    {
        [HttpPost]
        [Route("registrarCategoria")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AgregarCategoria(AgregarCategoriaCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        [Route("obtenerCategoria")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerCategoria(ObtenerCategoriaQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("verCategoria/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerCategoria(int id)
        {
            var response = await Mediator.Send(new VerCategoriaQuery()
            {
                Id = id
            });
            return Ok(response);
        }

        [HttpPut]
        [Route("editarCategoria")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarCategoria(EditarCategoriaCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("eliminarCategoria/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarCategoria(int id)
        {
            var response = await Mediator.Send(new EliminarCategoriaCommand()
            {
                IdCategoria = id
            });
            return Ok(response);
        }
    }
}
