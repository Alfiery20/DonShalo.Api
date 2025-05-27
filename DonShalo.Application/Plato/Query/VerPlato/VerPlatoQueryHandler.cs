using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Plato.Query.VerPlato
{
    public class VerPlatoQueryHandler : IRequestHandler<VerPlatoQuery, VerPlatoQueryDTO>
    {
        private readonly ILogger<VerPlatoQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPlatoRepository _platoRepository;

        public VerPlatoQueryHandler(
            ILogger<VerPlatoQueryHandler> logger,
            IMapper mapper,
            IPlatoRepository platoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._platoRepository = platoRepository;
        }
        public Task<VerPlatoQueryDTO> Handle(VerPlatoQuery request, CancellationToken cancellationToken)
        {
            var response = this._platoRepository.VerPlato(request);
            return response;
        }
    }
}
