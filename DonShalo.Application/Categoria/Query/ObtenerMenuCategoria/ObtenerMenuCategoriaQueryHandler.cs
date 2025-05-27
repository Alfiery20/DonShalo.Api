using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Categoria.Query.ObtenerMenuCategoria
{
    public class ObtenerMenuCategoriaQueryHandler : IRequestHandler<ObtenerMenuCategoriaQuery, IEnumerable<ObtenerMenuCategoriaQueryDTO>>
    {
        private readonly ILogger<ObtenerMenuCategoriaQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _categoriaRepository;

        public ObtenerMenuCategoriaQueryHandler(
            ILogger<ObtenerMenuCategoriaQueryHandler> logger,
            IMapper mapper,
            ICategoriaRepository categoriaRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._categoriaRepository = categoriaRepository;
        }
        public Task<IEnumerable<ObtenerMenuCategoriaQueryDTO>> Handle(ObtenerMenuCategoriaQuery request, CancellationToken cancellationToken)
        {
            var response = this._categoriaRepository.ObtenerMenuCategoria(request);
            return response;
        }
    }
}
