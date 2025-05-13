using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Personal.Query.VerPersonal
{
    public class VerPersonalQueryDTO
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Estado { get; set; }
        public int Rol { get; set; }
        public int Sucursal { get; set; }
    }
}
