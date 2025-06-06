using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Cliente.Command.AgregarCliente
{
    public class AgregarClienteCommandHandler : IRequestHandler<AgregarClienteCommand, AgregarClienteCommandDTO>
    {
        private readonly ILogger<AgregarClienteCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public AgregarClienteCommandHandler(
            ILogger<AgregarClienteCommandHandler> logger,
            IMapper mapper,
            IClienteRepository clienteRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._clienteRepository = clienteRepository;
        }
        public Task<AgregarClienteCommandDTO> Handle(AgregarClienteCommand request, CancellationToken cancellationToken)
        {
            var response = this._clienteRepository.RegistrarCliente(request);
            return response;
        }
    }
}
