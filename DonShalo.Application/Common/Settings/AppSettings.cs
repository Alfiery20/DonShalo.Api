﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonShalo.Application.Common.Dtos;

namespace DonShalo.Application.Common.Settings
{
    public class AppSettings
    {
        public string ApplicationName { get; set; }
        public string ApplicationDisplayName { get; set; }
        public string ApplicationId { get; set; }
        public long LongRequestTimeMilliseconds { get; set; }
        public long SlidingExpirationCacheTimeSeconds { get; set; }
        public MensajeUsuarioDTO GeneralErrorMessage { get; set; }
    }
}
