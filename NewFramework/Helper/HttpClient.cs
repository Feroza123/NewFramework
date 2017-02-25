using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace NewFramework.Helper
{
    public class HttpClient<TOutPut> where TOutPut : new()
    {
        private readonly string _apiUrl;
        private readonly Dictionary<string, string> _commonHeaders;
        private readonly RestClient _httpClient;
        private RestRequest httprequest;


        public HttpClient(string apiUrl, Dictionary<string, string> commonHeaders)
        {
            _apiUrl = apiUrl;
            _commonHeaders = commonHeaders;
            _httpClient = new RestClient(_apiUrl);

        }

        public IRestResponse<TOutPut> performRequest<TInput>(TInput requestPacket, Method httpMethod = Method.POST, Dictionary<string, string> headers = null)
        {
            httprequest = new RestRequest(httpMethod);
            httprequest.JsonSerializer = new RestJsonSerializer();

            // easily add HTTP Headers
            if (_commonHeaders != null)
            {
                foreach (var header in _commonHeaders)
                {
                    httprequest.AddHeader(header.Key, header.Value);
                }
            }

            // easily add HTTP Headers
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httprequest.AddHeader(header.Key, header.Value);
                }

            }

            httprequest.AddJsonBody(requestPacket);

            var response = _httpClient.Execute<TOutPut>(httprequest);
            return response;

        }

        public IRestResponse<TOutPut> performGetRequestQueryString(string name, string value, Method httpMethod = Method.GET, Dictionary<string, string> headers = null)
        {
            httprequest = new RestRequest(httpMethod);

            // easily add HTTP Headers
            foreach (var header in _commonHeaders)
            {
                httprequest.AddHeader(header.Key, header.Value);
            }

            // easily add HTTP Headers
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httprequest.AddHeader(header.Key, header.Value);
                }

            }

            httprequest.AddQueryParameter(name, value);

            var response = _httpClient.Execute<TOutPut>(httprequest);
            return response;

        }

        public IRestResponse<TOutPut> performGetRequestQueryString(Dictionary<string, string> kvp, Method httpMethod = Method.GET, Dictionary<string, string> headers = null)
        {
            httprequest = new RestRequest(httpMethod);

            // easily add HTTP Headers
            foreach (var header in _commonHeaders)
            {
                httprequest.AddHeader(header.Key, header.Value);
            }

            // easily add HTTP Headers
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httprequest.AddHeader(header.Key, header.Value);
                }

            }

            foreach (var item in kvp)
            {
                httprequest.AddQueryParameter(item.Key, item.Value);
            }


            var response = _httpClient.Execute<TOutPut>(httprequest);
            return response;

        }

        public IRestResponse<TOutPut> performRequest(string requestPacket, Method httpMethod = Method.POST, Dictionary<string, string> headers = null)
        {
            httprequest = new RestRequest(httpMethod);

            // easily add HTTP Headers
            foreach (var header in _commonHeaders)
            {
                httprequest.AddHeader(header.Key, header.Value);
            }

            // easily add HTTP Headers
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httprequest.AddHeader(header.Key, header.Value);
                }

            }

            httprequest.AddJsonBody(requestPacket);

            var response = _httpClient.Execute<TOutPut>(httprequest);
            return response;

        }

        public IRestResponse<TOutPut> performRequest(Method httpMethod = Method.GET, Dictionary<string, string> headers = null)
        {
            httprequest = new RestRequest(httpMethod);

            // easily add HTTP Headers
            foreach (var header in _commonHeaders)
            {
                httprequest.AddHeader(header.Key, header.Value);
            }

            // easily add HTTP Headers
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httprequest.AddHeader(header.Key, header.Value);
                }

            }

            var response = _httpClient.Execute<TOutPut>(httprequest);
            return response;

        }

        public Task<IRestResponse<TOutPut>> performRequestAsync<TInput>(TInput requestPacket, Method httpMethod = Method.POST, Dictionary<string, string> headers = null)
        {

            httprequest = new RestRequest(httpMethod);

            // easily add HTTP Headers
            foreach (var header in _commonHeaders)
            {
                httprequest.AddHeader(header.Key, header.Value);
            }

            // easily add HTTP Headers
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httprequest.AddHeader(header.Key, header.Value);
                }

            }

            httprequest.AddJsonBody(requestPacket);

            var taskResult = _httpClient.ExecuteTaskAsync<TOutPut>(httprequest);

            return taskResult;

        }
    }
}
