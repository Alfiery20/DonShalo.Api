using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Rol.Query.ObtenerRol
{
    public class ObtenerRolQueryHandler : IRequestHandler<ObtenerRolQuery, IEnumerable<ObtenerRolQueryDTO>>
    {
        private readonly ILogger<ObtenerRolQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IRolRepository _rolRepository;

        public ObtenerRolQueryHandler(
            ILogger<ObtenerRolQueryHandler> logger,
            IMapper mapper,
            IRolRepository rolRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._rolRepository = rolRepository;
        }
        public Task<IEnumerable<ObtenerRolQueryDTO>> Handle(ObtenerRolQuery request, CancellationToken cancellationToken)
        {
            var response = this._rolRepository.ObtenerRol(request);
            return response;
        }
    }
}
