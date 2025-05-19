using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Mesa.Command.AgregarMesa
{
    public class AgregarMesaCommandHandler : IRequestHandler<AgregarMesaCommand, AgregarMesaCommandDTO>
    {
        private readonly ILogger<AgregarMesaCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMesaRespository _mesaRespository;

        public AgregarMesaCommandHandler(
            ILogger<AgregarMesaCommandHandler> logger,
            IMapper mapper,
            IMesaRespository mesaRespository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._mesaRespository = mesaRespository;
        }
        public Task<AgregarMesaCommandDTO> Handle(AgregarMesaCommand request, CancellationToken cancellationToken)
        {
            var response = this._mesaRespository.RegistrarMesa(request);
            return response;
        }
    }
}
