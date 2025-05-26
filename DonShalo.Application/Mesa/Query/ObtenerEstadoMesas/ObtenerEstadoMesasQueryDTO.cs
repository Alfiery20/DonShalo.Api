using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Mesa.Query.ObtenerEstadoMesas
{
    public class ObtenerEstadoMesasQueryDTO
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int Estado { get; set; }
    }
}
