using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Pedido.Command.AgregarPedido
{
    public class AgregarPedidoCommand : IRequest<AgregarPedidoCommandDTO>
    {
        public int IdCliente { get; set; }
        public int IdMesa { get; set; }
        public int IdPersonal { get; set; }
        public AgregarPedidoDetalle[] DetallePedido { get; set; }
    }
}
