using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Pedido.Query.VerDetallePedidoParaPagar
{
    public class VerDetallePedidoParaPagarQueryHandler : IRequestHandler<VerDetallePedidoParaPagarQuery, VerDetallePedidoParaPagarQueryDTO>
    {
        private readonly ILogger<VerDetallePedidoParaPagarQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _pedidoRepository;

        public VerDetallePedidoParaPagarQueryHandler(
            ILogger<VerDetallePedidoParaPagarQueryHandler> logger,
            IMapper mapper,
            IPedidoRepository pedidoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._pedidoRepository = pedidoRepository;
        }
        public async Task<VerDetallePedidoParaPagarQueryDTO> Handle(VerDetallePedidoParaPagarQuery request, CancellationToken cancellationToken)
        {
            var response = await this._pedidoRepository.VerDetallePedidoParaPagar(request);
            response.Detalles = (await this._pedidoRepository.VerDetallesPago(response.Id)).ToArray();
            return response;
        }
    }
}
