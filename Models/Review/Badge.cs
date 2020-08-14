using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Review
{
    public class Badge
    {
        public Int64 id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image_100 { get; set; }
        public string image_300 { get; set; }
    }
}
