using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dapper;
using DonShalo.Application.Common.Interface;
using DonShalo.Application.Common.Interface.Repositories;
using DonShalo.Application.Mesa.Command.AgregarMesa;
using DonShalo.Application.Mesa.Query.VerMesa;
using DonShalo.Application.Pedido.Command.AgregarPedido;
using DonShalo.Application.Pedido.Command.EditarPedido;
using DonShalo.Application.Pedido.Command.EliminarPedido;
using DonShalo.Application.Pedido.Query.ObtenerDetallePedido;
using DonShalo.Application.Pedido.Query.ObtenerPedidoMesa;
using DonShalo.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;

namespace DonShalo.Persistence.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IDataBase _dataBase;

        public PedidoRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }
        public async Task<ObtenerPedidoMesaQueryDTO> ObtenerPedidoMesa(ObtenerPedidoMesaQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidMesa", query.IdMesa, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerPedidoPorMesa]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    ObtenerPedidoMesaQueryDTO response = new();
                    while (reader.Read())
                    {
                        response = new ObtenerPedidoMesaQueryDTO()
                        {
                            IdPedido = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Serie = Convert.IsDBNull(reader["SERIE"]) ? "" : reader["SERIE"].ToString(),
                            Correlativo = Convert.IsDBNull(reader["CORRELATIVO"]) ? "" : reader["CORRELATIVO"].ToString(),
                            ClienteId = Convert.IsDBNull(reader["CLIENTE_ID"]) ? 0 : Convert.ToInt32(reader["CLIENTE_ID"].ToString()),
                            NumeroDocumento = Convert.IsDBNull(reader["NUMERO_DOCUMENTO"]) ? "" : reader["NUMERO_DOCUMENTO"].ToString(),
                            Nombre = Convert.IsDBNull(reader["NOMBRE_CLIENTE"]) ? "" : reader["NOMBRE_CLIENTE"].ToString(),
                            ApellidoPaterno = Convert.IsDBNull(reader["APELLIDO_PATERNO_CLIENTE"]) ? "" : reader["APELLIDO_PATERNO_CLIENTE"].ToString(),
                            ApellidoMaterno = Convert.IsDBNull(reader["APELLIDO_MATERNO_CLIENTE"]) ? "" : reader["APELLIDO_MATERNO_CLIENTE"].ToString(),
                            RUC = Convert.IsDBNull(reader["RUC"]) ? "" : reader["RUC"].ToString(),
                            RazonSocial = Convert.IsDBNull(reader["RAZON_SOCIAL"]) ? "" : reader["RAZON_SOCIAL"].ToString()
                        };
                    }
                    return response;
                }
            }
        }

        public async Task<AgregarPedidoCommandDTO> RegistrarPedido(AgregarPedidoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidCliente", command.IdCliente, DbType.String, ParameterDirection.Input);
                parameters.Add("@pidMesa", command.IdMesa, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pidPersonal", command.IdPersonal, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pdetPedidos", this.ConvertirAXML(command.DetallePedido.ToList()), DbType.Xml, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_RegistrarPedido]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new AgregarPedidoCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<IEnumerable<ObtenerDetallePedidoQueryDTO>> ObtenerDetallePedido(ObtenerDetallePedidoQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidPedido", query.IdPedido, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerDetallePedido]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    List<ObtenerDetallePedidoQueryDTO> response = new();
                    while (reader.Read())
                    {
                        response.Add(new ObtenerDetallePedidoQueryDTO()
                        {
                            IdPlato = Convert.IsDBNull(reader["ID_PLATO"]) ? 0 : Convert.ToInt32(reader["ID_PLATO"].ToString()),
                            Plato = Convert.IsDBNull(reader["PLATO"]) ? "" : reader["PLATO"].ToString(),
                            Cantidad = Convert.IsDBNull(reader["CANTIDAD"]) ? 0 : Convert.ToInt32(reader["CANTIDAD"].ToString()),
                        });
                    }
                    return response;
                }
            }
        }

        public async Task<EditarPedidoCommandDTO> EditarPedido(EditarPedidoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidPedido", command.IdPedido, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pidCliente", command.IdCliente, DbType.String, ParameterDirection.Input);
                parameters.Add("@pdetPedidos", this.ConvertirAXML(command.DetallePedido.ToList()), DbType.Xml, ParameterDirection.Input);
                
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_EditarPedido]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new EditarPedidoCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<EliminarPedidoCommandDTO> EliminarPedido(EliminarPedidoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdPedido", command.IdPedido, DbType.String, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_EliminarPedido]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new EliminarPedidoCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        private string ConvertirAXML(List<AgregarPedidoDetalle> detalles)
        {
            var xml = new XElement("detalles",
                    detalles.Select(p =>
                        new XElement("detalle",
                            new XElement("idPlato", p.IdPlato),
                            new XElement("cantidad", p.Cantidad)
                        )
                    ));
            return xml.ToString();
        }

        private string ConvertirAXML(List<EditarPedidoDetalle> detalles)
        {
            var xml = new XElement("detalles",
                    detalles.Select(p =>
                        new XElement("detalle",
                            new XElement("idPlato", p.IdPlato),
                            new XElement("cantidad", p.Cantidad)
                        )
                    ));
            return xml.ToString();
        }
    }
}
