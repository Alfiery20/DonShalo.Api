using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.MedioPago.Command.EditarMedioPago
{
    public class EditarMedioPagoCommandHandler : IRequestHandler<EditarMedioPagoCommand, EditarMedioPagoCommandDTO>
    {
        private readonly ILogger<EditarMedioPagoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMedioPagoRepository _medioPagoRepository;

        public EditarMedioPagoCommandHandler(
            ILogger<EditarMedioPagoCommandHandler> logger,
            IMapper mapper,
            IMedioPagoRepository medioPagoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._medioPagoRepository = medioPagoRepository;
        }
        public Task<EditarMedioPagoCommandDTO> Handle(EditarMedioPagoCommand request, CancellationToken cancellationToken)
        {
            var response = this._medioPagoRepository.EditarMedioPago(request);
            return response;
        }
    }
}
