using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Rol.Command.ActualizarPermiso
{
    public class ActualizarPermisoCommandHandler : IRequestHandler<ActualizarPermisoCommand, ActualizarPermisoCommandDTO>
    {
        private readonly ILogger<ActualizarPermisoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IRolRepository _rolRepository;

        public ActualizarPermisoCommandHandler(
            ILogger<ActualizarPermisoCommandHandler> logger,
            IMapper mapper,
            IRolRepository rolRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._rolRepository = rolRepository;
        }
        public Task<ActualizarPermisoCommandDTO> Handle(ActualizarPermisoCommand request, CancellationToken cancellationToken)
        {
            var response = this._rolRepository.ActualizarPermiso(request);
            return response;
        }
    }
}
