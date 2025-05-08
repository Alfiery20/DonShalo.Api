using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Personal.Command.EliminarPersonal
{
    public class EliminarPersonalCommandHandler : IRequestHandler<EliminarPersonalCommand, EliminarPersonalCommandDTO>
    {
        private readonly ILogger<EliminarPersonalCommand> _logger;
        private readonly IMapper _mapper;
        private readonly IPersonalRepository _personalRepository;

        public EliminarPersonalCommandHandler(
            ILogger<EliminarPersonalCommand> logger,
            IMapper mapper,
            IPersonalRepository personalRepository
            )
        {
            this._logger = logger;
            this._mapper = mapper;
            this._personalRepository = personalRepository;
        }
        public Task<EliminarPersonalCommandDTO> Handle(EliminarPersonalCommand request, CancellationToken cancellationToken)
        {
            var response = this._personalRepository.EliminarPersonal(request);
            return response;
        }
    }
}
