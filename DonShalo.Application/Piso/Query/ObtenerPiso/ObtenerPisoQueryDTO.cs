using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Piso.Query.ObtenerPiso
{
    public class ObtenerPisoQueryDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CapacidadCliente { get; set; }
        public int CapacidadPersonal { get; set; }
        public string Sucursal { get; set; }
        public string Estado { get; set; }
    }
}
