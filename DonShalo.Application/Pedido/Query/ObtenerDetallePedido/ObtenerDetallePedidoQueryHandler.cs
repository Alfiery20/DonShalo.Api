using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Application.Rol.Query.obtenerMenuRol;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Pedido.Query.ObtenerDetallePedido
{
    public class ObtenerDetallePedidoQueryHandler : IRequestHandler<ObtenerDetallePedidoQuery, IEnumerable<ObtenerDetallePedidoQueryDTO>>
    {
        private readonly ILogger<obtenerMenuRolQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _pedidoRepository;

        public ObtenerDetallePedidoQueryHandler(
            ILogger<obtenerMenuRolQueryHandler> logger,
            IMapper mapper,
            IPedidoRepository pedidoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._pedidoRepository = pedidoRepository;
        }
        public Task<IEnumerable<ObtenerDetallePedidoQueryDTO>> Handle(ObtenerDetallePedidoQuery request, CancellationToken cancellationToken)
        {
            var response = this._pedidoRepository.ObtenerDetallePedido(request);
            return response;
        }
    }
}
