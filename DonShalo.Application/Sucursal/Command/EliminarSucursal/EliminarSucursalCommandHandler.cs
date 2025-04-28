using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Sucursal.Command.EliminarSucursal
{
    public class EliminarSucursalCommandHandler : IRequestHandler<EliminarSucursalCommand, EliminarSucursalCommandDTO>
    {
        private readonly ILogger<EliminarSucursalCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ISucursalRepository _sucursalRepository;

        public EliminarSucursalCommandHandler(
            ILogger<EliminarSucursalCommandHandler> logger,
            IMapper mapper,
            ISucursalRepository sucursalRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._sucursalRepository = sucursalRepository;
        }
        public Task<EliminarSucursalCommandDTO> Handle(EliminarSucursalCommand request, CancellationToken cancellationToken)
        {
            var response = this._sucursalRepository.EliminarSucursal(request);
            return response;
        }
    }
}
