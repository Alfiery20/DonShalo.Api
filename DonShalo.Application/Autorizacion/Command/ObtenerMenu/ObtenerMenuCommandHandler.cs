using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Autorizacion.Command.ObtenerMenu
{
    public class ObtenerMenuCommandHandler : IRequestHandler<ObtenerMenuCommand, IEnumerable<ObtenerMenuCommandDTO>>
    {
        private readonly ILogger<ObtenerMenuCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAutorizacionRepository _autorizacionRepository;

        public ObtenerMenuCommandHandler(
                ILogger<ObtenerMenuCommandHandler> logger,
                IMapper mapper,
                IAutorizacionRepository autorizacionRepository
            )
        {
            this._logger = logger;
            this._mapper = mapper;
            this._autorizacionRepository = autorizacionRepository;
        }
        public async Task<IEnumerable<ObtenerMenuCommandDTO>> Handle(ObtenerMenuCommand request, CancellationToken cancellationToken)
        {
            var response = await this._autorizacionRepository.ObtenerMenu(request);
            this.LlenarArreglo(response.ToList());
            return response.Where(x => x.IdMenuPadre == 0);
        }

        private void LlenarArreglo(List<ObtenerMenuCommandDTO> command)
        {
            foreach (var menu in command)
            {
                var primerosHijos = command.Where(n => n.IdMenuPadre == menu.Id).ToList();
                menu.MenuHijo = primerosHijos;
                this.LlenarArreglo(primerosHijos);
                //ArrayPadre = this.LlenarArreglo(menu.MenuHijo);
            }
        }
    }
}
