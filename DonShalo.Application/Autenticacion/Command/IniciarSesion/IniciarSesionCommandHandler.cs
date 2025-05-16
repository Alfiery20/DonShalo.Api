using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using DonShalo.Application.Autorizacion.Command.ObtenerMenu;
using DonShalo.Application.Common.Interface;
using DonShalo.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DonShalo.Application.Autenticacion.Command.IniciarSesion
{
    public class IniciarSesionCommandHandler : IRequestHandler<IniciarSesionCommand, IniciarSesionCommandDTO>
    {
        private readonly ILogger<IniciarSesionCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAutenticacionRepository _autenticacionRepository;
        private readonly IAutorizacionRepository _autorizacionRepository;
        private readonly IJwtService _jwtService;
        private readonly IDateTimeService _dateTimeService;

        public IniciarSesionCommandHandler(
            ILogger<IniciarSesionCommandHandler> logger,
            IMapper mapper,
            IAutenticacionRepository autenticacionRepository,
            IAutorizacionRepository autorizacionRepository,
            IJwtService jwtService,
            IDateTimeService dateTimeService)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._autenticacionRepository = autenticacionRepository;
            this._autorizacionRepository = autorizacionRepository;
            this._jwtService = jwtService;
            this._dateTimeService = dateTimeService;
        }

        public async Task<IniciarSesionCommandDTO> Handle(IniciarSesionCommand request, CancellationToken cancellationToken)
        {
            var response = await this._autenticacionRepository.IniciarSesion(request);
            var permisos = await this._autorizacionRepository.ObtenerMenu(
                                        new ObtenerMenuCommand
                                        {
                                            IdRol = response.IdRol,
                                            IdUsuario = response.Id
                                        });
            if (response.Id == 0)
            {
                return new IniciarSesionCommandDTO();
            }
            response.Token = GenerateToken(response, permisos.ToList());
            return response;
        }

        private string GenerateToken(IniciarSesionCommandDTO command, List<ObtenerMenuCommandDTO> permisos)
        {
            var claims = new List<Claim>
            {
                new Claim("identifier", command.Id.ToString() ?? ""),
                new Claim("nombres", command.Nombre ?? ""),
                new Claim("apellido_paterno", command.ApellidoPaterno ?? ""),
                new Claim("apellido_materno", command.ApellidoMaterno ?? ""),
                new Claim("nombre_completo", $"{command.Nombre} {command.ApellidoPaterno} {command.ApellidoMaterno}"),
                new Claim("id_rol", command.IdRol.ToString() ?? ""),
                new Claim("rol_nombre", command.NombreRol ?? ""),
                new Claim("permisos", JsonSerializer.Serialize(permisos))
            };

            var token = _jwtService.Generate(claims.ToArray(), this._dateTimeService.HoraLocal());

            return token;
        }
    }
}
