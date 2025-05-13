using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Personal.Query.ObtenerPersonal
{
    public class ObtenerPersonalQueryHandler : IRequestHandler<ObtenerPersonalQuery, IEnumerable<ObtenerPersonalQueryDTO>>
    {
        private readonly ILogger<ObtenerPersonalQueryHandler> _logger;
        private readonly IMapper mapper;
        private readonly IPersonalRepository _personalRepository;

        public ObtenerPersonalQueryHandler(
            ILogger<ObtenerPersonalQueryHandler> logger,
            IMapper mapper,
            IPersonalRepository personalRepository)
        {
            this._logger = logger;
            this.mapper = mapper;
            this._personalRepository = personalRepository;
        }
        public Task<IEnumerable<ObtenerPersonalQueryDTO>> Handle(ObtenerPersonalQuery request, CancellationToken cancellationToken)
        {
            var response = this._personalRepository.ObtenerPersonal(request);
            return response;
        }
    }
}
