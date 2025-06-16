using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Pedido.Query.VerDetallePedidoParaPagar
{
    public class VerDetallePedidoParaPagarQuery : IRequest<VerDetallePedidoParaPagarQueryDTO>
    {
        public int IdPedido { get; set; }
    }
}
