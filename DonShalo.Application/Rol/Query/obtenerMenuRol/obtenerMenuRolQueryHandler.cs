using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Rol.Query.obtenerMenuRol
{
    public class obtenerMenuRolQueryHandler : IRequestHandler<obtenerMenuRolQuery, IEnumerable<obtenerMenuRolQueryDTO>>
    {
        private readonly ILogger<obtenerMenuRolQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IRolRepository _rolRepository;

        public obtenerMenuRolQueryHandler(
            ILogger<obtenerMenuRolQueryHandler> logger,
            IMapper mapper,
            IRolRepository rolRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._rolRepository = rolRepository;
        }
        public Task<IEnumerable<obtenerMenuRolQueryDTO>> Handle(obtenerMenuRolQuery request, CancellationToken cancellationToken)
        {
            var response = this._rolRepository.ObtenerMenuRol(request);
            return response;
        }
    }
}
