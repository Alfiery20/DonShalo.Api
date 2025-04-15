using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Sucursal.Command.AgregarSucursal
{
    public class AgregarSucursalCommand : IRequest<AgregarSucursalCommandDTO>
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdEncargado { get; set; }
        public TimeOnly FechaEntrada { get; set; }
        public TimeOnly FechaSalida { get; set; }
    }
}
