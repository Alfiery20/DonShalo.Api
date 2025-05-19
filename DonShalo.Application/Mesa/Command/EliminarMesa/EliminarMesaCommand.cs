using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Mesa.Command.EliminarMesa
{
    public class EliminarMesaCommand : IRequest<EliminarMesaCommandDTO>
    {
        public int IdMesa { get; set; }
    }
}
