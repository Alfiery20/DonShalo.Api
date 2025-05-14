using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Rol.Command.RegistrarRol
{
    public class RegistrarRolCommandHandler : IRequestHandler<RegistrarRolCommand, RegistrarRolCommandDTO>
    {
        private readonly ILogger<RegistrarRolCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IRolRepository _rolRepository;

        public RegistrarRolCommandHandler(
            ILogger<RegistrarRolCommandHandler> logger,
            IMapper mapper,
            IRolRepository rolRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._rolRepository = rolRepository;
        }
        public Task<RegistrarRolCommandDTO> Handle(RegistrarRolCommand request, CancellationToken cancellationToken)
        {
            var response = this._rolRepository.RegistrarRol(request);
            return response;
        }
    }
}
