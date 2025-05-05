using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Autorizacion.Command.ObtenerMenu
{
    public class ObtenerMenuCommand : IRequest<IEnumerable<ObtenerMenuCommandDTO>>
    {
        public int IdRol { get; set; }
        public int IdUsuario { get; set; }
    }
}
