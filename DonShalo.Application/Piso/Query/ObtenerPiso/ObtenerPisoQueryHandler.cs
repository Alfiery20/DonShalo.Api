using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Piso.Query.ObtenerPiso
{
    public class ObtenerPisoQueryHandler : IRequestHandler<ObtenerPisoQuery, IEnumerable<ObtenerPisoQueryDTO>>
    {
        private readonly ILogger<ObtenerPisoQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPisoRepository _pisoRepository;

        public ObtenerPisoQueryHandler(
            ILogger<ObtenerPisoQueryHandler> logger,
            IMapper mapper,
            IPisoRepository pisoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._pisoRepository = pisoRepository;
        }
        public Task<IEnumerable<ObtenerPisoQueryDTO>> Handle(ObtenerPisoQuery request, CancellationToken cancellationToken)
        {
            var response = this._pisoRepository.ObtenerPiso(request);
            return response;
        }
    }
}
