using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Rol.Query.ObtenerMenuxRol
{
    public class ObtenerMenuxRolQuery : IRequest<IEnumerable<ObtenerMenuxRolQueryDTO>>
    {
        public int IdRol { get; set; }
    }
}
