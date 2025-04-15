using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Sucursal.Query.VerSucursal
{
    public class VerSucursalQueryHandler : IRequestHandler<VerSucursalQuery, VerSucursalQueryDTO>
    {
        private readonly ILogger<VerSucursalQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ISucursalRepository _sucursalRepository;

        public VerSucursalQueryHandler(
            ILogger<VerSucursalQueryHandler> logger,
            IMapper mapper,
            ISucursalRepository sucursalRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._sucursalRepository = sucursalRepository;
        }
        public Task<VerSucursalQueryDTO> Handle(VerSucursalQuery request, CancellationToken cancellationToken)
        {
            var response = this._sucursalRepository.VerSucursales(request);
            return response;
        }
    }
}
