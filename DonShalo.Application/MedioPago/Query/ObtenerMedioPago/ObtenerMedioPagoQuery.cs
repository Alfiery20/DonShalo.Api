using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.MedioPago.Query.ObtenerMedioPago
{
    public class ObtenerMedioPagoQuery : IRequest<IEnumerable<ObtenerMedioPagoQueryDTO>>
    {
        public string Termino { get; set; }
    }
}
