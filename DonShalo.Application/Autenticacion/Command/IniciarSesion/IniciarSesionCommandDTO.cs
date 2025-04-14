using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Autenticacion.Command.IniciarSesion
{
    public class IniciarSesionCommandDTO
    {
        public int Id { get; set; }
        public string CodigoPersonal { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string Token { get; set; }
    }
}
