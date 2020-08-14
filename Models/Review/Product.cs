using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Review
{
    public class Product
    {
        public class ProductImage
        {
            public Int64 id { get; set; }
            public string image_url { get; set; }
            public string big_image_url { get; set; }
        }
        public string product_url { get; set; }
        public Int64 id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string shorten_url { get; set; }
        //public List<string> images { get; set; }
        public List<ProductImage> images { get; set; }
        public SocialNetworkLinks social_network_links { get; set; }
        public string facebook_testemonials_page_product_url  { get; set; }
    }   
}
