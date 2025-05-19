using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Piso.Command.EditarPiso
{
    public class EditarPisoCommand : IRequest<EditarPisoCommandDTO>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CapacidadClientes { get; set; }
        public int CapacidadEmpleados { get; set; }
        public int IdSucursal { get; set; }
    }
}
