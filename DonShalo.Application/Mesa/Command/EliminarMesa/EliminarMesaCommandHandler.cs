using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Application.Rol.Command.EliminarRol;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Mesa.Command.EliminarMesa
{
    public class EliminarMesaCommandHandler : IRequestHandler<EliminarMesaCommand, EliminarMesaCommandDTO>
    {
        private readonly ILogger<EliminarRolCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMesaRespository _mesaRespository;

        public EliminarMesaCommandHandler(
            ILogger<EliminarRolCommandHandler> logger,
            IMapper mapper,
            IMesaRespository mesaRespository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._mesaRespository = mesaRespository;
        }
        public Task<EliminarMesaCommandDTO> Handle(EliminarMesaCommand request, CancellationToken cancellationToken)
        {
            var response = this._mesaRespository.EliminarMesa(request);
            return response;
        }
    }
}
