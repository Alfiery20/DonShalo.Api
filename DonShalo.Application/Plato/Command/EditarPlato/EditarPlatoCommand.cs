using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Plato.Command.EditarPlato
{
    public class EditarPlatoCommand : IRequest<EditarPlatoCommandDTO>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Monto { get; set; }
        public int IdCategoria { get; set; }
    }
}
