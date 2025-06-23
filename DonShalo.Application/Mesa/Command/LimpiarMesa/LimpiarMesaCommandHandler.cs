using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Mesa.Command.LimpiarMesa
{
    public class LimpiarMesaCommandHandler : IRequestHandler<LimpiarMesaCommand, LimpiarMesaCommandDTO>
    {
        private readonly ILogger<LimpiarMesaCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMesaRespository _mesaRespository;

        public LimpiarMesaCommandHandler(
            ILogger<LimpiarMesaCommandHandler> logger,
            IMapper mapper,
            IMesaRespository mesaRespository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._mesaRespository = mesaRespository;
        }
        public Task<LimpiarMesaCommandDTO> Handle(LimpiarMesaCommand request, CancellationToken cancellationToken)
        {
            var response = this._mesaRespository.LimpiarMesa(request);
            return response;
        }
    }
}
