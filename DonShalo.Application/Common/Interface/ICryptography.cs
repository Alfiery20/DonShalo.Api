﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonShalo.Application.Common.Interface
{
    public interface ICryptography
    {
        string Encrypt(string Texto);
        string Decrypt(string cipherText);
    }
}
