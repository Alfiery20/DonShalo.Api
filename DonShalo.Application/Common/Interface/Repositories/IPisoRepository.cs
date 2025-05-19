using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Piso.Command.AgregarPiso;
using DonShalo.Application.Piso.Command.EditarPiso;
using DonShalo.Application.Piso.Command.EilminarPiso;
using DonShalo.Application.Piso.Query.ObtenerPiso;
using DonShalo.Application.Piso.Query.VerPiso;

namespace DonShalo.Application.Common.Interface.Repositories
{
    public interface IPisoRepository
    {
        Task<AgregarPisoCommandDTO> RegistrarPiso(AgregarPisoCommand command);
        Task<IEnumerable<ObtenerPisoQueryDTO>> ObtenerPiso(ObtenerPisoQuery query);
        Task<VerPisoQueryDTO> VerPiso(VerPisoQuery query);
        Task<EliminarPisoCommandDTO> EliminarPiso(EliminarPisoCommand command);
        Task<EditarPisoCommandDTO> EditarPiso(EditarPisoCommand command);
    }
}
