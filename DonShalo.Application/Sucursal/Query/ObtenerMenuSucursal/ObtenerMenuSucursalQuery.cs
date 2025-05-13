using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Sucursal.Query.ObtenerMenuSucursal
{
    public class ObtenerMenuSucursalQuery : IRequest<IEnumerable<ObtenerMenuSucursalQueryDTO>>
    {
        public string Termino { get; set; }
    }
}
