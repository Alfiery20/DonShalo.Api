using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.Categoria.Query.ObtenerCategoria
{
    public class ObtenerCategoriaQuery : IRequest<IEnumerable<ObtenerCategoriaQueryDTO>>
    {
        public string Termino { get; set; }
    }
}
