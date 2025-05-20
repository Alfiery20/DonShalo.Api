using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.MedioPago.Command.AgregarMedioPago
{
    public class AgregarMedioPagoCommandHandler : IRequestHandler<AgregarMedioPagoCommand, AgregarMedioPagoCommandDTO>
    {
        private readonly ILogger<AgregarMedioPagoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMedioPagoRepository _medioPagoRepository;

        public AgregarMedioPagoCommandHandler(
            ILogger<AgregarMedioPagoCommandHandler> logger,
            IMapper mapper,
            IMedioPagoRepository medioPagoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._medioPagoRepository = medioPagoRepository;
        }
        public Task<AgregarMedioPagoCommandDTO> Handle(AgregarMedioPagoCommand request, CancellationToken cancellationToken)
        {
            var response = this._medioPagoRepository.RegistrarMedioPago(request);
            return response;
        }
    }
}
