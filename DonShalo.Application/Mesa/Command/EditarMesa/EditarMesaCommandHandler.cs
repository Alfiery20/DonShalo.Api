using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Mesa.Command.EditarMesa
{
    public class EditarMesaCommandHandler : IRequestHandler<EditarMesaCommand, EditarMesaCommandDTO>
    {
        private readonly ILogger<EditarMesaCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMesaRespository _mesaRespository;

        public EditarMesaCommandHandler(
            ILogger<EditarMesaCommandHandler> logger,
            IMapper mapper,
            IMesaRespository mesaRespository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._mesaRespository = mesaRespository;
        }
        public Task<EditarMesaCommandDTO> Handle(EditarMesaCommand request, CancellationToken cancellationToken)
        {
            var response = this._mesaRespository.EditarMesa(request);
            return response;
        }
    }
}
