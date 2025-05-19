using System.Data;
using Dapper;
using DonShalo.Application.Common.Interface;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Application.Piso.Command.AgregarPiso;
using DonShalo.Application.Piso.Command.EditarPiso;
using DonShalo.Application.Piso.Command.EilminarPiso;
using DonShalo.Application.Piso.Query.ObtenerPiso;
using DonShalo.Application.Piso.Query.VerPiso;
using DonShalo.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;

namespace DonShalo.Persistence.Repository
{
    internal class PisoRepository : IPisoRepository
    {
        private readonly IDataBase _dataBase;

        public PisoRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<AgregarPisoCommandDTO> RegistrarPiso(AgregarPisoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pnombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@pcapacidadCliente", command.CapacidadCliente, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pcapacidadEmpleado", command.CapacidadPersonal, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pidSucursal", command.IdSucursal, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_RegistrarPiso]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new AgregarPisoCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<IEnumerable<ObtenerPisoQueryDTO>> ObtenerPiso(ObtenerPisoQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pTermino", query.Termino, DbType.String, ParameterDirection.Input);
                parameters.Add("@pIdSucursal", query.IdSucursal, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerPiso]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    List<ObtenerPisoQueryDTO> response = new();
                    while (reader.Read())
                    {
                        response.Add(new ObtenerPisoQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            CapacidadCliente = Convert.IsDBNull(reader["CLIENTES"]) ? 0 : Convert.ToInt32(reader["CLIENTES"].ToString()),
                            CapacidadPersonal = Convert.IsDBNull(reader["EMPLEADOS"]) ? 0 : Convert.ToInt32(reader["EMPLEADOS"].ToString()),
                            Sucursal = Convert.IsDBNull(reader["SUCURSAL"]) ? "" : reader["SUCURSAL"].ToString(),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? "" : reader["ESTADO"].ToString()
                        });
                    }
                    return response;
                }
            }
        }

        public async Task<VerPisoQueryDTO> VerPiso(VerPisoQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pid", query.IdPiso, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_VerPiso]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    VerPisoQueryDTO response = new();
                    while (reader.Read())
                    {
                        response = new VerPisoQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            CapacidadCliente = Convert.IsDBNull(reader["CLIENTES"]) ? 0 : Convert.ToInt32(reader["CLIENTES"].ToString()),
                            CapacidadPersonal = Convert.IsDBNull(reader["EMPLEADOS"]) ? 0 : Convert.ToInt32(reader["EMPLEADOS"].ToString()),
                            IdSucursal = Convert.IsDBNull(reader["ID_SUCURSAL"]) ? 0 : Convert.ToInt32(reader["ID_SUCURSAL"].ToString()),
                            Sucursal = Convert.IsDBNull(reader["SUCURSAL"]) ? "" : reader["SUCURSAL"].ToString()
                        };
                    }
                    return response;
                }
            }
        }

        public async Task<EditarPisoCommandDTO> EditarPiso(EditarPisoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pId", command.Id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pNombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@pcapacidadCliente", command.CapacidadClientes, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pcapacidadEmpleado", command.CapacidadEmpleados, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pidSucursal", command.IdSucursal, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_EditarPiso]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new EditarPisoCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<EliminarPisoCommandDTO> EliminarPiso(EliminarPisoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdPiso", command.IdPiso, DbType.String, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_EliminarPiso]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new EliminarPisoCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }
    }
}
