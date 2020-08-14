using System;
using System.Collections.Generic;
using System.Text;

namespace Yotpo.Light.Models.Shared
{
    public class ResponseStatus
    {
        public int code { get; set; }
        public string message { get; set; }
        public string error_type { get; set; }
    }
}
