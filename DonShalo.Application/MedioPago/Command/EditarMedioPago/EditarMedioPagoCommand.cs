using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.MedioPago.Command.EditarMedioPago
{
    public class EditarMedioPagoCommand : IRequest<EditarMedioPagoCommandDTO>
    {
        public int Id { get; set; }
        public string Termino{ get; set; }
    }
}
