using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Mesa.Query.VerMesa
{
    public class VerMesaQuery : IRequest<VerMesaQueryDTO>
    {
        public int IdMesa { get; set; }
    }
}
