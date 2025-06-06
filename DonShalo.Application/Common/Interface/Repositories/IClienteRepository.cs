using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Cliente.Command.AgregarCliente;
using DonShalo.Application.Cliente.Command.EditarCliente;
using DonShalo.Application.Cliente.Query.ObtenerClienteDoc;
using DonShalo.Application.Cliente.Query.VerCliente;

namespace DonShalo.Application.Common.Interface.Repositories
{
    public interface IClienteRepository
    {
        Task<ObtenerClienteDocQueryDTO> ObtenerClientePorDoc(ObtenerClienteDocQuery query);
        Task<VerClienteQueryDTO> VerCliente(VerClienteQuery query);
        Task<AgregarClienteCommandDTO> RegistrarCliente(AgregarClienteCommand command);
        Task<EditarClienteCommandDTO> EditarCliente(EditarClienteCommand command);
    }
}
