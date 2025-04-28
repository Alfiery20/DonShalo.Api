using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Sucursal.Command.EditarSucursal
{
    public class EditarSucursalCommand : IRequest<EditarSucursalCommandDTO>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public TimeOnly HoraIngreso { get; set; }
        public TimeOnly HoraSalida { get; set; }
    }
}
