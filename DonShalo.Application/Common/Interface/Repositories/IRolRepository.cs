using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Rol.Query.ObtenerRol;

namespace DonShalo.Application.Common.Interface.Repositories
{
    public interface IRolRepository
    {
        Task<IEnumerable<ObtenerRolQueryDTO>> ObtenerRol(ObtenerRolQuery query);
    }
}
