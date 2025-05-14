using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Rol.Query.VerRol
{
    public class VerRolQuery : IRequest<VerRolQueryDTO>
    {
        public int IdRol { get; set; }
    }
}
