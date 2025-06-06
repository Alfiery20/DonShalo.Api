using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Cliente.Command.EditarCliente
{
    public class EditarClienteCommand : IRequest<EditarClienteCommandDTO>
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string DireccionEntrega { get; set; }
    }
}
