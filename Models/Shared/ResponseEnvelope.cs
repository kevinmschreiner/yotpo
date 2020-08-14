using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Yotpo.Light.Models.Shared
{
    public class ResponseEnvelope
    {
        public ResponseStatus status { get; set; }   
        public object response { get; set; }
        public ResponsePagination pagination { get; set; }
        public object products { get; set; }

        public static ResponseEnvelope from(HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<ResponseEnvelope>(response.Content.ReadAsStringAsync().Result);
        }
    }
    
}
