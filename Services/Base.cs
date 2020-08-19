using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using Yotpo.Light.Models.Authentication;
using Yotpo.Light.Models.Shared;

namespace Yotpo.Light
{
    public interface iLogHandler
    {
        string Identifier { get; set; }
        void Handle(string method, Dictionary<string, string> headers, string url, string body, int code, string response);
    }
    public class Base
    {
        private class YotpoLogEntry
        {
            public string method;
            public string url;
            private StringContent _body;
            private string _content;
            public StringContent body { set { _body = value; _content = value.ReadAsStringAsync().Result; } get { return _body; } }
            
            public string content { get { return _content; } }
            public string response;
            public int code;
            public Dictionary<string, string> headers = new Dictionary<string, string>();

            public YotpoLogEntry(string method)
            {
                this.method = method;
            }
        }
        private const string url = "https://api.yotpo.com/";
        private const string authurl = "oauth/token";
        private Models.Authentication.Response authentication;
        private string secretKey;
        private string appKey;
        
        public Base(string appKey, string secretKey) {
            this.appKey = appKey;
            this.secretKey = secretKey;
        }

        private Dictionary<string, iLogHandler> loghandlers = null;
        public void Attach(iLogHandler logHandler)
        {
            if (this.loghandlers == null) loghandlers = new Dictionary<string, iLogHandler>();
            if (!this.loghandlers.ContainsKey(logHandler.Identifier)) this.loghandlers.Add(logHandler.Identifier, logHandler);
            else this.loghandlers[logHandler.Identifier] = logHandler;
        }
        public void Detach(iLogHandler logHandler)
        {
            if (this.loghandlers != null)
            {
                if (this.loghandlers.ContainsKey(logHandler.Identifier)) this.loghandlers.Remove(logHandler.Identifier);
                if (this.loghandlers.Count == 0) this.loghandlers = null;
            }
        }
        private void Log_Request(YotpoLogEntry value)
        {
            if (this.loghandlers != null)
            {
                foreach (var handler in this.loghandlers.Values)
                {
                    try
                    {
                        handler.Handle(value.method, value.headers, value.url, value.content, value.code, value.response);
                    } catch(Exception ex)
                    {
                        //ignore, we dont care if the handler breaks.
                    }
                }
            }
        }

        public string UToken { get { if (this.authentication != null) { return this.authentication.access_token; } return null; } }

        private System.Net.Http.HttpClient GetHttpClient(YotpoLogEntry request) 
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            request.headers.Add("Accept", "application/json");
            return client;
        }

        public Models.Shared.ResponseEnvelope Post(string url, object body)
        {
            if (this.Authenticate())
            {
                var entry = new YotpoLogEntry("POST");
                var client = this.GetHttpClient(entry);
                if (client!=null)
                {
                    if (body is iAuthorizedRequest)
                    {
                        ((iAuthorizedRequest)body).utoken = this.UToken;
                    }
                    entry.url = this.ApplyParameters(url);
                    entry.body = ToJsonPayload(body);
                    var result = client.PostAsync(entry.url,entry.body).Result;
                    if (result != null)
                    {
                        entry.code = (int)result.StatusCode;
                        entry.response = result.Content.ReadAsStringAsync().Result;
                        this.Log_Request(entry);

                        var envelope = ResponseEnvelope.from(entry.response);
                        if (envelope.status.code == 200)
                        {
                            return envelope;
                        } else
                        {
                            throw new EnvelopeException(envelope.status);
                        }
                    } else
                    {

                    }
                }
            }
            return null;
        }

        public Models.Shared.ResponseEnvelope Put(string url, object body)
        {
            if (this.Authenticate())
            {
                var entry = new YotpoLogEntry("PUT");
                var client = this.GetHttpClient(entry);
                if (client != null)
                {
                    if (body is iAuthorizedRequest)
                    {
                        ((iAuthorizedRequest)body).utoken = this.UToken;
                    }
                    entry.url = this.ApplyParameters(url);
                    entry.body = ToJsonPayload(body);

                    var result = client.PutAsync(entry.url,entry.body).Result;
                    if (result != null)
                    {
                        entry.code = (int)result.StatusCode;
                        entry.response = result.Content.ReadAsStringAsync().Result;
                        this.Log_Request(entry);

                        var envelope = ResponseEnvelope.from(entry.response);
                        if (envelope.status.code == 200)
                        {
                            return envelope;
                        }
                        else
                        {
                            throw new EnvelopeException(envelope.status);
                        }
                    }
                }
            }
            return null;
        }

        //this probably doesnt work - by definition the DELETE method does not support a content value...
        public ResponseEnvelope Delete(string url, object body)
        {
            if (this.Authenticate())
            {
                var entry = new YotpoLogEntry("DELETE");
                var client = this.GetHttpClient(entry);
                if (client != null)
                {
                    if (body is iAuthorizedRequest)
                    {
                        ((iAuthorizedRequest)body).utoken = this.UToken;
                    }
                    entry.url = this.ApplyParameters(url);
                    entry.body = ToJsonPayload(body);
                    var httpReq = new HttpRequestMessage(HttpMethod.Delete, entry.url);
                    httpReq.Content = entry.body;

                    var result = client.SendAsync(httpReq).Result;
                    if (result != null)
                    {
                        entry.code = (int)result.StatusCode;
                        entry.response = result.Content.ReadAsStringAsync().Result;
                        this.Log_Request(entry);

                        var envelope = ResponseEnvelope.from(entry.response);
                        if (envelope.status.code == 200)
                        {
                            return envelope;
                        }
                        else
                        {
                            throw new EnvelopeException(envelope.status);
                        }
                    }
                }
            }
            return null;
        }

        public ResponseEnvelope Delete(string url)
        {
            if (this.Authenticate())
            {
                var entry = new YotpoLogEntry("DELETE");
                var client = this.GetHttpClient(entry);
                if (client != null)
                {
                    entry.url = this.ApplyParameters(url);

                    var result = client.DeleteAsync(entry.url).Result;
                    if (result != null)
                    {
                        entry.code = (int)result.StatusCode;
                        entry.response = result.Content.ReadAsStringAsync().Result;
                        this.Log_Request(entry);

                        var envelope = ResponseEnvelope.from(entry.response);
                        if (envelope.status.code == 200)
                        {
                            return envelope;
                        }
                        else
                        {
                            throw new EnvelopeException(envelope.status);
                        }
                    }
                }
            }
            return null;
        }

        public Models.Shared.ResponseEnvelope Get(string url)
        {
            if (this.Authenticate())
            {
                var entry = new YotpoLogEntry("GET");
                var client = this.GetHttpClient(entry);
                if (client != null)
                {
                    entry.url = this.ApplyParameters(url);

                    var result = client.GetAsync(entry.url).Result;
                    if (result != null)
                    {
                        entry.code = (int)result.StatusCode;
                        entry.response = result.Content.ReadAsStringAsync().Result;
                        this.Log_Request(entry);

                        var envelope = ResponseEnvelope.from(entry.response);
                        if (envelope.status.code == 200)
                        {
                            return envelope;
                        }
                        else
                        {
                            throw new EnvelopeException(envelope.status);
                        }
                    }
                }
            }
            return null;
        }

        public HttpContent GetContent(string url)
        {
            if (this.Authenticate())
            {
                var entry = new YotpoLogEntry("GET");
                var client = this.GetHttpClient(entry);
                if (client != null)
                {
                    entry.url = this.ApplyParameters(url);

                    var result = client.GetAsync(entry.url).Result;
                    if (result != null)
                    {
                        entry.code = (int)result.StatusCode;
                        entry.response = result.Content.ReadAsStringAsync().Result;
                        this.Log_Request(entry);

                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            return result.Content;
                        } else
                        {
                            throw new EnvelopeException(new ResponseStatus() { code = (int)result.StatusCode, message = result.ReasonPhrase });
                        }
                    }
                }
            }
            return null;
        }


        private string ApplyParameters(string url)
        {
            if(!string.IsNullOrWhiteSpace(this.appKey)) return url.Replace("{{APPKEY}}", this.appKey).Replace("{{UTOKEN}}",this.authentication!=null?this.authentication.access_token:"");
            return url;
        }

        private bool Authenticate()
        {
            if (authentication==null)
            {
                using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var request = new Models.Authentication.Request() { client_id = this.appKey, client_secret = this.secretKey, grant_type = "client_credentials" };
                    var response = client.PostAsync(authurl, ToJsonPayload(request)).Result;
                    switch (response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            try
                            {
                                this.authentication = Models.Authentication.Response.from(response);
                                return true;
                            } catch(Exception ex)
                            {
                                throw new FormatException("The system was unable to convert the response to the valid authentication format", ex);
                            }
                            break;
                        case System.Net.HttpStatusCode.NotFound:
                            this.authentication = null;
                            throw new UnauthorizedAccessException();
                        default:
                            this.authentication = null;
                            throw new InvalidOperationException();
                    }
                    this.authentication = null;
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private StringContent ToJsonPayload(object data)
        {
            return new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
        }
    }
}
