using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Personal.Query.ObtenerMenuPersonal
{
    public class ObtenerMenuPersonalQuery : IRequest<IEnumerable<ObtenerMenuPersonalQueryDTO>>
    {
        public string Termino { get; set; }
    }
}
