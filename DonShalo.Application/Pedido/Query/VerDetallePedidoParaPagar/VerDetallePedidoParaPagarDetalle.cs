using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Pedido.Query.VerDetallePedidoParaPagar
{
    public class VerDetallePedidoParaPagarDetalle
    {
        public int Id { get; set; }
        public string Plato { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
    }
}
