using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Yotpo.Light.Models.Shared;

namespace Yotpo.Light.Models.Review
{
    public class ReviewListResponse
    {
        public List<ReviewEntry> reviews { get; set; }

        public static ReviewListResponse from(HttpContent content)
        {
            return content.ReadAsAsync<ReviewListResponse>().Result;
        }
    }
}
