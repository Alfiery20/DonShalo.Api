using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Application.Rol.Query.obtenerMenuRol;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Plato.Query.ObtenerMenuPlato
{
    public class ObtenerMenuPlatoQueryHandler : IRequestHandler<ObtenerMenuPlatoQuery, IEnumerable<ObtenerMenuPlatoQueryDTO>>
    {
        private readonly ILogger<obtenerMenuRolQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPlatoRepository _platoRepository;

        public ObtenerMenuPlatoQueryHandler(
            ILogger<obtenerMenuRolQueryHandler> logger,
            IMapper mapper,
            IPlatoRepository platoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._platoRepository = platoRepository;
        }
        public Task<IEnumerable<ObtenerMenuPlatoQueryDTO>> Handle(ObtenerMenuPlatoQuery request, CancellationToken cancellationToken)
        {
            var response = this._platoRepository.ObtenerMenuPlato(request);
            return response;
        }
    }
}
