﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Autenticacion.Command.IniciarSesion;
using DonShalo.Application.Personal.Command.RegistrarUsuario;

namespace DonShalo.Application.Common.Interface.Repositories
{
    public interface IAutenticacionRepository
    {
        Task<IniciarSesionCommandDTO> IniciarSesion(IniciarSesionCommand command);
    }
}
