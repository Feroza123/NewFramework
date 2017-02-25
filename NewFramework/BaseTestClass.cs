using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewFramework.Helper;
using NewFramework.Interfaces;
using NUnit.Framework;

namespace NewFramework
{
    public abstract class BaseTestClass
    {
        private string weatherBaseUrl, getWeatherEndPoint;

        public Dictionary<string, string> CommonHeaders { get; set; }

        protected abstract void DoSetUp();
        protected string GetWeatherApiConfigurationUrl { get; set; }

        // Public protected variables
        protected string authorizationHeader;
        protected int CityId { get; set; }

        // Generic types: TAuthentication, ICity
        //private readonly IAuthentication authentication = new TAuthentication();
        //private readonly ICity city = new TCity();

        [SetUp]
        public void Initialize()
        {
            CommonHeaders = new Dictionary<string, string>
            {
                //{"Authorization", IAuthentication.GetAuthHeader()},
                {"Authorization", "78c6049258d78e9e11fbe618edae0eee"},
                {"Content-Type", "application/json"}
            };

            //CityId = city.GetCity();

            DoSetUp();
        }

        public void SetupGetWeatherUrl()
        {
            SetupBaseUrl();
            getWeatherEndPoint = SettingsHelper.GetValue<string>(settingName: "GetWeatherByCityNameEndPoint");

            GetWeatherApiConfigurationUrl = string.Concat(weatherBaseUrl, getWeatherEndPoint);

        }

        public void SetupBaseUrl()
        {
            weatherBaseUrl = SettingsHelper.GetValue<string>(settingName: "WeatherAPIBaseUrl");

        }
    }
}
