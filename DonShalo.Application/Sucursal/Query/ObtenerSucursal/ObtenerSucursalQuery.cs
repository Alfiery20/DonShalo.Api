using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Sucursal.Query.ObtenerSucursal
{
    public class ObtenerSucursalQuery : IRequest<IEnumerable<ObtenerSucursalQueryDTO>>
    {
        public string Termino { get; set; }
    }
}
