using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Piso.Query.VerPiso
{
    public class VerPisoQueryDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CapacidadCliente { get; set; }
        public int CapacidadPersonal { get; set; }
        public int IdSucursal { get; set; }
        public string Sucursal { get; set; }
    }
}
