using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Sucursal.Command.EditarSucursal
{
    public class EditarSucursalCommandHandler : IRequestHandler<EditarSucursalCommand, EditarSucursalCommandDTO>
    {
        private readonly ILogger<EditarSucursalCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ISucursalRepository _sucursalRepository;

        public EditarSucursalCommandHandler(
            ILogger<EditarSucursalCommandHandler> logger,
            IMapper mapper,
            ISucursalRepository sucursalRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._sucursalRepository = sucursalRepository;
        }
        public Task<EditarSucursalCommandDTO> Handle(EditarSucursalCommand request, CancellationToken cancellationToken)
        {
            var response = this._sucursalRepository.EditarSucursal(request);
            return response;
        }
    }
}
