using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Sucursal.Query.ObtenerSucursal
{
    public class ObtenerSucursalQueryHandler : IRequestHandler<ObtenerSucursalQuery, IEnumerable<ObtenerSucursalQueryDTO>>
    {
        private readonly ILogger<ObtenerSucursalQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ISucursalRepository _sucursalRepository;

        public ObtenerSucursalQueryHandler(
            ILogger<ObtenerSucursalQueryHandler> logger,
            IMapper mapper,
            ISucursalRepository sucursalRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._sucursalRepository = sucursalRepository;
        }
        public Task<IEnumerable<ObtenerSucursalQueryDTO>> Handle(ObtenerSucursalQuery request, CancellationToken cancellationToken)
        {
            var response = this._sucursalRepository.ObtenerSucursales(request);
            return response;
        }
    }
}
