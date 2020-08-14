using System;
using System.Collections.Generic;
using System.Text;

namespace Yotpo.Light.Models.Order
{
    public class Purchase
    {
        public Int64 order_line_id { get; set; }
        public Int64 product_id { get; set; }
        public string user_email { get; set; }
        public string user_name { get; set; }
        public string order_id { get; set; }
        public string product_sku { get; set; }
        public string product_name { get; set; }
        public string product_url { get; set; }
        public string order_date { get; set; }
        public string product_description { get; set; }
        public string created_at { get; set; }
    }
}
