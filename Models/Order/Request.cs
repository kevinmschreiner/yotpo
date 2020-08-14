using System;
using System.Collections.Generic;
using System.Text;
using Yotpo.Light.Models.Shared;

namespace Yotpo.Light.Models.Order
{
    public class Request : Order, iAuthorizedRequest
    {
        /// <summary>
        /// Your eCommerce platform
        /// </summary>
        public string platform { get; set; }
        /// <summary>
        /// Your Yotpo account access token. See Yotpo Authentication to learn how to generate your utoken.
        /// </summary>
        public string utoken { get; set; }

        /// <summary>
        /// Your Yotpo account API key
        /// </summary>
        public string app_key { get; set; }

    }
}
