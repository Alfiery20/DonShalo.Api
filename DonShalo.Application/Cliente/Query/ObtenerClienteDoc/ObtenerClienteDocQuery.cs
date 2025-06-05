using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Cliente.Query.ObtenerClienteDoc
{
    public class ObtenerClienteDocQuery : IRequest<ObtenerClienteDocQueryDTO>
    {
        public string NumeroDocumento { get; set; }
    }
}
