using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Categoria.Query.VerCategoria
{
    public class VerCategoriaQuery : IRequest<VerCategoriaQueryDTO>
    {
        public int Id { get; set; }
    }
}
