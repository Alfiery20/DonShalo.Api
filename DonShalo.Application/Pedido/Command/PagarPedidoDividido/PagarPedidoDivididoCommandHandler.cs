using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Pedido.Command.PagarPedidoDividido
{
    public class PagarPedidoDivididoCommandHandler : IRequestHandler<PagarPedidoDivididoCommand, PagarPedidoDivididoCommandDTO>
    {
        private readonly ILogger<PagarPedidoDivididoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _pedidoRepository;

        public PagarPedidoDivididoCommandHandler(
            ILogger<PagarPedidoDivididoCommandHandler> logger,
            IMapper mapper,
            IPedidoRepository pedidoRepository
            )
        {
            this._logger = logger;
            this._mapper = mapper;
            this._pedidoRepository = pedidoRepository;
        }
        public Task<PagarPedidoDivididoCommandDTO> Handle(PagarPedidoDivididoCommand request, CancellationToken cancellationToken)
        {
            var response = this._pedidoRepository.PagarPedidoDividido(request);
            return response;
        }
    }
}
