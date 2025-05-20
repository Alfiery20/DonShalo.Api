using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.MedioPago.Command.EliminarMedioPago
{
    public class EliminarMedioPagoCommandHandler : IRequestHandler<EliminarMedioPagoCommand, EliminarMedioPagoCommandDTO>
    {
        private readonly ILogger<EliminarMedioPagoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMedioPagoRepository _medioPagoRepository;

        public EliminarMedioPagoCommandHandler(
            ILogger<EliminarMedioPagoCommandHandler> logger,
            IMapper mapper,
            IMedioPagoRepository medioPagoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._medioPagoRepository = medioPagoRepository;
        }
        public Task<EliminarMedioPagoCommandDTO> Handle(EliminarMedioPagoCommand request, CancellationToken cancellationToken)
        {
            var response = this._medioPagoRepository.EliminarMedioPago(request);
            return response;
        }
    }
}
