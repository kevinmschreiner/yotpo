using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Product
{
    public class PromotedListItem
    {
        public Int64 products_app_id { get; set; }
        public string url { get; set; }
        public decimal price { get; set; }
        public string currency { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int position { get; set; }


        public string domain_key { get; set; }
        public string image_title { get; set; }
        public decimal average_score { get; set; }
        public int total_review { get; set; }
        
        public string image { get; set; }
        
      
    }
}
