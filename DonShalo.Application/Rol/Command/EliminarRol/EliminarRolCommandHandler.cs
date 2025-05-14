using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Rol.Command.EliminarRol
{
    public class EliminarRolCommandHandler : IRequestHandler<EliminarRolCommand, EliminarRolCommandDTO>
    {
        private readonly ILogger<EliminarRolCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IRolRepository _rolRepository;

        public EliminarRolCommandHandler(
            ILogger<EliminarRolCommandHandler> logger,
            IMapper mapper,
            IRolRepository rolRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._rolRepository = rolRepository;
        }
        public Task<EliminarRolCommandDTO> Handle(EliminarRolCommand request, CancellationToken cancellationToken)
        {
            var response = this._rolRepository.EliminarRol(request);
            return response;
        }
    }
}
