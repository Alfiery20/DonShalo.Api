using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DonShalo.Application.Common.Interface;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Application.Plato.Command.AgregarPlato;
using DonShalo.Application.Plato.Command.EditarPlato;
using DonShalo.Application.Plato.Command.EliminarPlato;
using DonShalo.Application.Plato.Query.ObtenerMenuPlato;
using DonShalo.Application.Plato.Query.ObtenerPlato;
using DonShalo.Application.Plato.Query.VerPlato;
using DonShalo.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;

namespace DonShalo.Persistence.Repository
{
    public class PlatoRepository : IPlatoRepository
    {
        private readonly IDataBase _dataBase;
        private readonly IDateTimeService _dateTimeService;

        public PlatoRepository(IServiceProvider serviceProvider, IDateTimeService dateTimeService)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
            this._dateTimeService = dateTimeService;
        }

        public async Task<AgregarPlatoCommandDTO> RegistrarPlato(AgregarPlatoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pnombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@pidCategoria", command.IdCategoria, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pFecha", this._dateTimeService.HoraLocal(), DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@pPrecio", command.Precio, DbType.Double, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_RegistrarCategoria]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new AgregarPlatoCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<IEnumerable<ObtenerPlatoQueryDTO>> ObtenerPlato(ObtenerPlatoQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pTermino", query.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@pIdCategoria", query.IdCategoria, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerPlato]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    List<ObtenerPlatoQueryDTO> response = new();
                    while (reader.Read())
                    {
                        response.Add(new ObtenerPlatoQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Categoria = Convert.IsDBNull(reader["CATEGORIA"]) ? "" : reader["CATEGORIA"].ToString(),
                            Monto = Convert.IsDBNull(reader["PRECIO"]) ? 0 : Convert.ToDouble(reader["PRECIO"].ToString()),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? "" : reader["ESTADO"].ToString()
                        });
                    }
                    return response;
                }
            }
        }

        public async Task<VerPlatoQueryDTO> VerPlato(VerPlatoQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pid", query.IdPlato, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_VerPlato]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    VerPlatoQueryDTO response = new();
                    while (reader.Read())
                    {
                        response = new VerPlatoQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Categoria = Convert.IsDBNull(reader["CATEGORIA"]) ? 0 : Convert.ToInt32(reader["CATEGORIA"].ToString()),
                            Monto = Convert.IsDBNull(reader["MONTO"]) ? 0 : Convert.ToDouble(reader["MONTO"].ToString()),
                        };
                    }
                    return response;
                }
            }
        }

        public async Task<EditarPlatoCommandDTO> EditarPlato(EditarPlatoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pId", command.Id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pnombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@pidCategoria", command.IdCategoria, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pPrecio", command.Monto, DbType.Double, ParameterDirection.Input);
                parameters.Add("@pFecha", this._dateTimeService.HoraLocal(), DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_EditarPlato]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new EditarPlatoCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<EliminarPlatoCommandDTO> EliminarPlato(EliminarPlatoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdPlato", command.Id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_EliminarPlato]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new EliminarPlatoCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<IEnumerable<ObtenerMenuPlatoQueryDTO>> ObtenerMenuPlato(ObtenerMenuPlatoQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidCategoria", query.IdCategoria, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerMenuPlato]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    List<ObtenerMenuPlatoQueryDTO> response = new();
                    while (reader.Read())
                    {
                        response.Add(new ObtenerMenuPlatoQueryDTO()
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
