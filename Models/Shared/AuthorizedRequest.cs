﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Shared
{
    public class AuthorizedRequest: iAuthorizedRequest
    {
        public string utoken { get; set; }
    }
}
