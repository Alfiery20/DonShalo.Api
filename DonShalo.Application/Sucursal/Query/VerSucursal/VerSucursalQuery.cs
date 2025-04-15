using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Sucursal.Query.VerSucursal
{
    public class VerSucursalQuery : IRequest<VerSucursalQueryDTO>
    {
        public int Id { get; set; }
    }
}
