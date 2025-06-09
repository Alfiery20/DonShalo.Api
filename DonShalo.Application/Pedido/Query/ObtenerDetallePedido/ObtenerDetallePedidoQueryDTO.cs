using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Pedido.Query.ObtenerDetallePedido
{
    public class ObtenerDetallePedidoQueryDTO
    {
        public int IdPlato { get; set; }
        public string Plato { get; set; }
        public double Cantidad { get; set; }
    }
}
