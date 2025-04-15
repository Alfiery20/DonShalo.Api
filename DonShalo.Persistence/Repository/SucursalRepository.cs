using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DonShalo.Application.Autenticacion.Command.IniciarSesion;
using DonShalo.Application.Common.Interface;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Application.Personal.Command.RegistrarUsuario;
using DonShalo.Application.Sucursal.Command.AgregarSucursal;
using DonShalo.Application.Sucursal.Query.ObtenerSucursal;
using DonShalo.Application.Sucursal.Query.VerSucursal;
using DonShalo.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;

namespace DonShalo.Persistence.Repository
{
    public class SucursalRepository : ISucursalRepository
    {
        private readonly IDataBase _dataBase;

        public SucursalRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<AgregarSucursalCommandDTO> RegistrarSucursal(AgregarSucursalCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pnombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@pdireccion", command.Direccion, DbType.String, ParameterDirection.Input);
                parameters.Add("@ptelefono", command.Telefono, DbType.String, ParameterDirection.Input);
                parameters.Add("@pidEncargado", command.IdEncargado, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pfechaEntrada", command.FechaEntrada.ToTimeSpan(), DbType.Time, ParameterDirection.Input);
                parameters.Add("@pfechaSalida", command.FechaSalida.ToTimeSpan(), DbType.Time, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_RegistrarSucursal]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new AgregarSucursalCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<IEnumerable<ObtenerSucursalQueryDTO>> ObtenerSucursales(ObtenerSucursalQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pTermino", query.Termino, DbType.String, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerSucursales]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    List<ObtenerSucursalQueryDTO> response = new();
                    while (reader.Read())
                    {
                        response.Add(new ObtenerSucursalQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            CodigoSucursal = Convert.IsDBNull(reader["CODIGO_SUCURSAL"]) ? "" : reader["CODIGO_SUCURSAL"].ToString(),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Direccion = Convert.IsDBNull(reader["DIRECCION"]) ? "" : reader["DIRECCION"].ToString(),
                            Telefono = Convert.IsDBNull(reader["TELEFONO"]) ? "" : reader["TELEFONO"].ToString(),
                            HoraEntrada = Convert.IsDBNull(reader["HORA_ENTRADA"]) ? TimeOnly.MinValue : TimeOnly.FromDateTime(Convert.ToDateTime(reader["HORA_ENTRADA"].ToString())),
                            HoraSalida = Convert.IsDBNull(reader["HORA_SALIDA"]) ? TimeOnly.MinValue : TimeOnly.FromDateTime(Convert.ToDateTime(reader["HORA_SALIDA"].ToString())),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? "" : reader["ESTADO"].ToString(),
                            Responsable = Convert.IsDBNull(reader["RESPONSABLE"]) ? "" : reader["RESPONSABLE"].ToString()
                        });
                    }
                    return response;
                }
            }
        }

        public async Task<VerSucursalQueryDTO> VerSucursales(VerSucursalQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pid", query.Id, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_VerSucursal]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    VerSucursalQueryDTO response = new();
                    while (reader.Read())
                    {
                        response = new VerSucursalQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            CodigoSucursal = Convert.IsDBNull(reader["CODIGO_SUCURSAL"]) ? "" : reader["CODIGO_SUCURSAL"].ToString(),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Direccion = Convert.IsDBNull(reader["DIRECCION"]) ? "" : reader["DIRECCION"].ToString(),
                            Telefono = Convert.IsDBNull(reader["TELEFONO"]) ? "" : reader["TELEFONO"].ToString(),
                            HoraEntrada = Convert.IsDBNull(reader["HORA_ENTRADA"]) ? TimeOnly.MinValue : TimeOnly.FromDateTime(Convert.ToDateTime(reader["HORA_ENTRADA"].ToString())),
                            HoraSalida = Convert.IsDBNull(reader["HORA_SALIDA"]) ? TimeOnly.MinValue : TimeOnly.FromDateTime(Convert.ToDateTime(reader["HORA_SALIDA"].ToString())),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? false : Convert.ToBoolean(reader["ESTADO"].ToString()),
                            IdResponsable = Convert.IsDBNull(reader["ID_RESPONSABLE"]) ? 0 : Convert.ToInt32(reader["ID_RESPONSABLE"].ToString()),
                            Responsable = Convert.IsDBNull(reader["RESPONSABLE"]) ? "" : reader["RESPONSABLE"].ToString()
                        };
                    }
                    return response;
                }
            }
        }
    }
}
