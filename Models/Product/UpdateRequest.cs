using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Product
{
    public class UpdateRequest : Shared.iAuthorizedRequest
    {
        public string return_email_address { get; set; }
        public string result_callback_url { get; set; }
        public string utoken { get; set; }

        public Dictionary<string, UpdateProduct> products {get;set;}

        public void Add(string key, UpdateProduct product)
        {
            if (products == null) products = new Dictionary<string, UpdateProduct>();
            if (products.ContainsKey(key)) products[key] = product;
            else products.Add(key, product);
        }
    }
}
