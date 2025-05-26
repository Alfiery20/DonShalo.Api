using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Mesa.Command.AgregarMesa;
using DonShalo.Application.Mesa.Command.EditarMesa;
using DonShalo.Application.Mesa.Command.EliminarMesa;
using DonShalo.Application.Mesa.Query.ObtenerEstadoMesas;
using DonShalo.Application.Mesa.Query.ObtenerMesa;
using DonShalo.Application.Mesa.Query.VerMesa;

namespace DonShalo.Application.Common.Interface.Repositories
{
    public interface IMesaRespository
    {
        Task<AgregarMesaCommandDTO> RegistrarMesa(AgregarMesaCommand command);
        Task<EditarMesaCommandDTO> EditarMesa(EditarMesaCommand command);
        Task<EliminarMesaCommandDTO> EliminarMesa(EliminarMesaCommand command);
        Task<IEnumerable<ObtenerMesaQueryDTO>> ObtenerMesa(ObtenerMesaQuery query);
        Task<VerMesaQueryDTO> VerMesa(VerMesaQuery query);
        Task<IEnumerable<ObtenerEstadoMesasQueryDTO>> ObtenerEstadoMesas(ObtenerEstadoMesasQuery query);
    }
}
