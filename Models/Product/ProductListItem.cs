using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Product
{
    public class ProductListItem
    {
        public Int64 id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public bool blacklisted { get; set; }
        public decimal average_score { get; set; }
        public int total_reviews { get; set; }
        public string url { get; set; }
        public string external_product_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Shared.CustomProperty> product_specs { get; set; }
        public Category category { get; set; }
        public List<ProductImage> images {get;set;}
    }
}
