using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Categoria.Command.EditarCategoria
{
    public class EditarCategoriaCommand : IRequest<EditarCategoriaCommandDTO>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
