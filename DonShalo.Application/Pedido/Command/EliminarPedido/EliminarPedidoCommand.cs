using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Pedido.Command.EliminarPedido
{
    public class EliminarPedidoCommand : IRequest<EliminarPedidoCommandDTO>
    {
        public int IdPedido { get; set; }
    }
}
