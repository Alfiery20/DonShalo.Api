using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Autenticacion.Command.RegistrarUsuario
{
    public class RegistrarUsuarioCommandHandler : IRequestHandler<RegistrarUsuarioCommand, RegistrarUsuarioCommandDTO>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<RegistrarUsuarioCommandHandler> _logger;
        private readonly IAutenticacionRepository _autenticacionRepository;

        public RegistrarUsuarioCommandHandler(
            IMapper mapper,
            ILogger<RegistrarUsuarioCommandHandler> logger,
            IAutenticacionRepository autenticacionRepository)
        {
            this._mapper = mapper;
            this._logger = logger;
            this._autenticacionRepository = autenticacionRepository;
        }
        public Task<RegistrarUsuarioCommandDTO> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var response = this._autenticacionRepository.RegistrarPersonal(request);
            return response;
        }
    }
}
