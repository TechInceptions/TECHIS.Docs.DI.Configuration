﻿using System;
using System.Collections.Generic;
using System.Text;
using TECHIS.Configuration;

namespace TECHIS.Docs.Services.Config
{
    public class CustomerService: ServiceConfigurationBase
    {
        public bool IsSupportMode { get; set; }
    }
}
