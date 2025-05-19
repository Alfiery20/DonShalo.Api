using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Mesa.Command.EditarMesa
{
    public class EditarMesaCommand : IRequest<EditarMesaCommandDTO>
    {
        public int IdMesa { get; set; }
        public string Numero { get; set; }
        public int Capacidad { get; set; }
        public int IdPiso { get; set; }
    }
}
