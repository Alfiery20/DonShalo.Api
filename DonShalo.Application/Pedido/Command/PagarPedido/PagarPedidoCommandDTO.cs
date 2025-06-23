using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Pedido.Command.PagarPedido
{
    public class PagarPedidoCommandDTO
    {
        public string Codigo { get; set; }
        public string Mensaje { get; set; }
    }
}
