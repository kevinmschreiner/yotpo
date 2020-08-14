using System;
using System.Collections.Generic;
using System.Text;
using Yotpo.Light.Models.Shared;

namespace Yotpo.Light.Models.Account
{
    public class Request : iAuthorizedRequest
    {
        public AccountPlatformRequest account_platform { get; set; }
        public string utoken { get; set; }
    }
}
