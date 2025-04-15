using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Sucursal.Query.ObtenerSucursal
{
    public class ObtenerSucursalQueryDTO
    {
        public int Id { get; set; }
        public string CodigoSucursal { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public TimeOnly HoraEntrada { get; set; }
        public TimeOnly HoraSalida { get; set; }
        public string Estado { get; set; }
        public string Responsable { get; set; }
    }
}
