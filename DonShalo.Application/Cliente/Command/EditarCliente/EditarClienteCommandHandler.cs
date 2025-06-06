using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Cliente.Command.EditarCliente
{
    public class EditarClienteCommandHandler : IRequestHandler<EditarClienteCommand, EditarClienteCommandDTO>
    {
        private readonly ILogger<EditarClienteCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public EditarClienteCommandHandler(
            ILogger<EditarClienteCommandHandler> logger,
            IMapper mapper,
            IClienteRepository clienteRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._clienteRepository = clienteRepository;
        }
        public Task<EditarClienteCommandDTO> Handle(EditarClienteCommand request, CancellationToken cancellationToken)
        {
            var response = this._clienteRepository.EditarCliente(request);
            return response;
        }
    }
}
