using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Pedido.Command.PagarPedido
{
    public class PagarPedidoCommand : IRequest<PagarPedidoCommandDTO>
    {
        public int IdPedido { get; set; }
    }
}
