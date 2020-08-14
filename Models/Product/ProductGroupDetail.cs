using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Product
{
    public class ProductGroupDetail: ProductGroup
    {
        public class ProductApp
        {
            public string sku { get; set; }
            public string product_url { get; set; }
        }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public List<ProductApp> products_apps { get; set; } 
    }
}
