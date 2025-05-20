using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.MedioPago.Command.EliminarMedioPago
{
    public class EliminarMedioPagoCommand : IRequest<EliminarMedioPagoCommandDTO>
    {
        public int Id { get; set; }
    }
}
