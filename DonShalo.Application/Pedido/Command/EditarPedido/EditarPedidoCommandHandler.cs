using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Pedido.Command.EditarPedido
{
    public class EditarPedidoCommandHandler : IRequestHandler<EditarPedidoCommand, EditarPedidoCommandDTO>
    {
        private readonly ILogger<EditarPedidoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _pedidoRepository;

        public EditarPedidoCommandHandler(
            ILogger<EditarPedidoCommandHandler> logger,
            IMapper mapper,
            IPedidoRepository pedidoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._pedidoRepository = pedidoRepository;
        }
        public Task<EditarPedidoCommandDTO> Handle(EditarPedidoCommand request, CancellationToken cancellationToken)
        {
            var response = this._pedidoRepository.EditarPedido(request);
            return response;
        }
    }
}
