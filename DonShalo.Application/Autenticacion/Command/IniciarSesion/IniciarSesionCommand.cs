using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Autenticacion.Command.IniciarSesion
{
    public class IniciarSesionCommand : IRequest<IniciarSesionCommandDTO>
    {
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}
