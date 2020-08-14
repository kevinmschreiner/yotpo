using System;
using System.Collections.Generic;
using System.Text;

namespace Yotpo.Light.Models.Account
{
    public class AccountPlatformResponse
    {
        public int id { get; set; }
        public string shop_token { get; set; }
        public string shop_domain { get; set; }
        public string shop_api_url { get; set; }
        public string plan_name { get; set; }
        public PlatformType platform_type { get; set; }
        public bool deleted { get; set; }
        public string shop_user_name { get; set; }
    }
}
