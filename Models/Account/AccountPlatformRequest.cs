using System;
using System.Collections.Generic;
using System.Text;

namespace Yotpo.Light.Models.Account
{
    public class AccountPlatformRequest
    {
        /// <summary>
        /// Your shop’s domain, starting with http://, for example https://www.yourawesomeshop.com/
        /// </summary>
        public string shop_domain { get; set; }

        /// <summary>
        /// Your e-commerce platform, for example 3dcart
        /// </summary>
        public string platform_type_id { get; set; }

    }
}
