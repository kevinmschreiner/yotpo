using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotpo.Light.Models.Review
{
    public class ReviewByUserResponse
    {
        public UserBottomLine bottomline { get; set; }
        public List<Models.Review.Response> reviews { get; set; }
    }
}
