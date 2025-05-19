using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Piso.Query.VerPiso
{
    public class VerPisoQueryHandler : IRequestHandler<VerPisoQuery, VerPisoQueryDTO>
    {
        private readonly ILogger<VerPisoQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPisoRepository _pisoRepository;

        public VerPisoQueryHandler(
            ILogger<VerPisoQueryHandler> logger,
            IMapper mapper,
            IPisoRepository pisoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._pisoRepository = pisoRepository;
        }
        public Task<VerPisoQueryDTO> Handle(VerPisoQuery request, CancellationToken cancellationToken)
        {
            var response = this._pisoRepository.VerPiso(request);
            return response;
        }
    }
}
