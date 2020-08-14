using System;
using System.Collections.Generic;
using System.Text;
using Yotpo.Light.Models.Shared;

namespace Yotpo.Light.Models.Order
{
    public class MassRequest : iAuthorizedRequest
    {

        /// <summary>
        /// Your eCommerce platform
        /// </summary>
        public string platform { get; set; }

        public List<Order> orders {get;set;}

        public string utoken { get; set; }

    }
}
