using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Personal.Command.EliminarPersonal
{
    public class EliminarPersonalCommand : IRequest<EliminarPersonalCommandDTO>
    {
        public int IdPersonal { get; set; }
    }
}
