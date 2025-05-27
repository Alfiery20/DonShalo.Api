using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Plato.Query.VerPlato
{
    public class VerPlatoQuery : IRequest<VerPlatoQueryDTO>
    {
        public int IdPlato { get; set; }
    }
}
