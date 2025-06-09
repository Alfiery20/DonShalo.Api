using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Pedido.Command.EliminarPedido
{
    public class EliminarPedidoCommandHandler : IRequestHandler<EliminarPedidoCommand, EliminarPedidoCommandDTO>
    {
        private readonly ILogger<EliminarPedidoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _pedidoRepository;

        public EliminarPedidoCommandHandler(
            ILogger<EliminarPedidoCommandHandler> logger,
            IMapper mapper,
            IPedidoRepository pedidoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._pedidoRepository = pedidoRepository;
        }
        public Task<EliminarPedidoCommandDTO> Handle(EliminarPedidoCommand request, CancellationToken cancellationToken)
        {
            var response = this._pedidoRepository.EliminarPedido(request);
            return response;
        }
    }
}
