using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Sucursal.Query.ObtenerMenuSucursal
{
    public class ObtenerMenuSucursalQueryHandler : IRequestHandler<ObtenerMenuSucursalQuery, IEnumerable<ObtenerMenuSucursalQueryDTO>>
    {
        private readonly ILogger<ObtenerMenuSucursalQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ISucursalRepository _sucursalRepository;

        public ObtenerMenuSucursalQueryHandler(
            ILogger<ObtenerMenuSucursalQueryHandler> logger,
            IMapper mapper,
            ISucursalRepository sucursalRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._sucursalRepository = sucursalRepository;
        }
        public Task<IEnumerable<ObtenerMenuSucursalQueryDTO>> Handle(ObtenerMenuSucursalQuery request, CancellationToken cancellationToken)
        {
            var response = this._sucursalRepository.ObtenerMenuSucursal(request);
            return response;
        }
    }
}
