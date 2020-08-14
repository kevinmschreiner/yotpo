using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Yotpo.Light.Models.Shared;

namespace Yotpo.Light.Models.Product
{
    public class PromotedListResponse
    {
        public List<PromotedListItem> products { get; set; }
        public ResponsePagination pagination { get; set; }
        public static PromotedListResponse from(Shared.ResponseEnvelope response)
        {
            if (response.pagination != null || response.products != null)
            {
                PromotedListResponse result = new PromotedListResponse();
                result.pagination = response.pagination;
                result.products = ((JArray)response.products).ToObject<List<PromotedListItem>>();
                return result;
            }
            return null;
        }
    }
}
