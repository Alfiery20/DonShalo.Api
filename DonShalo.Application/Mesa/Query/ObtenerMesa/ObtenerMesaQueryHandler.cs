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

namespace DonShalo.Application.Mesa.Query.ObtenerMesa
{
    public class ObtenerMesaQueryHandler : IRequestHandler<ObtenerMesaQuery, IEnumerable<ObtenerMesaQueryDTO>>
    {
        private readonly ILogger<ObtenerMesaQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMesaRespository _mesaRespository;

        public ObtenerMesaQueryHandler(
            ILogger<ObtenerMesaQueryHandler> logger,
            IMapper mapper,
            IMesaRespository mesaRespository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._mesaRespository = mesaRespository;
        }
        public Task<IEnumerable<ObtenerMesaQueryDTO>> Handle(ObtenerMesaQuery request, CancellationToken cancellationToken)
        {
            var response = this._mesaRespository.ObtenerMesa(request);
            return response;
        }
    }
}
