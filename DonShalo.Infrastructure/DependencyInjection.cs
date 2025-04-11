using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Common.Interface;
using DonShalo.Infrastructure.Crytography;
using DonShalo.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DonShalo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeService, DateTimeService>();
            services.AddSingleton<ICryptography, Cryptography>();
            services.AddSingleton<IJwtService, JwtService>();
            return services;
        }

    }
}
