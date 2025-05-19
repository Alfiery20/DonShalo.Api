using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Mesa.Query.ObtenerMesa
{
    public class ObtenerMesaQueryDTO
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int Capacidad { get; set; }
        public string Piso { get; set; }
        public string Sucursal { get; set; }
        public string Estado { get; set; }
    }
}
