using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using Yotpo.Light.Models.Order;
using Yotpo.Light.Models.Product;

namespace Yotpo.Light.Services
{
    public class Product:Base
    {
        public Product(string appKey, string secretKey) : base(appKey, secretKey) { }
        public Models.Product.ProductListResponse Retrieve(int? count = null, int? page = null)
        {
            string url = "v1/apps/{{APPKEY}}/products?utoken={{UTOKEN}}";
            if (count != null) url += "&count=" + count.Value.ToString();
            if (page != null) url += "&page=" + page.Value.ToString();

            return Models.Product.ProductListResponse.from(base.Get(url));
        }
        public Models.Product.PromotedListResponse Promoted(int? count =null, int? page = null)
        {
            string url = "v1/apps/{{APPKEY}}/products?utoken={{UTOKEN}}";
            if (count != null) url += "&count=" + count.Value.ToString();
            if (page != null) url += "&page=" + page.Value.ToString();

            return Models.Product.PromotedListResponse.from(base.Get(url));
        }

        public bool Update(string return_email_address, string result_callback_url, string key, UpdateProduct product)
        {
            var request = new UpdateRequest();
            request.result_callback_url = result_callback_url;
            request.return_email_address = return_email_address;
            
            request.Add(key, product);

            var result = base.Put("apps/{{APPKEY}}/products/mass_update", request);
            if (result.status.code == 200) return true;
            return false;
        }

        public bool Add(string return_email_address, string result_callback_url, string key, UpdateProduct product)
        {
            var request = new UpdateRequest();
            request.result_callback_url = result_callback_url;
            request.return_email_address = return_email_address;

            request.Add(key, product);

            var result = base.Post("apps/{{APPKEY}}/products/mass_create", request);
            if (result.status.code == 200) return true;
            return false;
        }
    }
}
