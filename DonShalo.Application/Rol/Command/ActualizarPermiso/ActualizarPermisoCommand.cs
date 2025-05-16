using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Rol.Command.ActualizarPermiso
{
    public class ActualizarPermisoCommand : IRequest<ActualizarPermisoCommandDTO>
    {
        public bool IdPermiso { get; set; }
        public int IdMenu { get; set; }
        public int IdRol { get; set; }
    }
}
