using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.MedioPago.Query.VerMedioPago
{
    public class VerMedioPagoQueryHandler : IRequestHandler<VerMedioPagoQuery, VerMedioPagoQueryDTO>
    {
        private readonly ILogger<VerMedioPagoQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMedioPagoRepository _medioPagoRepository;

        public VerMedioPagoQueryHandler(
            ILogger<VerMedioPagoQueryHandler> logger,
            IMapper mapper,
            IMedioPagoRepository medioPagoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._medioPagoRepository = medioPagoRepository;
        }
        public Task<VerMedioPagoQueryDTO> Handle(VerMedioPagoQuery request, CancellationToken cancellationToken)
        {
            var response = this._medioPagoRepository.VerMedioPagos(request);
            return response;
        }
    }
}
