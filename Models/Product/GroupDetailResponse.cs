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
    public class GroupDetailResponse
    {
        public ProductGroupDetail products_group { get; set; }
        public static GroupDetailResponse from(Shared.ResponseEnvelope response)
        {
            if (response.response != null)
            {
                GroupDetailResponse result = ((JObject)response.response).ToObject<GroupDetailResponse>();
                return result;
            }
            return null;
        }
    }
}
