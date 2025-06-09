using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Pedido.Query.ObtenerDetallePedido
{
    public class ObtenerDetallePedidoQuery : IRequest<IEnumerable<ObtenerDetallePedidoQueryDTO>>
    {
        public int IdPedido { get; set; }
    }
}
