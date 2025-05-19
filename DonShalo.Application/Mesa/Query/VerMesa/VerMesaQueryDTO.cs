using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Mesa.Query.VerMesa
{
    public class VerMesaQueryDTO
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int Capacidad { get; set; }
        public int IdPiso { get; set; }
        public int IdSucursal { get; set; }
    }
}
