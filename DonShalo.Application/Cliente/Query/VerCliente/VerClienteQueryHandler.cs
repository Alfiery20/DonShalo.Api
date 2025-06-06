using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Cliente.Query.VerCliente
{
    public class VerClienteQueryHandler : IRequestHandler<VerClienteQuery, VerClienteQueryDTO>
    {
        private readonly ILogger<VerClienteQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public VerClienteQueryHandler(
            ILogger<VerClienteQueryHandler> logger,
            IMapper mapper,
            IClienteRepository clienteRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._clienteRepository = clienteRepository;
        }
        public Task<VerClienteQueryDTO> Handle(VerClienteQuery request, CancellationToken cancellationToken)
        {
            var response = this._clienteRepository.VerCliente(request);
            return response;
        }
    }
}
