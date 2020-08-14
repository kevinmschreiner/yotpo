using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Review
{
    public class Review
    {
        public Int64 id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int score { get; set; }
        public int votes_up { get; set; }
        public int votes_down { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public bool deleted { get; set; }
    }
}
