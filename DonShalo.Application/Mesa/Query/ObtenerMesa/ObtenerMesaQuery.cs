using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Mesa.Query.ObtenerMesa
{
    public class ObtenerMesaQuery : IRequest<IEnumerable<ObtenerMesaQueryDTO>>
    {
        public string Termino { get; set; }
        public int IdPiso { get; set; }
        public int IdSucursal { get; set; }
    }
}
