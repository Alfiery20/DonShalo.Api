using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Common.Interface;
using DonShalo.Application.Common.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DonShalo.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IDateTimeService _dateTimeService;
        private readonly ILogger<JwtService> _logger;

        public JwtService(
            IOptions<JwtSettings> jwtSettings, 
            IDateTimeService dateTimeService, 
            ILogger<JwtService> logger)
        {
            this._jwtSettings = jwtSettings.Value;
            this._dateTimeService = dateTimeService;
            this._logger = logger;
        }

        public string Generate(Claim[] claims, DateTime? experisUtc = null, string audience = null)
        {
            var symmetricSecurity = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurity, SecurityAlgorithms.HmacSha256Signature);
            this._logger.LogInformation("------------------------------------------------");
            this._logger.LogInformation($"Hora Local: {_dateTimeService.HoraActual()}");
            this._logger.LogInformation($"Hora Local adicional: {_dateTimeService.HoraActual().AddSeconds(_jwtSettings.ExpiresInSeconds)}");
            this._logger.LogInformation("------------------------------------------------");
            var jwtSecurityToken = new JwtSecurityToken(
                        issuer: _jwtSettings.Issuer,
                        audience: audience,
                        claims: claims,
                        expires: _dateTimeService.HoraActual().AddSeconds(_jwtSettings.ExpiresInSeconds),
                        signingCredentials: signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
