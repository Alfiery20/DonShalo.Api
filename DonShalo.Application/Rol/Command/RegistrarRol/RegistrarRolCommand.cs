using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Rol.Command.RegistrarRol
{
    public class RegistrarRolCommand : IRequest<RegistrarRolCommandDTO>
    {
        public string Nombre { get; set; } 
    }
}
