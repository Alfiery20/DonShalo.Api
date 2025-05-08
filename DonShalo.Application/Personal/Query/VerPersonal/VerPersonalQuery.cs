using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Personal.Query.VerPersonal
{
    public class VerPersonalQuery : IRequest<VerPersonalQueryDTO>
    {
        public int IdPersonal { get; set; }
    }
}
