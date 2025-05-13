using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Personal.Command.RegistrarUsuario
{
    public class RegistrarUsuarioCommand : IRequest<RegistrarUsuarioCommandDTO>
    {
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public int IdRol { get; set; }
        public int IdSucursal { get; set; }
    }
}
