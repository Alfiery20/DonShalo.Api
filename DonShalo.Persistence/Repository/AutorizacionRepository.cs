using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DonShalo.Application.Autenticacion.Command.IniciarSesion;
using DonShalo.Application.Autorizacion.Command.ObtenerMenu;
using DonShalo.Application.Common.Interface;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;

namespace DonShalo.Persistence.Repository
{
    public class AutorizacionRepository : IAutorizacionRepository
    {
        private readonly IDataBase _dataBase;

        public AutorizacionRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<IEnumerable<ObtenerMenuCommandDTO>> ObtenerMenu(ObtenerMenuCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdRol", command.IdRol, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pIdUsuario", command.IdUsuario, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_ObtenerMenu]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    List<ObtenerMenuCommandDTO> response = new();
                    while (reader.Read())
                    {
                        response.Add(new ObtenerMenuCommandDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Ruta = Convert.IsDBNull(reader["RUTA"]) ? "" : reader["RUTA"].ToString(),
                            IdMenuPadre = Convert.IsDBNull(reader["ID_PADRE"]) ? 0 : Convert.ToInt32(reader["ID_PADRE"].ToString()),
                            Orden = Convert.IsDBNull(reader["ORDEN"]) ? 0 : Convert.ToInt32(reader["ORDEN"].ToString())
                        });
                    }
                    return response;
                }
            }
        }
    }
}
