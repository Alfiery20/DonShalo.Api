﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DonShalo.Application.MedioPago.Query.VerMedioPago
{
    public class VerMedioPagoQueryDTO : IRequest<VerMedioPagoQueryDTO>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
    }
}
