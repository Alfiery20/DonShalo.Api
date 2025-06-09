using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Pedido.Command.AgregarPedido
{
    public class AgregarPedidoDetalle
    {
        public int IdPlato { get; set; }
        public int Cantidad { get; set; }
    }
}
