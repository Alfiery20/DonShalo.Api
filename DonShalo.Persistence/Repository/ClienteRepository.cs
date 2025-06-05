using System.Data;
using Dapper;
using DonShalo.Application.Cliente.Query.ObtenerClienteDoc;
using DonShalo.Application.Common.Interface;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Application.MedioPago.Query.ObtenerMedioPago;
using DonShalo.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;

namespace DonShalo.Persistence.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDataBase _dataBase;

        public ClienteRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }
        public async Task<ObtenerClienteDocQueryDTO> ObtenerClientePorDoc(ObtenerClienteDocQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pNumeroDocumento", query.NumeroDocumento, DbType.String, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerCliente]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    ObtenerClienteDocQueryDTO response = new();
                    while (reader.Read())
                    {
                        response = new ObtenerClienteDocQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString()
                        };
                    }
                    return response;
                }
            }
        }
    }
}
