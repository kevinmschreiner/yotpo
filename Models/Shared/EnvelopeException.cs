using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Yotpo.Light.Models.Authentication;

namespace Yotpo.Light.Models.Shared
{
    public class EnvelopeException:Exception
    {
        public int Code { get; private set; }
        public string Type { get; private set; }
        public EnvelopeException(ResponseStatus status):base(status.message)
        {
            this.Code = status.code;
            this.Type = status.error_type;
        }
    }
}
