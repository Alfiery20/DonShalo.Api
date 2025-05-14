using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Autorizacion.Command.ObtenerMenu;
using DonShalo.Application.Personal.Command.AsignarResponsable;
using DonShalo.Application.Personal.Command.EditarPersonal;
using DonShalo.Application.Personal.Command.EliminarPersonal;
using DonShalo.Application.Personal.Command.RegistrarUsuario;
using DonShalo.Application.Personal.Query.ObtenerMenuPersonal;
using DonShalo.Application.Personal.Query.ObtenerPersonal;
using DonShalo.Application.Personal.Query.VerPersonal;

namespace DonShalo.Application.Common.Interface.Repositories
{
    public interface IPersonalRepository
    {
        Task<RegistrarUsuarioCommandDTO> RegistrarPersonal(RegistrarUsuarioCommand command);
        Task<IEnumerable<ObtenerPersonalQueryDTO>> ObtenerPersonal(ObtenerPersonalQuery query);
        Task<VerPersonalQueryDTO> VerPersonal(VerPersonalQuery query);
        Task<EditarPersonalCommandDTO> EditarPersonal(EditarPersonalCommand command);
        Task<EliminarPersonalCommandDTO> EliminarPersonal(EliminarPersonalCommand command);
        Task<IEnumerable<ObtenerMenuPersonalQueryDTO>> ObtenerMenuPersonal(ObtenerMenuPersonalQuery command);
        Task<AsignarResponsableCommandDTO> AsignarPersonal(AsignarResponsableCommand command);
    }
}
