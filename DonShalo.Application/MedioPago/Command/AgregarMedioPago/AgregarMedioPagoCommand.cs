using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.MedioPago.Command.AgregarMedioPago
{
    public class AgregarMedioPagoCommand : IRequest<AgregarMedioPagoCommandDTO>
    {
        public string Termino { get; set; }
    }
}
