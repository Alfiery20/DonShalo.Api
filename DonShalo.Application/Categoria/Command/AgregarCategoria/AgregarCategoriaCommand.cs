using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Categoria.Command.AgregarCategoria
{
    public class AgregarCategoriaCommand : IRequest<AgregarCategoriaCommandDTO>
    {
        public string Nombre { get; set; }
    }
}
