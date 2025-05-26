using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Categoria.Command.EliminarCategoria
{
    public class EliminarCategoriaCommand : IRequest<EliminarCategoriaCommandDTO>
    {
        public int IdCategoria { get; set; }
    }
}
