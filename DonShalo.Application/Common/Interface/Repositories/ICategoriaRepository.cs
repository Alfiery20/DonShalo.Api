using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Categoria.Command.AgregarCategoria;
using DonShalo.Application.Categoria.Command.EditarCategoria;
using DonShalo.Application.Categoria.Command.EliminarCategoria;
using DonShalo.Application.Categoria.Query.ObtenerCategoria;
using DonShalo.Application.Categoria.Query.ObtenerMenuCategoria;
using DonShalo.Application.Categoria.Query.VerCategoria;
using DonShalo.Application.Mesa.Command.EliminarMesa;

namespace DonShalo.Application.Common.Interface.Repositories
{
    public interface ICategoriaRepository
    {
        Task<AgregarCategoriaCommandDTO> RegistrarCategoria(AgregarCategoriaCommand command);
        Task<EditarCategoriaCommandDTO> EditarCategoria(EditarCategoriaCommand command);
        Task<EliminarCategoriaCommandDTO> EliminarCategoria(EliminarCategoriaCommand command);
        Task<IEnumerable<ObtenerCategoriaQueryDTO>> ObtenerCategoria(ObtenerCategoriaQuery query);
        Task<VerCategoriaQueryDTO> VerCategoria(VerCategoriaQuery query);
        Task<IEnumerable<ObtenerMenuCategoriaQueryDTO>> ObtenerMenuCategoria(ObtenerMenuCategoriaQuery query);
    }
}
