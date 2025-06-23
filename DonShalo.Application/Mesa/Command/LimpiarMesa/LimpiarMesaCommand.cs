using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Mesa.Command.LimpiarMesa
{
    public class LimpiarMesaCommand : IRequest<LimpiarMesaCommandDTO>
    {
        public int IdMesa { get; set; }
    }
}
