using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Rol.Query.ObtenerMenuxRol
{
    public class ObtenerMenuxRolQueryDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Permiso { get; set; }
        public int Padre { get; set; }
        public List<ObtenerMenuxRolQueryDTO> Hijos { get; set; }
    }
}
