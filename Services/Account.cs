using System;
using System.Collections.Generic;
using System.Text;

namespace Yotpo.Light.Services
{
    public class Account:Base
    {
        public Account(string appKey,string secretKey) : base(appKey, secretKey) { }
        public bool Set(string shop_domain, string platform_type_id)
        {
            var request = new Models.Account.Request()
            {
                account_platform = new Models.Account.AccountPlatformRequest()
                {
                    platform_type_id = platform_type_id,
                    shop_domain = shop_domain
                }
            };
            var result = (Models.Account.AccountPlatformResponse) base.Post("apps/{{APPKEY}}/account_platform", request).response;
            if (result!=null && result.platform_type!=null && result.platform_type.id==int.Parse(platform_type_id))
            {
                return true;
            }
            return false;
        }

    }
}
