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

namespace DonShalo.Application.Pedido.Query.ObtenerPedidoMesa
{
    public class ObtenerPedidoMesaQueryHandler : IRequestHandler<ObtenerPedidoMesaQuery, ObtenerPedidoMesaQueryDTO>
    {
        private readonly ILogger<obtenerMenuRolQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _pedidoRepository;

        public ObtenerPedidoMesaQueryHandler(
            ILogger<obtenerMenuRolQueryHandler> logger,
            IMapper mapper,
            IPedidoRepository pedidoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._pedidoRepository = pedidoRepository;
        }
        public Task<ObtenerPedidoMesaQueryDTO> Handle(ObtenerPedidoMesaQuery request, CancellationToken cancellationToken)
        {
            var response = this._pedidoRepository.ObtenerPedidoMesa(request);
            return response;
        }
    }
}
