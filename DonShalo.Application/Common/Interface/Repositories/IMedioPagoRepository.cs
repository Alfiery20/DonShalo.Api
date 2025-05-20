using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.MedioPago.Command.AgregarMedioPago;
using DonShalo.Application.MedioPago.Command.EditarMedioPago;
using DonShalo.Application.MedioPago.Command.EliminarMedioPago;
using DonShalo.Application.MedioPago.Query.ObtenerMedioPago;
using DonShalo.Application.MedioPago.Query.VerMedioPago;

namespace DonShalo.Application.Common.Interface.Repositories
{
    public interface IMedioPagoRepository
    {
        Task<AgregarMedioPagoCommandDTO> RegistrarMedioPago(AgregarMedioPagoCommand command);
        Task<IEnumerable<ObtenerMedioPagoQueryDTO>> ObtenerMedioPagos(ObtenerMedioPagoQuery query);
        Task<VerMedioPagoQueryDTO> VerMedioPagos(VerMedioPagoQuery query);
        Task<EditarMedioPagoCommandDTO> EditarMedioPago(EditarMedioPagoCommand command);
        Task<EliminarMedioPagoCommandDTO> EliminarMedioPago(EliminarMedioPagoCommand command);
    }
}