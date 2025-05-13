using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Personal.Command.AsignarResponsable
{
    public class AsignarResponsableCommand : IRequest<AsignarResponsableCommandDTO>
    {
        public int IdPersonal { get; set; }
    }
}
