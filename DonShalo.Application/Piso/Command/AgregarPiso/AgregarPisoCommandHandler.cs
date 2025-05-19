using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Piso.Command.AgregarPiso
{
    public class AgregarPisoCommandHandler : IRequestHandler<AgregarPisoCommand, AgregarPisoCommandDTO>
    {
        private readonly ILogger<AgregarPisoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPisoRepository _pisoRepository;

        public AgregarPisoCommandHandler(
            ILogger<AgregarPisoCommandHandler> logger,
            IMapper mapper,
            IPisoRepository pisoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._pisoRepository = pisoRepository;
        }
        public Task<AgregarPisoCommandDTO> Handle(AgregarPisoCommand request, CancellationToken cancellationToken)
        {
            var response = this._pisoRepository.RegistrarPiso(request);
            return response;
        }
    }
}
