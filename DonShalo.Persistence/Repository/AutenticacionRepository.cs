using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DonShalo.Application.Autenticacion.Command.IniciarSesion;
using DonShalo.Application.Autenticacion.Command.RegistrarUsuario;
using DonShalo.Application.Common.Interface;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;

namespace DonShalo.Persistence.Repository
{
    public class AutenticacionRepository : IAutenticacionRepository
    {
        private readonly IDataBase _dataBase;
        private readonly ICryptography cryptography;

        public AutenticacionRepository(IServiceProvider serviceProvider, ICryptography cryptography)
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

        public async Task<IniciarSesionCommandDTO> IniciarSesion(IniciarSesionCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pemail", command.Correo, DbType.String, ParameterDirection.Input);
                parameters.Add("@pclave", this.cryptography.Encrypt(command.Clave), DbType.String, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_IniciarSesion]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    IniciarSesionCommandDTO response = new();
                    while (reader.Read())
                    {
                        response = new IniciarSesionCommandDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            CodigoPersonal = Convert.IsDBNull(reader["CODIGO_PERSONAL"]) ? "" : reader["CODIGO_PERSONAL"].ToString(),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            ApellidoPaterno = Convert.IsDBNull(reader["APELLIDO_PATERNO"]) ? "" : reader["APELLIDO_PATERNO"].ToString(),
                            ApellidoMaterno = Convert.IsDBNull(reader["APELLIDO_MATERNO"]) ? "" : reader["APELLIDO_MATERNO"].ToString(),
                            IdRol = Convert.IsDBNull(reader["ID_ROL"]) ? 0 : Convert.ToInt32(reader["ID_ROL"].ToString()),
                            NombreRol = Convert.IsDBNull(reader["NOMBRE_ROL"]) ? "" : reader["NOMBRE_ROL"].ToString()
                        };
                    }
                    return response;
                }
            }
        }
    }
}
