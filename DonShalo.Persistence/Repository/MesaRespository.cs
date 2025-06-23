using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DonShalo.Application.Common.Interface;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Application.Mesa.Command.AgregarMesa;
using DonShalo.Application.Mesa.Command.EditarMesa;
using DonShalo.Application.Mesa.Command.EliminarMesa;
using DonShalo.Application.Mesa.Command.LimpiarMesa;
using DonShalo.Application.Mesa.Query.ObtenerEstadoMesas;
using DonShalo.Application.Mesa.Query.ObtenerMesa;
using DonShalo.Application.Mesa.Query.VerMesa;
using DonShalo.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;

namespace DonShalo.Persistence.Repository
{
    public class MesaRespository : IMesaRespository
    {
        private readonly IDataBase _dataBase;

        public MesaRespository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<AgregarMesaCommandDTO> RegistrarMesa(AgregarMesaCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pnumero", command.Numero, DbType.String, ParameterDirection.Input);
                parameters.Add("@pcapacidad", command.Capacidad, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pidPiso", command.IdPiso, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_RegistrarMesa]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new AgregarMesaCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<IEnumerable<ObtenerMesaQueryDTO>> ObtenerMesa(ObtenerMesaQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pTermino", query.Termino, DbType.String, ParameterDirection.Input);
                parameters.Add("@pIdSucursal", query.IdSucursal, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pIdPiso", query.IdPiso, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerMesa]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    List<ObtenerMesaQueryDTO> response = new();
                    while (reader.Read())
                    {
                        response.Add(new ObtenerMesaQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Numero = Convert.IsDBNull(reader["NUMERO"]) ? "" : reader["NUMERO"].ToString(),
                            Capacidad = Convert.IsDBNull(reader["CAPACIDAD"]) ? 0 : Convert.ToInt32(reader["CAPACIDAD"].ToString()),
                            Sucursal = Convert.IsDBNull(reader["SUCURSAL"]) ? "" : reader["SUCURSAL"].ToString(),
                            Piso = Convert.IsDBNull(reader["PISO"]) ? "" : reader["PISO"].ToString(),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? "" : reader["ESTADO"].ToString()
                        });
                    }
                    return response;
                }
            }
        }

        public async Task<VerMesaQueryDTO> VerMesa(VerMesaQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pid", query.IdMesa, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_VerMesa]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    VerMesaQueryDTO response = new();
                    while (reader.Read())
                    {
                        response = new VerMesaQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Numero = Convert.IsDBNull(reader["NUMERO"]) ? "" : reader["NUMERO"].ToString(),
                            Capacidad = Convert.IsDBNull(reader["CAPACIDAD"]) ? 0 : Convert.ToInt32(reader["CAPACIDAD"].ToString()),
                            IdSucursal = Convert.IsDBNull(reader["SUCURSAL"]) ? 0 : Convert.ToInt32(reader["SUCURSAL"].ToString()),
                            IdPiso = Convert.IsDBNull(reader["PISO"]) ? 0 : Convert.ToInt32(reader["PISO"].ToString())
                        };
                    }
                    return response;
                }
            }
        }

        public async Task<EditarMesaCommandDTO> EditarMesa(EditarMesaCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pId", command.IdMesa, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pnumero", command.Numero, DbType.String, ParameterDirection.Input);
                parameters.Add("@pcapacidad", command.Capacidad, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pidPiso", command.IdPiso, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_EditarMesa]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new EditarMesaCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<EliminarMesaCommandDTO> EliminarMesa(EliminarMesaCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdMesa", command.IdMesa, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_EliminarMesa]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new EliminarMesaCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<IEnumerable<ObtenerEstadoMesasQueryDTO>> ObtenerEstadoMesas(ObtenerEstadoMesasQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidPiso", query.IdPiso, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerMesaPorPersonal]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    List<ObtenerEstadoMesasQueryDTO> response = new();
                    while (reader.Read())
                    {
                        response.Add(new ObtenerEstadoMesasQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Numero = Convert.IsDBNull(reader["NUMERO"]) ? "" : reader["NUMERO"].ToString(),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? 0 : Convert.ToInt32(reader["ESTADO"].ToString())
                        });
                    }
                    return response;
                }
            }
        }

        public async Task<LimpiarMesaCommandDTO> LimpiarMesa(LimpiarMesaCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidMesa", command.IdMesa, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_LimpiarMesa]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new LimpiarMesaCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }
    }
}
