using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Application.Rol.Query.obtenerMenuRol;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Categoria.Query.ObtenerCategoria
{
    public class ObtenerCategoriaQueryHandler : IRequestHandler<ObtenerCategoriaQuery, IEnumerable<ObtenerCategoriaQueryDTO>>
    {
        private readonly ILogger<ObtenerCategoriaQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _categoriaRepository;

        public ObtenerCategoriaQueryHandler(
            ILogger<ObtenerCategoriaQueryHandler> logger,
            IMapper mapper,
            ICategoriaRepository categoriaRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._categoriaRepository = categoriaRepository;
        }
        public Task<IEnumerable<ObtenerCategoriaQueryDTO>> Handle(ObtenerCategoriaQuery request, CancellationToken cancellationToken)
        {
            var response = this._categoriaRepository.ObtenerCategoria(request);
            return response;
        }
    }
}
