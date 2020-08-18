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

        protected class ActualResponseEnvelop
        {
            public ResponseStatus status { get; set; }
            public object response { get; set; }
            public ResponsePagination pagination { get; set; }
            public object products { get; set; }

            public int? code { get; set; }
            public string message { get; set; }
        }

        public static ResponseEnvelope from(HttpResponseMessage response)
        {
            var r = JsonConvert.DeserializeObject<ActualResponseEnvelop>(response.Content.ReadAsStringAsync().Result);
            var ar = new ResponseEnvelope();
            ar.status = r.status;
            ar.response = r.response;
            ar.pagination = r.pagination;
            ar.products = r.products;
            if (ar.status==null && r.code!=null)
            {
                ar.status = new ResponseStatus();
                ar.status.code = r.code.Value;
                ar.status.message = r.message;
            }
            return ar;
        }
    }

}
