using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Personal.Command.RegistrarUsuario
{
    public class RegistrarUsuarioCommandHandler : IRequestHandler<RegistrarUsuarioCommand, RegistrarUsuarioCommandDTO>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<RegistrarUsuarioCommandHandler> _logger;
        private readonly IPersonalRepository _personalRepository;

        public RegistrarUsuarioCommandHandler(
            IMapper mapper,
            ILogger<RegistrarUsuarioCommandHandler> logger,
            IPersonalRepository personalRepository
            )
        {
            _mapper = mapper;
            _logger = logger;
            this._personalRepository = personalRepository;
        }
        public Task<RegistrarUsuarioCommandDTO> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var response = this._personalRepository.RegistrarPersonal(request);
            return response;
        }
    }
}
