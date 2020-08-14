using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Product
{
    public class UpdateProduct
    {
        public string name { get; set; }
        public string url { get; set; }
        public string image_url { get; set; }
        public string description { get; set; }
        public string currency { get; set; }
        public string price { get; set; }
        public string group_name { get; set; }
        public string product_tags { get; set; }
        public Spec specs { get; set; }
    }
}
