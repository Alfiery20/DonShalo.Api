using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Piso.Command.EilminarPiso
{
    public class EliminarPisoCommandHandler : IRequestHandler<EliminarPisoCommand, EliminarPisoCommandDTO>
    {
        private readonly ILogger<EliminarPisoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPisoRepository _pisoRepository;

        public EliminarPisoCommandHandler(
            ILogger<EliminarPisoCommandHandler> logger,
            IMapper mapper,
            IPisoRepository pisoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._pisoRepository = pisoRepository;
        }
        public Task<EliminarPisoCommandDTO> Handle(EliminarPisoCommand request, CancellationToken cancellationToken)
        {
            var response = this._pisoRepository.EliminarPiso(request);
            return response;
        }
    }
}
