using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.MedioPago.Query.VerMedioPago
{
    public class VerMedioPagoQuery : IRequest<VerMedioPagoQueryDTO>
    {
        public int Id { get; set; }
    }
}
