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
using DonShalo.Application.Personal.Command.EditarPersonal;
using DonShalo.Application.Personal.Command.EliminarPersonal;
using DonShalo.Application.Personal.Command.RegistrarUsuario;
using DonShalo.Application.Personal.Query.ObtenerPersonal;
using DonShalo.Application.Personal.Query.VerPersonal;
using DonShalo.Application.Sucursal.Query.ObtenerSucursal;
using DonShalo.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;

namespace DonShalo.Persistence.Repository
{
    public class PersonalRepository : IPersonalRepository
    {
        private readonly IDataBase _dataBase;
        private readonly ICryptography cryptography;
        public PersonalRepository(IServiceProvider serviceProvider, ICryptography cryptography)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
            this.cryptography = cryptography;
        }
        public async Task<RegistrarUsuarioCommandDTO> RegistrarPersonal(RegistrarUsuarioCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@ptipoDocumento", command.TipoDocumento, DbType.String, ParameterDirection.Input);
                parameters.Add("@pnumeroDocumento", command.NumeroDocumento, DbType.String, ParameterDirection.Input);
                parameters.Add("@pnombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@papellidoPaterno", command.ApellidoPaterno, DbType.String, ParameterDirection.Input);
                parameters.Add("@papellidoMaterno", command.ApellidoMaterno, DbType.String, ParameterDirection.Input);
                parameters.Add("@ptelefono", command.Telefono, DbType.String, ParameterDirection.Input);
                parameters.Add("@pcorreo", command.Correo, DbType.String, ParameterDirection.Input);
                parameters.Add("@pclave", this.cryptography.Encrypt(command.Clave), DbType.String, ParameterDirection.Input);
                parameters.Add("@pidRol", command.IdRol, DbType.String, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_RegistrarUsuario]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new RegistrarUsuarioCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<IEnumerable<ObtenerPersonalQueryDTO>> ObtenerSucursales(ObtenerPersonalQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pNumeroPersonal", query.CodigoPersonal, DbType.String, ParameterDirection.Input);
                parameters.Add("@pNumeroDocumento", query.NumeroDocumento, DbType.String, ParameterDirection.Input);
                parameters.Add("@pNombre", query.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@pRol", query.IdRol, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerPersonal]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    List<ObtenerPersonalQueryDTO> response = new();
                    while (reader.Read())
                    {
                        response.Add(new ObtenerPersonalQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            TipoDocumento = Convert.IsDBNull(reader["TIPO_DOCUMENTO"]) ? "" : reader["TIPO_DOCUMENTO"].ToString(),
                            NumeroDocumento = Convert.IsDBNull(reader["NUMERO_DOCUMENTO"]) ? "" : reader["NUMERO_DOCUMENTO"].ToString(),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Telefono = Convert.IsDBNull(reader["TELEFONO"]) ? "" : reader["TELEFONO"].ToString(),
                            Correo = Convert.IsDBNull(reader["CORREO"]) ? "" : reader["CORREO"].ToString(),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? "" : reader["ESTADO"].ToString(),
                            Rol = Convert.IsDBNull(reader["ROL"]) ? "" : reader["ROL"].ToString(),
                        });
                    }
                    return response;
                }
            }
        }

        public async Task<VerPersonalQueryDTO> VerSucursales(VerPersonalQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pId", query.IdPersonal, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_VerPersonal]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    VerPersonalQueryDTO response = new();
                    while (reader.Read())
                    {
                        response = (new VerPersonalQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            TipoDocumento = Convert.IsDBNull(reader["TIPO_DOCUMENTO"]) ? "" : reader["TIPO_DOCUMENTO"].ToString(),
                            NumeroDocumento = Convert.IsDBNull(reader["NUMERO_DOCUMENTO"]) ? "" : reader["NUMERO_DOCUMENTO"].ToString(),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Telefono = Convert.IsDBNull(reader["TELEFONO"]) ? "" : reader["TELEFONO"].ToString(),
                            Correo = Convert.IsDBNull(reader["CORREO"]) ? "" : reader["CORREO"].ToString(),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? "" : reader["ESTADO"].ToString(),
                            Rol = Convert.IsDBNull(reader["ROL"]) ? 0 : Convert.ToInt32(reader["ROL"].ToString()),
                        });
                    }
                    return response;
                }
            }
        }

        public async Task<EditarPersonalCommandDTO> EditarPersonal(EditarPersonalCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pId", command.Id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pnombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@papellidoPaterno", command.ApellidoPaterno, DbType.String, ParameterDirection.Input);
                parameters.Add("@papellidoMaterno", command.ApellidoMaterno, DbType.String, ParameterDirection.Input);
                parameters.Add("@ptelefono", command.Telefono, DbType.String, ParameterDirection.Input);
                parameters.Add("@pcorreo", command.Correo, DbType.String, ParameterDirection.Input);
                parameters.Add("@pidRol", command.IdRol, DbType.String, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_EditarPersonal]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new EditarPersonalCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<EliminarPersonalCommandDTO> EliminarPersonal(EliminarPersonalCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pId", command.IdPersonal, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_EliminarPersonal]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new EliminarPersonalCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }
    }
}
