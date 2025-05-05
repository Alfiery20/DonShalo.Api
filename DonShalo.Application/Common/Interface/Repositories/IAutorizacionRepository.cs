using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Autorizacion.Command.ObtenerMenu;

namespace DonShalo.Application.Common.Interface.Repositories
{
    public interface IAutorizacionRepository
    {
        Task<IEnumerable<ObtenerMenuCommandDTO>> ObtenerMenu(ObtenerMenuCommand command);
    }
}
