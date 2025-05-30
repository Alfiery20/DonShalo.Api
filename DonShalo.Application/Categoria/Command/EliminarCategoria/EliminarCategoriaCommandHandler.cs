﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Categoria.Command.EliminarCategoria
{
    public class EliminarCategoriaCommandHandler : IRequestHandler<EliminarCategoriaCommand, EliminarCategoriaCommandDTO>
    {
        private readonly ILogger<EliminarCategoriaCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _categoriaRepository;

        public EliminarCategoriaCommandHandler(
            ILogger<EliminarCategoriaCommandHandler> logger,
            IMapper mapper,
            ICategoriaRepository categoriaRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._categoriaRepository = categoriaRepository;
        }
        public Task<EliminarCategoriaCommandDTO> Handle(EliminarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var response = this._categoriaRepository.EliminarCategoria(request);
            return response;
        }
    }
}
