using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Pedido.Command.AgregarPedido
{
    public class AgregarPedidoCommandHandler : IRequestHandler<AgregarPedidoCommand, AgregarPedidoCommandDTO>
    {
        private readonly ILogger<AgregarPedidoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _pedidoRepository;

        public AgregarPedidoCommandHandler(
            ILogger<AgregarPedidoCommandHandler> logger,
            IMapper mapper,
            IPedidoRepository pedidoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._pedidoRepository = pedidoRepository;
        }
        public Task<AgregarPedidoCommandDTO> Handle(AgregarPedidoCommand request, CancellationToken cancellationToken)
        {
            var response = this._pedidoRepository.RegistrarPedido(request);
            return response;
        }
    }
}
