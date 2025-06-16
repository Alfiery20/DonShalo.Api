using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Pedido.Query.VerDetallePedidoParaPagar
{
    public class VerDetallePedidoParaPagarQueryDTO
    {
        public int Id { get; set; }
        public string NroSerie { get; set; }
        public string NroCorrelativo { get; set; }
        public string ClienteNatural { get; set; }
        public string ClienteJuridico { get; set; }
        public string Personal { get; set; }
        public string Mesa { get; set; }
        public VerDetallePedidoParaPagarDetalle[] Detalles { get; set; }
    }
}
