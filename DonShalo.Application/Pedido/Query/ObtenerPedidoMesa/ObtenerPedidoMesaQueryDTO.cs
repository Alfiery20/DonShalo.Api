using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Pedido.Query.ObtenerPedidoMesa
{
    public class ObtenerPedidoMesaQueryDTO
    {
        public int IdPedido { get; set; }
        public string Serie { get; set; }
        public string Correlativo { get; set; }
        public int ClienteId { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string RUC { get; set; }
        public string RazonSocial { get; set; }
    }
}
