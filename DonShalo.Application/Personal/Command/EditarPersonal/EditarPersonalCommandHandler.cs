using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Personal.Command.EditarPersonal
{
    public class EditarPersonalCommandHandler : IRequestHandler<EditarPersonalCommand, EditarPersonalCommandDTO>
    {
        private readonly ILogger<EditarPersonalCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPersonalRepository _personalRepository;

        public EditarPersonalCommandHandler(
            ILogger<EditarPersonalCommandHandler> logger,
            IMapper mapper,
            IPersonalRepository personalRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._personalRepository = personalRepository;
        }
        public Task<EditarPersonalCommandDTO> Handle(EditarPersonalCommand request, CancellationToken cancellationToken)
        {
            var response = this._personalRepository.EditarPersonal(request);
            return response;
        }
    }
}
