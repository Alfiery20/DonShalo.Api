using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Piso.Query.ObtenerPiso
{
    public class ObtenerPisoQuery : IRequest<IEnumerable<ObtenerPisoQueryDTO>>
    {
        public string Termino { get; set; }
        public int IdSucursal { get; set; }
    }
}
