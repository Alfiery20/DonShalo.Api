using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Cliente.Query.VerCliente
{
    public class VerClienteQueryDTO
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string RUC { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string DireccionEntrega { get; set; }
    }
}
