using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DonShalo.Application.Common.Interface;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Application.Rol.Query.ObtenerRol;
using DonShalo.Application.Sucursal.Query.ObtenerSucursal;
using DonShalo.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;

namespace DonShalo.Persistence.Repository
{
    public class RolRepository : IRolRepository
    {
        private readonly IDataBase _dataBase;

        public RolRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<IEnumerable<ObtenerRolQueryDTO>> ObtenerRol(ObtenerRolQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pTermino", query.Termino, DbType.String, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerRol]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    List<ObtenerRolQueryDTO> response = new();
                    while (reader.Read())
                    {
                        response.Add(new ObtenerRolQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString()
                        });
                    }
                    return response;
                }
            }
        }
    }
}
