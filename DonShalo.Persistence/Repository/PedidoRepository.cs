using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DonShalo.Application.Common.Interface;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Application.Mesa.Query.VerMesa;
using DonShalo.Application.Pedido.Query.ObtenerPedidoMesa;
using DonShalo.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;

namespace DonShalo.Persistence.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IDataBase _dataBase;

        public PedidoRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }
        public async Task<ObtenerPedidoMesaQueryDTO> ObtenerPedidoMesa(ObtenerPedidoMesaQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidMesa", query.IdMesa, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerPedidoPorMesa]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    ObtenerPedidoMesaQueryDTO response = new();
                    while (reader.Read())
                    {
                        response = new ObtenerPedidoMesaQueryDTO()
                        {
                            IdPedido = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Serie = Convert.IsDBNull(reader["SERIE"]) ? "" : reader["SERIE"].ToString(),
                            Correlativo = Convert.IsDBNull(reader["CORRELATIVO"]) ? "" : reader["CORRELATIVO"].ToString(),
                            ClienteId = Convert.IsDBNull(reader["CLIENTE_ID"]) ? 0 : Convert.ToInt32(reader["CLIENTE_ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE_CLIENTE"]) ? "" : reader["NOMBRE_CLIENTE"].ToString(),
                            ApellidoPaterno = Convert.IsDBNull(reader["APELLIDO_PATERNO_CLIENTE"]) ? "" : reader["APELLIDO_PATERNO_CLIENTE"].ToString(),
                            ApellidoMaterno = Convert.IsDBNull(reader["APELLIDO_MATERNO_CLIENTE"]) ? "" : reader["APELLIDO_MATERNO_CLIENTE"].ToString(),
                            RUC = Convert.IsDBNull(reader["RUC"]) ? "" : reader["RUC"].ToString(),
                            RazonSocial = Convert.IsDBNull(reader["RAZON_SOCIAL"]) ? "" : reader["RAZON_SOCIAL"].ToString()
                        };
                    }
                    return response;
                }
            }
        }
    }
}
