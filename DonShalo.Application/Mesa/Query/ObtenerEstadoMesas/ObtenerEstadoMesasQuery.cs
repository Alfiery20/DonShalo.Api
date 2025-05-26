using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Mesa.Query.ObtenerEstadoMesas
{
    public class ObtenerEstadoMesasQuery : IRequest<IEnumerable<ObtenerEstadoMesasQueryDTO>>
    {
        public int IdPiso { get; set; }
    }
}
