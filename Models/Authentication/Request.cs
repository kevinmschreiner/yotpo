using System;
using System.Collections.Generic;
using System.Text;

namespace Yotpo.Light.Models.Authentication
{
    public class Request
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string grant_type { get; set; }
    }
}
