using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MgNetcoreCsSample.Models;

namespace MgNetcoreCsSample.Core
{
    public class RestApiSender
    {
        public const string JWT_BEARER_SCHEME = "Bearer";
        private readonly HttpClient client;

        public RestApiSender()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> SendPostRequestAsync(MtRequest mt, string baseUrl)
        {
            try
            {
                var resp = await client.PostAsJsonAsync(baseUrl, mt);
                return resp;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        public async Task<HttpResponseMessage> SendGetRequestAsync(string url)
        {
            try
            {
                var resp = await client.GetAsync(url);
                return resp;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}