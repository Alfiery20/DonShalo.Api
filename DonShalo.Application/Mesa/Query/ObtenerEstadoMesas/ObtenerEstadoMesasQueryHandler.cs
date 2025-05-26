using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Application.Rol.Query.obtenerMenuRol;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Mesa.Query.ObtenerEstadoMesas
{
    public class ObtenerEstadoMesasQueryHandler : IRequestHandler<ObtenerEstadoMesasQuery, IEnumerable<ObtenerEstadoMesasQueryDTO>>
    {
        private readonly ILogger<obtenerMenuRolQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMesaRespository _mesaRespository;

        public ObtenerEstadoMesasQueryHandler(
            ILogger<obtenerMenuRolQueryHandler> logger,
            IMapper mapper,
            IMesaRespository mesaRespository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._mesaRespository = mesaRespository;
        }
        public Task<IEnumerable<ObtenerEstadoMesasQueryDTO>> Handle(ObtenerEstadoMesasQuery request, CancellationToken cancellationToken)
        {
            var response = this._mesaRespository.ObtenerEstadoMesas(request);
            return response;
        }
    }
}
