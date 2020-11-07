using CoreMVCClient.Helper;
using CoreMVCClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CoreMVCClient.HttpClients
{
    /// <summary>
    /// This class exposes RESTful CRUD functionality in a generic way, abstracting
    /// the implementation and useage details of HttpClient, HttpRequestMessage,
    /// HttpResponseMessage, ObjectContent, Formatters etc. 
    /// </summary>
    /// <typeparam name="T">This is the Type of Resource you want to work with, such as Customer, Order etc.</typeparam>
    /// <typeparam name="TResourceIdentifier">This is the type of the identifier that uniquely identifies a specific resource such as Id or Username etc.</typeparam>
    public class GenericRestfulCrudHttpClient<T, TResourceIdentifier> : IDisposable where T : class
    {
        private bool disposed = false;
        private HttpClient httpClient;
        protected readonly string serviceBaseAddress;
        private readonly string addressSuffix;
        private readonly string jsonMediaType = "application/json";

        /// <summary>
        /// The constructor requires two parameters that essentially initialize the underlying HttpClient.
        /// In a RESTful service, you might have URLs of the following nature (for a given resource - Member in this example):<para />
        /// 1. http://www.somedomain/api/members/<para />
        /// 2. http://www.somedomain/api/members/jdoe<para />
        /// Where the first URL will GET you all members, and allow you to POST new members.<para />
        /// While the second URL supports PUT and DELETE operations on a specifc member.
        /// </summary>
        /// <param name="serviceBaseAddress">As per the example, this would be "http://www.somedomain"</param>
        /// <param name="addressSuffix">As per the example, this would be "api/members/"</param>

        public GenericRestfulCrudHttpClient(string serviceBaseAddress, string addressSuffix)
        {
            this.serviceBaseAddress = serviceBaseAddress;
            this.addressSuffix = addressSuffix;
            httpClient = MakeHttpClient(serviceBaseAddress);
        }

        protected virtual HttpClient MakeHttpClient(string serviceBaseAddress)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(serviceBaseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(jsonMediaType));
            httpClient.DefaultRequestHeaders.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("gzip"));
            httpClient.DefaultRequestHeaders.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("defalte"));
            httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue("Matlus_HttpClient", "1.0")));
            return httpClient;
        }

        public async Task<IEnumerable<T>> GetManyAsync()
        {
            var ApiUrl = FillApiAddress(Constants.GetProjectsService, serviceBaseAddress, null);

            var response = await httpClient.GetAsync(ApiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<T>>(responseBody);
            }
            throw new Exception(response.ReasonPhrase);
        }

        public async Task<T> GetAsync(TResourceIdentifier identifier)
        {
            var responseMessage = await httpClient.GetAsync(addressSuffix + identifier.ToString());
            responseMessage.EnsureSuccessStatusCode();
            string responseBody = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseBody);
        }

        public async Task<T> PostAsync(T model)
        {
            var requestMessage = new HttpRequestMessage();
            var objectContent = Extensions.AsJson(model);

            var ApiUrl = FillApiAddress(Constants.PostProjectsService, serviceBaseAddress,null);

            var responseMessage = await httpClient.PostAsJsonAsync<T>(ApiUrl, model);

            return await responseMessage.Content.ReadAsAsync<T>();
        }

        public async Task PutAsync(TResourceIdentifier identifier, T model)
        {
            var requestMessage = new HttpRequestMessage();
            var objectContent = Extensions.AsJson(model);
            var responseMessage = await httpClient.PutAsync(addressSuffix + identifier.ToString(), objectContent);
        }

        public async Task DeleteAsync(TResourceIdentifier identifier)
        {
            var r = await httpClient.DeleteAsync(addressSuffix + identifier.ToString());
        }

        //private ObjectContent CreateJsonObjectContent(T model)
        //{
        //    var requestMessage = new HttpRequestMessage();
        //    return requestMessage.CreateResponse<T>(
        //        model,
        //        MediaTypeHeaderValue.Parse(jsonMediaType),
        //        new MediaTypeFormatter[] { new JsonMediaTypeFormatter() },
        //        new FormatterSelector());
        //}

        private string FillApiAddress(string url, string _baseUri, string objectContent)
        {
            string Url = string.Empty;

            if(objectContent!=null)
            {
                 Url = string.Format(url, _baseUri);
                Url += "?project=" + objectContent?.ToString();
                return Url;
            }
            else
            {
                Url = string.Format(url, _baseUri);
                // Url += "?project=" + objectContent?.ToString();
                return Url;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                if (httpClient != null)
                {
                    var hc = httpClient;
                    httpClient = null;
                    hc.Dispose();
                }
                disposed = true;
            }
        }

        #endregion IDisposable Members
    }
}
