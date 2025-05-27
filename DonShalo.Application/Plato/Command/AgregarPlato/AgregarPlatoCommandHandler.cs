using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Plato.Command.AgregarPlato
{
    public class AgregarPlatoCommandHandler : IRequestHandler<AgregarPlatoCommand, AgregarPlatoCommandDTO>
    {
        private readonly ILogger<AgregarPlatoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPlatoRepository _platoRepository;

        public AgregarPlatoCommandHandler(
            ILogger<AgregarPlatoCommandHandler> logger,
            IMapper mapper,
            IPlatoRepository platoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._platoRepository = platoRepository;
        }
        public Task<AgregarPlatoCommandDTO> Handle(AgregarPlatoCommand request, CancellationToken cancellationToken)
        {
            var response = _platoRepository.RegistrarPlato(request);
            return response;
        }
    }
}
