using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Application.Rol.Query.obtenerMenuRol;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.MedioPago.Query.ObtenerMedioPago
{
    public class ObtenerMedioPagoQueryHandler : IRequestHandler<ObtenerMedioPagoQuery, IEnumerable<ObtenerMedioPagoQueryDTO>>
    {
        private readonly ILogger<ObtenerMedioPagoQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMedioPagoRepository _medioPagoRepository;

        public ObtenerMedioPagoQueryHandler(
            ILogger<ObtenerMedioPagoQueryHandler> logger,
            IMapper mapper,
            IMedioPagoRepository medioPagoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._medioPagoRepository = medioPagoRepository;
        }
        public Task<IEnumerable<ObtenerMedioPagoQueryDTO>> Handle(ObtenerMedioPagoQuery request, CancellationToken cancellationToken)
        {
            var response = this._medioPagoRepository.ObtenerMedioPagos(request);
            return response;
        }
    }
}
