﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Common.Dtos;

namespace DonShalo.Application.Common.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(MensajeUsuarioDTO message)
            : base(message)
        {
        }
    }
}
