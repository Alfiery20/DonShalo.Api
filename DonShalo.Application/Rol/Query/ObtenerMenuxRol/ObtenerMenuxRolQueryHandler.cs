using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Autorizacion.Command.ObtenerMenu;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Rol.Query.ObtenerMenuxRol
{
    public class ObtenerMenuxRolQueryHandler : IRequestHandler<ObtenerMenuxRolQuery, IEnumerable<ObtenerMenuxRolQueryDTO>>
    {
        private readonly ILogger<ObtenerMenuxRolQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IRolRepository _rolRepository;

        public ObtenerMenuxRolQueryHandler(
            ILogger<ObtenerMenuxRolQueryHandler> logger,
            IMapper mapper,
            IRolRepository rolRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._rolRepository = rolRepository;
        }
        public async Task<IEnumerable<ObtenerMenuxRolQueryDTO>> Handle(ObtenerMenuxRolQuery request, CancellationToken cancellationToken)
        {
            var response = await this._rolRepository.ObtenerMenuXRol(request);
            this.LlenarArreglo(response.ToList());
            return response.Where(x => x.Padre == 0);
        }

        private void LlenarArreglo(List<ObtenerMenuxRolQueryDTO> command)
        {
            foreach (var menu in command)
            {
                var primerosHijos = command.Where(n => n.Padre == menu.Id).ToList();
                menu.Hijos = primerosHijos;
                this.LlenarArreglo(primerosHijos);
                //ArrayPadre = this.LlenarArreglo(menu.MenuHijo);
            }
        }
    }
}
