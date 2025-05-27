using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Plato.Command.EliminarPlato
{
    public class EliminarPlatoCommand : IRequest<EliminarPlatoCommandDTO>
    {
        public int Id { get; set; }
    }
}
