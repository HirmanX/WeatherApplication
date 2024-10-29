using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Data.Repository;
using WeatherApplication.Data.Service.Weather;

namespace WeatherApplication.Data.Service
{
    public class WeatherRepository : IWeatherRepository
    {
        private string _key;

        private string _ciryUrl = @"http://api.openweathermap.org/geo/1.0/direct?q={city name}&limit=1&appid={API key}";
        private string _weatherUrl = @"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric&appid={API key}";

        public WeatherRepository(string key)
        {
            _key = key;
        }

        public List<City> GetCity(string name)
        {
            string url = (_ciryUrl.Replace("{city name}", $"{name}")).Replace("{API key}", $"{_key}");
            using(var client = new HttpClient())
            {
                var result = client.GetStringAsync(url).Result;
                var city = JsonConvert.DeserializeObject<List<City>>(result);
                return city;
            }       
        }

        public WeatherResponse GetWeather(double lat, double lon)
        {
            string url = ((_weatherUrl.Replace("{lat}", $"{lat}")).Replace("{lon}", $"{lon}")).Replace("{API key}", $"{_key}");
            using (var client = new HttpClient())
            {
                var result = client.GetStringAsync(url).Result;
                var weather = JsonConvert.DeserializeObject<WeatherResponse>(result);
                return weather;
            }
        }
        
    }
}
