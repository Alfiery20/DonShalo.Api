using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Personal.Query.ObtenerPersonal
{
    public class ObtenerPersonalQuery : IRequest<IEnumerable<ObtenerPersonalQueryDTO>>
    {
        public string CodigoPersonal { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public int IdRol { get; set; }
    }
}
