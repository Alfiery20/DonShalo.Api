using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Sucursal.Command.AgregarSucursal
{
    public class AgregarSucursalCommandHandler : IRequestHandler<AgregarSucursalCommand, AgregarSucursalCommandDTO>
    {
        private readonly ILogger<AgregarSucursalCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ISucursalRepository _sucursalRepository;

        public AgregarSucursalCommandHandler(
            ILogger<AgregarSucursalCommandHandler> logger,
            IMapper mapper,
            ISucursalRepository sucursalRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._sucursalRepository = sucursalRepository;
        }
        public Task<AgregarSucursalCommandDTO> Handle(AgregarSucursalCommand request, CancellationToken cancellationToken)
        {
            var response = _sucursalRepository.RegistrarSucursal(request);
            return response;
        }
    }
}
