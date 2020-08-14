using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Review
{
    public class AddRequest
    {
        public string appkey { get; set; }
        public string domain { get; set; }
        public string sku { get; set; }
        public string product_title { get; set; }
        public string product_description { get; set; }
        public string product_url { get; set; }
        public string product_image_url { get; set; }
        public string display_name { get; set; }
        public string email { get; set; }
        public string review_content { get; set; }
        public string review_title { get; set; }
        public int review_score { get; set; }
        public string signature { get; set; }
        public string time_stamp { get; set; }
        public string reviewer_type { get; set; }
        public Order.Metadata order_metadata { get; set; }
        public Models.Product.Metadata product_metadata { get; set; }
        public Customer.Metadata customer_metadata { get; set; }

        public Dictionary<string,string> custom_fields { get; set; }

    }
}
