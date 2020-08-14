using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Review
{
    public class ReviewSummary : Review
    {
        public decimal sentiment { get; set; }
        public bool verified_buyer { get; set; }
        public Dictionary<string, string> custom_fields { get; set; }
        public object source_review_id { get; set; }
        public List<ReviewImage> images_data { get; set; }
        public Int64 product_id { get; set; }
        public ReviewUser user { get; set; }
    }
}
