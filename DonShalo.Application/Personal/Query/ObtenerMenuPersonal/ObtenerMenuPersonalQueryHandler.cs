using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Personal.Query.ObtenerMenuPersonal
{
    public class ObtenerMenuPersonalQueryHandler : IRequestHandler<ObtenerMenuPersonalQuery, IEnumerable<ObtenerMenuPersonalQueryDTO>>
    {
        private readonly ILogger<ObtenerMenuPersonalQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPersonalRepository _personalRepository;

        public ObtenerMenuPersonalQueryHandler(
            ILogger<ObtenerMenuPersonalQueryHandler> logger,
            IMapper mapper,
            IPersonalRepository personalRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._personalRepository = personalRepository;
        }
        public Task<IEnumerable<ObtenerMenuPersonalQueryDTO>> Handle(ObtenerMenuPersonalQuery request, CancellationToken cancellationToken)
        {
            var response = this._personalRepository.ObtenerMenuPersonal(request);
            return response;
        }
    }
}
