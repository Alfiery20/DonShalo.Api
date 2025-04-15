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
    }
}
