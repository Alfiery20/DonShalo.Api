using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Mesa.Query.VerMesa
{
    public class VerMesaQueryHandler : IRequestHandler<VerMesaQuery, VerMesaQueryDTO>
    {
        private readonly ILogger<VerMesaQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMesaRespository _mesaRespository;

        public VerMesaQueryHandler(
            ILogger<VerMesaQueryHandler> logger,
            IMapper mapper,
            IMesaRespository mesaRespository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._mesaRespository = mesaRespository;
        }
        public Task<VerMesaQueryDTO> Handle(VerMesaQuery request, CancellationToken cancellationToken)
        {
            var response = this._mesaRespository.VerMesa(request);
            return response;
        }
    }
}
