using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Review
{
    public class ReviewPagination
    {
        public Int64 page { get; set; }
        public Int64 per_page { get; set; }
        public Int64 total { get; set; }
    }
}
