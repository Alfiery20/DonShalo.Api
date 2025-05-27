using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Plato.Query.ObtenerPlato
{
    public class ObtenerPlatoQueryDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public double Monto { get; set; }
        public string Estado { get; set; }
    }
}
