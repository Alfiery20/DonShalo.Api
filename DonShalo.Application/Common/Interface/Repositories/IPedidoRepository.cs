using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Pedido.Command.AgregarPedido;
using DonShalo.Application.Pedido.Command.EditarPedido;
using DonShalo.Application.Pedido.Command.EliminarPedido;
using DonShalo.Application.Pedido.Command.PagarPedido;
using DonShalo.Application.Pedido.Command.PagarPedidoDividido;
using DonShalo.Application.Pedido.Query.ObtenerDetallePedido;
using DonShalo.Application.Pedido.Query.ObtenerPedidoMesa;
using DonShalo.Application.Pedido.Query.VerDetallePedidoParaPagar;

namespace DonShalo.Application.Common.Interface.Repositories
{
    public interface IPedidoRepository
    {
        Task<ObtenerPedidoMesaQueryDTO> ObtenerPedidoMesa(ObtenerPedidoMesaQuery query);
        Task<AgregarPedidoCommandDTO> RegistrarPedido(AgregarPedidoCommand command);
        Task<IEnumerable<ObtenerDetallePedidoQueryDTO>> ObtenerDetallePedido(ObtenerDetallePedidoQuery query);
        Task<EditarPedidoCommandDTO> EditarPedido(EditarPedidoCommand command);
        Task<EliminarPedidoCommandDTO> EliminarPedido(EliminarPedidoCommand command);
        Task<VerDetallePedidoParaPagarQueryDTO> VerDetallePedidoParaPagar(VerDetallePedidoParaPagarQuery query);
        Task<IEnumerable<VerDetallePedidoParaPagarDetalle>> VerDetallesPago(int idPedido);
        Task<PagarPedidoDivididoCommandDTO> PagarPedidoDividido(PagarPedidoDivididoCommand command);
        Task<PagarPedidoCommandDTO> PagarPedido(PagarPedidoCommand command);
    }
}
