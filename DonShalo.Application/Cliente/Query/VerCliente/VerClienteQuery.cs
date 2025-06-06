using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Cliente.Query.VerCliente
{
    public class VerClienteQuery : IRequest<VerClienteQueryDTO>
    {
        public int Id { get; set; }
    }
}
