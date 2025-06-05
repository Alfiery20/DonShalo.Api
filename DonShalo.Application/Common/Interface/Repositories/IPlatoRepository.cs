using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Plato.Command.AgregarPlato;
using DonShalo.Application.Plato.Command.EditarPlato;
using DonShalo.Application.Plato.Command.EliminarPlato;
using DonShalo.Application.Plato.Query.ObtenerMenuPlato;
using DonShalo.Application.Plato.Query.ObtenerPlato;
using DonShalo.Application.Plato.Query.VerPlato;

namespace DonShalo.Application.Common.Interface.Repositories
{
    public interface IPlatoRepository
    {
        Task<AgregarPlatoCommandDTO> RegistrarPlato(AgregarPlatoCommand command);
        Task<IEnumerable<ObtenerPlatoQueryDTO>> ObtenerPlato(ObtenerPlatoQuery query);
        Task<VerPlatoQueryDTO> VerPlato(VerPlatoQuery query);
        Task<EditarPlatoCommandDTO> EditarPlato(EditarPlatoCommand command);
        Task<EliminarPlatoCommandDTO> EliminarPlato(EliminarPlatoCommand command);
        Task<IEnumerable<ObtenerMenuPlatoQueryDTO>> ObtenerMenuPlato(ObtenerMenuPlatoQuery query);
    }
}
