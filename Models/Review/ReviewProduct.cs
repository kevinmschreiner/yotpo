using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Review
{
    public class ReviewProduct
    {
        public Int64 id { get; set; }
        public string domain_key { get; set; }
        public string name { get; set; }
        public SocialNetworkLinks social_links { get; set; }
        public string embedded_widget_link { get; set; }
        public string testimonials_product_link { get; set; }
    }
}
