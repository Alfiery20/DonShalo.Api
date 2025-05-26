using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Categoria.Command.AgregarCategoria
{
    public class AgregarCategoriaCommandHandler : IRequestHandler<AgregarCategoriaCommand, AgregarCategoriaCommandDTO>
    {
        private readonly ILogger<AgregarCategoriaCommand> _logger;
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _categoriaRepository;

        public AgregarCategoriaCommandHandler(
            ILogger<AgregarCategoriaCommand> logger,
            IMapper mapper,
            ICategoriaRepository categoriaRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._categoriaRepository = categoriaRepository;
        }
        public Task<AgregarCategoriaCommandDTO> Handle(AgregarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var response = this._categoriaRepository.RegistrarCategoria(request);
            return response;
        }
    }
}
