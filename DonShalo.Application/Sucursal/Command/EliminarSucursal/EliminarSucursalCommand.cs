using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Sucursal.Command.EliminarSucursal
{
    public class EliminarSucursalCommand : IRequest<EliminarSucursalCommandDTO>
    {
        public int Id { get; set; }
    }
}
