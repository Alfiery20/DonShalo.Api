using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Personal.Query.VerPersonal
{
    public class VerPersonalQueryHandler : IRequestHandler<VerPersonalQuery, VerPersonalQueryDTO>
    {
        private readonly ILogger<VerPersonalQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPersonalRepository _personalRepository;

        public VerPersonalQueryHandler(
            ILogger<VerPersonalQueryHandler> logger,
            IMapper mapper,
            IPersonalRepository personalRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._personalRepository = personalRepository;
        }

        public Task<VerPersonalQueryDTO> Handle(VerPersonalQuery request, CancellationToken cancellationToken)
        {
            var response = this._personalRepository.VerSucursales(request);
            return response;
        }
    }
}
