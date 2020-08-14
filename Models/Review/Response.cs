using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Yotpo.Light.Models.Review
{
    public class Response:Review
    {
        public Models.Review.User user { get; set; }
        public string user_type { get; set; }
        //public users
        public List<Models.Review.ProductList> products { get; set; }
        public int user_vote { get; set; }

        [JsonProperty("new")]
        public bool isNew  { get; set; }
        public bool verified_buyer { get; set; }
        public bool archived { get; set; }
        public bool social_pushed { get; set; }
        public int facebook_pushed { get; set; }
        public int twitter_pushed { get; set; }
        public Models.Review.Account account { get; set; }
        public List<Models.Review.ProductApp> products_apps { get; set; }
    }
}
