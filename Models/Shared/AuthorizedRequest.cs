using System;
using System.Collections.Generic;
using System.Text;

namespace Yotpo.Light.Models.Shared
{
    public interface iAuthorizedRequest
    {
        /// <summary>
        /// Your Yotpo account access token. See Yotpo Authentication to learn how to generate your utoken.
        /// </summary>
        string utoken { get; set; }
    }
}
