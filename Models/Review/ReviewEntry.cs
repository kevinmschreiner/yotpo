using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Review
{
    public class ReviewEntry:Review
    {
        public decimal sentiment { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string reviewer_type { get; set; }
        public object user_reference { get; set; }
    }
}
