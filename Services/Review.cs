using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Yotpo.Light.Models.Review;

namespace Yotpo.Light.Services
{
    public class Review : Base
    {
        public Review(string appKey, string secretKey) : base(appKey, secretKey) { }

        public bool Add(AddRequest request)
        {
            var result = base.Post("v1/widget/reviews", request);
            if (result.status.code == 200) return true;
            return false;
        }

        public Models.Review.AddResponse AddSynchronous(AddRequest request)
        {
            var result = base.Post("reviews/dynamic_create", request);
            if (result.status.code == 200)
            {
                return ((JObject)result.response).ToObject<Models.Review.AddResponse>();
            }
            return null;
        }

        public VoteResponse Vote(string review_id, string vote_type, bool undo=false)
        {
            var result = base.Post("reviews/"+review_id+"/vote/"+vote_type+(undo?"/true":""), new Models.Shared.AuthorizedRequest());
            if (result.status.code == 200)
            {
                return ((JObject)result.response).ToObject<Models.Review.VoteResponse>();
            }
            return null;
        }

        public ReviewListResponse Retrieve(int? count = null, int? page = null)
        {
            string url = "v1/apps/{{APPKEY}}/reviews?utoken={{UTOKEN}}";
            if (count != null) url += "&count=" + count.Value.ToString();
            if (page != null) url += "&page=" + page.Value.ToString();

            return ReviewListResponse.from(base.GetContent(url));
        }

        public ViewResponse Retrieve_ById(string reviewid)
        {
            string url = "reviews/"+ reviewid + "?utoken={{UTOKEN}}";
            var result = base.Get(url);
            if (result.status.code == 200)
            {
                return ((JObject)result.response).ToObject<Models.Review.ViewResponse>();
            }
            return null;
        }

        public PaginatedResponse Retrieve_ByProduct(string product, int? count = null, int? page = null)
        {
            string url = "v1/widget/{{APPKEY}}/products/"+product+"/reviews.json?utoken={{UTOKEN}}";
            if (count != null) url += "&per_page=" + count.Value.ToString();
            if (page != null) url += "&page=" + page.Value.ToString();

            var result = base.Get(url);
            if (result.status.code == 200)
            {
                return ((JObject)result.response).ToObject<Models.Review.PaginatedResponse>();
            }
            return null;
        }

        public ReviewByUserResponse Retrieve_ByUser(string user, int? count = null, int? page = null)
        {
            string url = "products/{{APPKEY}}/yotpo_global_reviews/reviews.json?user_reference="+user+"&utoken={{UTOKEN}}";
            if (count != null) url += "&per_page=" + count.Value.ToString();
            if (page != null) url += "&page=" + page.Value.ToString();

            var result = base.Get(url);
            if (result.status.code == 200)
            {
                return ((JObject)result.response).ToObject<Models.Review.ReviewByUserResponse>();
            }
            return null;
        }

        public PaginatedResponse Retrieve_ForSite(int? count = null, int? page = null)
        {
            string url = "v1/widget/{{APPKEY}}/products/yotpo_site_reviews/reviews.json?utoken={{UTOKEN}}";
            if (count != null) url += "&per_page=" + count.Value.ToString();
            if (page != null) url += "&page=" + page.Value.ToString();

            var result = base.Get(url);
            if (result.status.code == 200)
            {
                return ((JObject)result.response).ToObject<Models.Review.PaginatedResponse>();
            }
            return null;
        }

        public BottomLineResponse Retrieve_BottomLine_ByProduct(string product)
        {
            string url = "products/{{APPKEY}}/"+product+"/bottomline?utoken={{UTOKEN}}";
            var result = base.Get(url);
            if (result.status.code == 200)
            {
                return ((JObject)result.response).ToObject<Models.Review.BottomLineResponse>();
            }
            return null;
        }

        public BottomLinesResponse Retrieve_BottomLines(int? count = null, int? page = null)
        {
            string url = "v1/apps/{{APPKEY}}/bottom_lines?utoken={{UTOKEN}}";
            if (count != null) url += "&count=" + count.Value.ToString();
            if (page != null) url += "&page=" + page.Value.ToString();
            var result = base.Get(url);
            if (result.status.code == 200)
            {
                return ((JObject)result.response).ToObject<Models.Review.BottomLinesResponse>();
            }
            return null;
        }

        public BottomLineResponse Retrieve_BottomLine()
        {
            string url = "products/{{APPKEY}}/yotpo_site_reviews/bottomline?utoken={{UTOKEN}}";
            var result = base.Get(url);
            if (result.status.code == 200)
            {
                return ((JObject)result.response).ToObject<Models.Review.BottomLineResponse>();
            }
            return null;
        }
    }
}
