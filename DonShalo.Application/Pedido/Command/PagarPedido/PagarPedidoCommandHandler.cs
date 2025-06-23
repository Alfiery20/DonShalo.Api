using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Pedido.Command.PagarPedido
{
    public class PagarPedidoCommandHandler : IRequestHandler<PagarPedidoCommand, PagarPedidoCommandDTO>
    {
        private readonly ILogger<PagarPedidoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _pedidoRepository;

        public PagarPedidoCommandHandler(
            ILogger<PagarPedidoCommandHandler> logger,
            IMapper mapper,
            IPedidoRepository pedidoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._pedidoRepository = pedidoRepository;
        }
        public Task<PagarPedidoCommandDTO> Handle(PagarPedidoCommand request, CancellationToken cancellationToken)
        {
            var response = this._pedidoRepository.PagarPedido(request);
            return response;
        }
    }
}
