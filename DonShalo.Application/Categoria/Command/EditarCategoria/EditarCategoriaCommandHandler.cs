using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Categoria.Command.EditarCategoria
{
    public class EditarCategoriaCommandHandler : IRequestHandler<EditarCategoriaCommand, EditarCategoriaCommandDTO>
    {
        private readonly ILogger<EditarCategoriaCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _categoriaRepository;

        public EditarCategoriaCommandHandler(
            ILogger<EditarCategoriaCommandHandler> logger,
            IMapper mapper,
            ICategoriaRepository categoriaRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._categoriaRepository = categoriaRepository;
        }
        public Task<EditarCategoriaCommandDTO> Handle(EditarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var response = this._categoriaRepository.EditarCategoria(request);
            return response;
        }
    }
}
