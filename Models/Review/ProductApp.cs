using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Review
{
    public class ProductApp
    {
        public Int64 id { get; set; }
        public string product_url { get; set; }
        public string domain_key { get; set; }
        public ProductMeta product { get; set; }
    }
}
