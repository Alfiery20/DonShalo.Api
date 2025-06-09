using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Pedido.Command.EditarPedido
{
    public class EditarPedidoCommand : IRequest<EditarPedidoCommandDTO>
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public EditarPedidoDetalle[] DetallePedido { get; set; }
    }
}
