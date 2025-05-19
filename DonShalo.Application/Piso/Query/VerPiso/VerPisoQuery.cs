using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Piso.Query.VerPiso
{
    public class VerPisoQuery : IRequest<VerPisoQueryDTO>
    {
        public int IdPiso { get; set; }
    }
}
