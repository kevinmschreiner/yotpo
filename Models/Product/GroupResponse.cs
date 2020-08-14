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
    public class GroupResponse
    {
        public List<ProductGroup> products_groups { get; set; }
        public static GroupResponse from(Shared.ResponseEnvelope response)
        {
            if (response.response != null)
            {
                GroupResponse result = ((JObject)response.response).ToObject<GroupResponse>();
                return result;
            }
            return null;
        }
    }
}
