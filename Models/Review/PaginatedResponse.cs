using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yotpo.Light.Models.Shared;

namespace Yotpo.Light.Models.Review
{
    public class PaginatedResponse
    {
        public ReviewPagination pagination { get; set; }
        public BottomLine bottomline { get; set; }
        public List<Models.Review.ReviewProduct> products { get; set; }
        public List<Models.Review.ReviewSummary> reviews { get; set; }
    }
}
