using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Review
{
    public class ReviewUser
    {
        public Int64 user_id { get; set; }
        public string display_name { get; set; }
        public string social_image { get; set; }
        public string user_type { get; set; }
        public int is_social_connected { get; set; }
    }
}
