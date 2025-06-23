using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Pedido.Command.PagarPedidoDividido
{
    public class PagarPedidoDivididoCommand : IRequest<PagarPedidoDivididoCommandDTO>
    {
        public int IdPedido { get; set; }
        public PagarPedidoDivididoDetalle[] DetallePedido { get; set; }
        public PagarPedidoDivididoSubcuenta[] Subcuentas { get; set; }
    }
}
