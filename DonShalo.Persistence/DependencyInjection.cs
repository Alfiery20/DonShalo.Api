using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Common.Interface;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Persistence.Database;
using DonShalo.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DonShalo.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IDataBase>(sp => new SqlDataBase(connectionString));

            services.AddSingleton<IAutenticacionRepository, AutenticacionRepository>();
            services.AddSingleton<IAutorizacionRepository, AutorizacionRepository>();
            services.AddSingleton<IPersonalRepository, PersonalRepository>();
            services.AddSingleton<ISucursalRepository, SucursalRepository>();
            services.AddSingleton<IRolRepository, RolRepository>();

            return services;
        }
    }
}
