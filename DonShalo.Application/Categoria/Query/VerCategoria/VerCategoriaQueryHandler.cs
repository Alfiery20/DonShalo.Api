using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Categoria.Query.VerCategoria
{
    public class VerCategoriaQueryHandler : IRequestHandler<VerCategoriaQuery, VerCategoriaQueryDTO>
    {
        private readonly ILogger<VerCategoriaQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _categoriaRepository;

        public VerCategoriaQueryHandler(
            ILogger<VerCategoriaQueryHandler> logger,
            IMapper mapper,
            ICategoriaRepository categoriaRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._categoriaRepository = categoriaRepository;
        }
        public Task<VerCategoriaQueryDTO> Handle(VerCategoriaQuery request, CancellationToken cancellationToken)
        {
            var response = this._categoriaRepository.VerCategoria(request);
            return response;
        }
    }
}
