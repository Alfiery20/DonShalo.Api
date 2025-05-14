using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Rol.Query.VerRol
{
    public class VerRolQueryHandler : IRequestHandler<VerRolQuery, VerRolQueryDTO>
    {
        private readonly ILogger<VerRolQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IRolRepository _rolRepository;

        public VerRolQueryHandler(
            ILogger<VerRolQueryHandler> logger,
            IMapper mapper,
            IRolRepository rolRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._rolRepository = rolRepository;
        }
        public Task<VerRolQueryDTO> Handle(VerRolQuery request, CancellationToken cancellationToken)
        {
            var response = this._rolRepository.VerRol(request);
            return response;
        }
    }
}
