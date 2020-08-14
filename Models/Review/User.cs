using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Review
{
    public class User
    {
        public Int64 id { get; set; }
        public string display_name { get; set; }
        public string slug { get; set; }
        public string social_image { get; set; }
        public bool is_social_connected { get; set; }
        public string bio { get; set; }
        public int score { get; set; }

        public List<Badge> badges { get; set; }
    }
}
