using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DonShalo.Application.Categoria.Command.AgregarCategoria;
using DonShalo.Application.Categoria.Command.EditarCategoria;
using DonShalo.Application.Categoria.Command.EliminarCategoria;
using DonShalo.Application.Categoria.Query.ObtenerCategoria;
using DonShalo.Application.Categoria.Query.VerCategoria;
using DonShalo.Application.Common.Interface;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Application.Mesa.Command.AgregarMesa;
using DonShalo.Application.Mesa.Command.EditarMesa;
using DonShalo.Application.Mesa.Command.EliminarMesa;
using DonShalo.Application.Mesa.Query.ObtenerMesa;
using DonShalo.Application.Mesa.Query.VerMesa;
using DonShalo.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;

namespace DonShalo.Persistence.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IDataBase _dataBase;

        public CategoriaRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<AgregarCategoriaCommandDTO> RegistrarCategoria(AgregarCategoriaCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pnumero", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_RegistrarCategoria]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new AgregarCategoriaCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<EditarCategoriaCommandDTO> EditarCategoria(EditarCategoriaCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pId", command.Id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pnombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_EditarCategoria]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new EditarCategoriaCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }
        
        public async Task<EliminarCategoriaCommandDTO> EliminarCategoria(EliminarCategoriaCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdCategoria", command.IdCategoria, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_EliminarMesa]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new EliminarCategoriaCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<IEnumerable<ObtenerCategoriaQueryDTO>> ObtenerCategoria(ObtenerCategoriaQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pTermino", query.Termino, DbType.String, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerCategoria]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    List<ObtenerCategoriaQueryDTO> response = new();
                    while (reader.Read())
                    {
                        response.Add(new ObtenerCategoriaQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? "" : reader["ESTADO"].ToString()
                        });
                    }
                    return response;
                }
            }
        }

        public async Task<VerCategoriaQueryDTO> VerCategoria(VerCategoriaQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pid", query.Id, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_VerCategoria]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    VerCategoriaQueryDTO response = new();
                    while (reader.Read())
                    {
                        response = new VerCategoriaQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString()
                        };
                    }
                    return response;
                }
            }
        }
    }
}
