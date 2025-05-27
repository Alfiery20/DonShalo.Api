using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Plato.Command.EditarPlato
{
    public class EditarPlatoCommandHandler : IRequestHandler<EditarPlatoCommand, EditarPlatoCommandDTO>
    {
        private readonly ILogger<EditarPlatoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPlatoRepository _platoRepository;

        public EditarPlatoCommandHandler(
            ILogger<EditarPlatoCommandHandler> logger,
            IMapper mapper,
            IPlatoRepository platoRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._platoRepository = platoRepository;
        }
        public Task<EditarPlatoCommandDTO> Handle(EditarPlatoCommand request, CancellationToken cancellationToken)
        {
            var response = this._platoRepository.EditarPlato(request);
            return response;
        }
    }
}
