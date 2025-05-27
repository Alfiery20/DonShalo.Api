using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Plato.Command.EliminarPlato
{
    public class EliminarPlatoCommandHandler : IRequestHandler<EliminarPlatoCommand, EliminarPlatoCommandDTO>
    {
        private readonly ILogger<EliminarPlatoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPlatoRepository _platoRepository;

        public EliminarPlatoCommandHandler(
            ILogger<EliminarPlatoCommandHandler> logger,
            IMapper mapper,
            IPlatoRepository platoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._platoRepository = platoRepository;
        }
        public Task<EliminarPlatoCommandDTO> Handle(EliminarPlatoCommand request, CancellationToken cancellationToken)
        {
            var response = this._platoRepository.EliminarPlato(request);
            return response;
        }
    }
}
