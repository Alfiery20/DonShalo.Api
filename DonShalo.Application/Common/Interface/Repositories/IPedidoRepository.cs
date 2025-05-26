using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Pedido.Query.ObtenerPedidoMesa;

namespace DonShalo.Application.Common.Interface.Repositories
{
    public interface IPedidoRepository
    {
        Task<ObtenerPedidoMesaQueryDTO> ObtenerPedidoMesa(ObtenerPedidoMesaQuery query);
    }
}
