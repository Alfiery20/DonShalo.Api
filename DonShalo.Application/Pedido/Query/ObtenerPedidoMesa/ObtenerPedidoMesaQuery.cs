using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Rol.Query.obtenerMenuRol;
using MediatR;

namespace DonShalo.Application.Pedido.Query.ObtenerPedidoMesa
{
    public class ObtenerPedidoMesaQuery : IRequest<ObtenerPedidoMesaQueryDTO>
    {
        public int IdMesa { get; set; }
    }
}
