using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.ComponentModel.Design;
using System.Net.Http;
using System.Reflection;
using Yotpo.Light.Models.Shared;

namespace Yotpo.Light
{
    public class Base
    {
        
        private const string url = "https://api.yotpo.com/";
        private const string authurl = "oauth/token";
        private Models.Authentication.Response authentication;
        private string secretKey;
        private string appKey;
        public Base(string appKey, string secretKey) {
            this.appKey = appKey;
            this.secretKey = secretKey;
        }
        public string UToken { get { if (this.authentication != null) { return this.authentication.access_token; } return null; } }

        private System.Net.Http.HttpClient GetHttpClient() 
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", this.key);
            return client;
        }

        public Models.Shared.ResponseEnvelope Post(string url, object body)
        {
            if (this.Authenticate())
            {
                var client = this.GetHttpClient();
                if (client!=null)
                {
                    if (body is iAuthorizedRequest)
                    {
                        ((iAuthorizedRequest)body).utoken = this.UToken;
                    }

                    var result = client.PostAsJsonAsync(this.ApplyParameters(url), body).Result;
                    if (result != null)
                    {
                        var envelope = ResponseEnvelope.from(result);
                        if (envelope.status.code == 200)
                        {
                            return envelope;
                        } else
                        {
                            throw new EnvelopeException(envelope.status);
                        }
                    }
                }
            }
            return null;
        }

        public Models.Shared.ResponseEnvelope Put(string url, object body)
        {
            if (this.Authenticate())
            {
                var client = this.GetHttpClient();
                if (client != null)
                {
                    if (body is iAuthorizedRequest)
                    {
                        ((iAuthorizedRequest)body).utoken = this.UToken;
                    }

                    var result = client.PutAsJsonAsync(this.ApplyParameters(url), body).Result;
                    if (result != null)
                    {
                        var envelope = ResponseEnvelope.from(result);
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
                var client = this.GetHttpClient();
                if (client != null)
                {
                    if (body is iAuthorizedRequest)
                    {
                        ((iAuthorizedRequest)body).utoken = this.UToken;
                    }

                    var httpReq = new HttpRequestMessage(HttpMethod.Delete, this.ApplyParameters(url));
                    httpReq.Content = new StringContent(JsonConvert.SerializeObject(body));
                    var result = client.SendAsync(httpReq).Result;
                    if (result != null)
                    {
                        var envelope = ResponseEnvelope.from(result);
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
                var client = this.GetHttpClient();
                if (client != null)
                {
                    var result = client.DeleteAsync(this.ApplyParameters(url)).Result;
                    if (result != null)
                    {
                        var envelope = ResponseEnvelope.from(result);
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
                var client = this.GetHttpClient();
                if (client != null)
                {
                    var result = client.GetAsync(this.ApplyParameters(url)).Result;
                    if (result != null)
                    {
                        var envelope = ResponseEnvelope.from(result);
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
                var client = this.GetHttpClient();
                if (client != null)
                {
                    var result = client.GetAsync(this.ApplyParameters(url)).Result;
                    if (result != null)
                    {
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
                    var response = client.PostAsJsonAsync(authurl, request).Result;
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
    }
}
