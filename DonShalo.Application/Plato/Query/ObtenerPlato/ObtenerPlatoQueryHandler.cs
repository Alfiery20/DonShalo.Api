using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Plato.Query.ObtenerPlato
{
    public class ObtenerPlatoQueryHandler : IRequestHandler<ObtenerPlatoQuery, IEnumerable<ObtenerPlatoQueryDTO>>
    {
        private readonly ILogger<ObtenerPlatoQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPlatoRepository _platoRepository;

        public ObtenerPlatoQueryHandler(
            ILogger<ObtenerPlatoQueryHandler> logger,
            IMapper mapper,
            IPlatoRepository platoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._platoRepository = platoRepository;
        }
        public Task<IEnumerable<ObtenerPlatoQueryDTO>> Handle(ObtenerPlatoQuery request, CancellationToken cancellationToken)
        {
            var response = this._platoRepository.ObtenerPlato(request);
            return response;
        }
    }
}
