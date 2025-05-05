using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Autorizacion.Command.ObtenerMenu
{
    public class ObtenerMenuCommandDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public int IdMenuPadre { get; set; }
        public int Orden { get; set; }
        public List<ObtenerMenuCommandDTO> MenuHijo { get; set; }
    }
}
