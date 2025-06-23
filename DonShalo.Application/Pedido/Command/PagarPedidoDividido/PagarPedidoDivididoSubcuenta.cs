using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Pedido.Command.PagarPedidoDividido
{
    public class PagarPedidoDivididoSubcuenta
    {
        public int IdCliente { get; set; }
        public PagarPedidoDivididoDetalle[] DetallePedidoSubcuenta { get; set; }
    }
}
