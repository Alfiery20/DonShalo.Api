using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Cliente.Query.ObtenerClienteDoc;

namespace DonShalo.Application.Common.Interface.Repositories
{
    public interface IClienteRepository
    {
        Task<ObtenerClienteDocQueryDTO> ObtenerClientePorDoc(ObtenerClienteDocQuery query);
    }
}
