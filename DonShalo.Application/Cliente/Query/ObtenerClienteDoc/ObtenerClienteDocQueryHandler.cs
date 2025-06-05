using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Cliente.Query.ObtenerClienteDoc
{
    public class ObtenerClienteDocQueryHandler : IRequestHandler<ObtenerClienteDocQuery, ObtenerClienteDocQueryDTO>
    {
        private readonly ILogger<ObtenerClienteDocQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public ObtenerClienteDocQueryHandler(
            ILogger<ObtenerClienteDocQueryHandler> logger,
            IMapper mapper,
            IClienteRepository clienteRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._clienteRepository = clienteRepository;
        }
        public Task<ObtenerClienteDocQueryDTO> Handle(ObtenerClienteDocQuery request, CancellationToken cancellationToken)
        {
            var response = this._clienteRepository.ObtenerClientePorDoc(request);
            return response;
        }
    }
}
