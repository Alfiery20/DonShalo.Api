using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Rol.Command.EditarRol
{
    public class EditarRolCommandHandler : IRequestHandler<EditarRolCommand, EditarRolCommandDTO>
    {
        private readonly ILogger<EditarRolCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IRolRepository _rolRepository;

        public EditarRolCommandHandler(
            ILogger<EditarRolCommandHandler> logger,
            IMapper mapper,
            IRolRepository rolRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._rolRepository = rolRepository;
        }
        public Task<EditarRolCommandDTO> Handle(EditarRolCommand request, CancellationToken cancellationToken)
        {
            var response = this._rolRepository.EditarRol(request);
            return response;
        }
    }
}
