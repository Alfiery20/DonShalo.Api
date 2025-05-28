using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Plato.Command.AgregarPlato
{
    public class AgregarPlatoCommand : IRequest<AgregarPlatoCommandDTO>
    {
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }
        public double Precio { get; set; }
    }
}
