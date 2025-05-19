using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Piso.Command.EditarPiso
{
    public class EditarPisoCommandHandler : IRequestHandler<EditarPisoCommand, EditarPisoCommandDTO>
    {
        private readonly ILogger<EditarPisoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPisoRepository _pisoRepository;

        public EditarPisoCommandHandler(
            ILogger<EditarPisoCommandHandler> logger,
            IMapper mapper,
            IPisoRepository pisoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._pisoRepository = pisoRepository;
        }
        public Task<EditarPisoCommandDTO> Handle(EditarPisoCommand request, CancellationToken cancellationToken)
        {
            var response = this._pisoRepository.EditarPiso(request);
            return response;
        }
    }
}
