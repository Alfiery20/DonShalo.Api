using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Rol.Query.ObtenerRol
{
    public class ObtenerRolQuery : IRequest<IEnumerable<ObtenerRolQueryDTO>>
    {
        public string Termino { get; set; }
    }
}
