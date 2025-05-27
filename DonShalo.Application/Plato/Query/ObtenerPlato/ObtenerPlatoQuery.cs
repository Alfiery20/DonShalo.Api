using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Plato.Query.ObtenerPlato
{
    public class ObtenerPlatoQuery : IRequest<IEnumerable<ObtenerPlatoQueryDTO>>
    {
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }
    }
}
