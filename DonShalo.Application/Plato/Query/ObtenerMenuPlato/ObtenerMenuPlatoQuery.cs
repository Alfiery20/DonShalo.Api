using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Plato.Query.ObtenerMenuPlato
{
    public class ObtenerMenuPlatoQuery : IRequest<IEnumerable<ObtenerMenuPlatoQueryDTO>>
    {
        public int IdCategoria { get; set; }
    }
}
