using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NewFramework.Helper;
using NewFramework.Models;
using NUnit.Framework;
using RestSharp;

namespace NewFramework
{
    public class GetCityByName : BaseTestClass 
    {
        private static HttpClient<GetWeatherByCityRequestModel> httpClient;
        protected override void DoSetUp() { }

        [Test]
        public void GetWeather()
        {
            SetupGetWeatherUrl();
            var apiResponse = GetWeatherInformation(string.Format(GetWeatherApiConfigurationUrl, arg0: "", arg1: ""), CommonHeaders); 

            apiResponse = GetWeatherInformation(string.Format(GetWeatherApiConfigurationUrl, arg0: "London", arg1: "78c6049258d78e9e11fbe618edae0eee"), CommonHeaders);

            Assert.AreEqual(HttpStatusCode.OK, apiResponse.StatusCode);
        }


        private IRestResponse<GetWeatherByCityRequestModel> GetWeatherInformation(string url, Dictionary<string, string> headers)
        {
            httpClient = new HttpClient<GetWeatherByCityRequestModel>(url, headers);

            var packet = new { };

            IRestResponse<GetWeatherByCityRequestModel> apiResponse = httpClient.performRequest(packet, Method.GET);

            return apiResponse;
        }
    }
}
