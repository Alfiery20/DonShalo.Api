using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Rol.Command.ActualizarPermiso;
using DonShalo.Application.Rol.Command.EditarRol;
using DonShalo.Application.Rol.Command.EliminarRol;
using DonShalo.Application.Rol.Command.RegistrarRol;
using DonShalo.Application.Rol.Query.obtenerMenuRol;
using DonShalo.Application.Rol.Query.ObtenerMenuxRol;
using DonShalo.Application.Rol.Query.ObtenerRol;
using DonShalo.Application.Rol.Query.VerRol;

namespace DonShalo.Application.Common.Interface.Repositories
{
    public interface IRolRepository
    {
        Task<IEnumerable<ObtenerRolQueryDTO>> ObtenerRol(ObtenerRolQuery query);
        Task<RegistrarRolCommandDTO> RegistrarRol(RegistrarRolCommand command);
        Task<VerRolQueryDTO> VerRol(VerRolQuery query);
        Task<EditarRolCommandDTO> EditarRol(EditarRolCommand command);
        Task<EliminarRolCommandDTO> EliminarRol(EliminarRolCommand command);
        Task<IEnumerable<obtenerMenuRolQueryDTO>> ObtenerMenuRol(obtenerMenuRolQuery query);
        Task<IEnumerable<ObtenerMenuxRolQueryDTO>> ObtenerMenuXRol(ObtenerMenuxRolQuery query);
        Task<ActualizarPermisoCommandDTO> ActualizarPermiso(ActualizarPermisoCommand command);
    }
}
