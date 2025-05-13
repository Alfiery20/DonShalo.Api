using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Personal.Query.ObtenerPersonal
{
    public class ObtenerPersonalQueryDTO
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Estado { get; set; }
        public string Rol { get; set; }
        public string Sucursal { get; set; }
    }
}
