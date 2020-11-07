using CoreMVCClient.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CoreMVCClient.HttpClients
{
    public class RestClient : HttpClient
    {
        string _baseUri = string.Empty;
        /// <summary>
        /// http://dotnetblogpost.com/2017/11/22/csharp-httpclient-utility-class-calling-web-api/
        /// </summary>
        public RestClient()
        {
            _baseUri = Environment.GetEnvironmentVariable("baseUri");
        }
        public async Task<T> GetAsync<T>(string url)
        {
           // await SetTokenAsync();
            DefaultRequestHeaders.Clear();
            DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() { NoCache = true };
            //  DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token.AccessToken);

            var ApiUrl = FillApiAddress(Constants.GetProjectsService,_baseUri);

            using (HttpResponseMessage response = await GetAsync(_baseUri + url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(responseBody);
                }
                throw new Exception(response.ReasonPhrase);
            }
        }

        private string FillApiAddress(string url, string _baseUri)
        {
            var Url = string.Format(url, _baseUri);
           /// Url += "?RequestTime=" + RequestTime.ToString();
            return Url;
        }
    }
    
}
