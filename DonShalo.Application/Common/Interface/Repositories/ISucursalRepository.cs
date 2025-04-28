using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Sucursal.Command.AgregarSucursal;
using DonShalo.Application.Sucursal.Command.EditarSucursal;
using DonShalo.Application.Sucursal.Command.EliminarSucursal;
using DonShalo.Application.Sucursal.Query.ObtenerSucursal;
using DonShalo.Application.Sucursal.Query.VerSucursal;

namespace DonShalo.Application.Common.Interface.Repositories
{
    public interface ISucursalRepository
    {
        Task<AgregarSucursalCommandDTO> RegistrarSucursal(AgregarSucursalCommand command);
        Task<IEnumerable<ObtenerSucursalQueryDTO>> ObtenerSucursales(ObtenerSucursalQuery query);
        Task<VerSucursalQueryDTO> VerSucursales(VerSucursalQuery query);
        Task<EditarSucursalCommandDTO> EditarSucursal(EditarSucursalCommand command);
        Task<EliminarSucursalCommandDTO> EliminarSucursal(EliminarSucursalCommand command);
    }
}
