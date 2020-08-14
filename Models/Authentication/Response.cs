using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Yotpo.Light.Models.Authentication
{
    public class Response
    {
        public string access_token { get; set; }
        public string token_type { get; set; }

        public string error { get; set; }

        public static Response from(HttpResponseMessage value)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(value.Content.ReadAsStringAsync().Result);
        }
    }
}
