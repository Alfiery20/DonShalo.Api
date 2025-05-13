using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Personal.Command.AsignarResponsable
{
    public class AsignarResponsableCommandHandler : IRequestHandler<AsignarResponsableCommand, AsignarResponsableCommandDTO>
    {
        private readonly ILogger<AsignarResponsableCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPersonalRepository _personalRepository;

        public AsignarResponsableCommandHandler(
            ILogger<AsignarResponsableCommandHandler> logger,
            IMapper mapper,
            IPersonalRepository personalRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._personalRepository = personalRepository;
        }
        public Task<AsignarResponsableCommandDTO> Handle(AsignarResponsableCommand request, CancellationToken cancellationToken)
        {
            var response = this._personalRepository.AsignarPersonal(request);
            return response;
        }
    }
}
