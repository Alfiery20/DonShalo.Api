using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Piso.Command.EilminarPiso
{
    public class EliminarPisoCommand : IRequest<EliminarPisoCommandDTO>
    {
        public int IdPiso { get; set; }
    }
}
