using System.Data;
using Dapper;
using DonShalo.Application.Cliente.Command.AgregarCliente;
using DonShalo.Application.Cliente.Command.EditarCliente;
using DonShalo.Application.Cliente.Query.ObtenerClienteDoc;
using DonShalo.Application.Cliente.Query.VerCliente;
using DonShalo.Application.Common.Interface;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Application.MedioPago.Query.ObtenerMedioPago;
using DonShalo.Application.Piso.Command.AgregarPiso;
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

        public async Task<VerClienteQueryDTO> VerCliente(VerClienteQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pid", query.Id, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_VerCliente]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    VerClienteQueryDTO response = new();
                    while (reader.Read())
                    {
                        response = new VerClienteQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            TipoDocumento = Convert.IsDBNull(reader["TIPO_DOCUMENTO"]) ? "" : reader["TIPO_DOCUMENTO"].ToString(),
                            NumeroDocumento = Convert.IsDBNull(reader["NUMERO_DOCUMENTO"]) ? "" : reader["NUMERO_DOCUMENTO"].ToString(),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            ApellidoPaterno = Convert.IsDBNull(reader["APELLIDO_PATERNO"]) ? "" : reader["APELLIDO_PATERNO"].ToString(),
                            ApellidoMaterno = Convert.IsDBNull(reader["APELLIDO_MATERNO"]) ? "" : reader["APELLIDO_MATERNO"].ToString(),
                            RUC = Convert.IsDBNull(reader["RUC"]) ? "" : reader["RUC"].ToString(),
                            RazonSocial = Convert.IsDBNull(reader["RAZON_SOCIAL"]) ? "" : reader["RAZON_SOCIAL"].ToString(),
                            Direccion = Convert.IsDBNull(reader["DIRECCION"]) ? "" : reader["DIRECCION"].ToString(),
                            DireccionEntrega = Convert.IsDBNull(reader["DIRECCION_ENTREGA"]) ? "" : reader["DIRECCION_ENTREGA"].ToString()

                        };
                    }
                    return response;
                }
            }
        }

        public async Task<AgregarClienteCommandDTO> RegistrarCliente(AgregarClienteCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@ptipoDocumento", command.TipoDocumento, DbType.String, ParameterDirection.Input);
                parameters.Add("@pnumeroDocumento", command.NumeroDocumento, DbType.String, ParameterDirection.Input);
                parameters.Add("@pnombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@papellidoPaterno", command.ApellidoPaterno, DbType.String, ParameterDirection.Input);
                parameters.Add("@papellidoMaterno", command.ApellidoMaterno, DbType.String, ParameterDirection.Input);
                parameters.Add("@pruc", command.Ruc, DbType.String, ParameterDirection.Input);
                parameters.Add("@prazonSocial", command.RazonSocial, DbType.String, ParameterDirection.Input);
                parameters.Add("@pdireccion", command.Direccion, DbType.String, ParameterDirection.Input);
                parameters.Add("@pdireccionEntrega", command.DireccionEntrega, DbType.String, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_RegistrarCliente]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new AgregarClienteCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<EditarClienteCommandDTO> EditarCliente(EditarClienteCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pid", command.Id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@ptipoDocumento", command.TipoDocumento, DbType.String, ParameterDirection.Input);
                parameters.Add("@pnumeroDocumento", command.NumeroDocumento, DbType.String, ParameterDirection.Input);
                parameters.Add("@pnombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@papellidoPaterno", command.ApellidoPaterno, DbType.String, ParameterDirection.Input);
                parameters.Add("@papellidoMaterno", command.ApellidoMaterno, DbType.String, ParameterDirection.Input);
                parameters.Add("@pruc", command.Ruc, DbType.String, ParameterDirection.Input);
                parameters.Add("@prazonSocial", command.RazonSocial, DbType.String, ParameterDirection.Input);
                parameters.Add("@pdireccion", command.Direccion, DbType.String, ParameterDirection.Input);
                parameters.Add("@pdireccionEntrega", command.DireccionEntrega, DbType.String, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_EditarCliente]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new EditarClienteCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }
    }
}
