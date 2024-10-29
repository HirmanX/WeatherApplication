using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Data.Service;
using WeatherApplication.Data.Service.Weather;

namespace WeatherApplication.Data.Repository
{
    public interface IWeatherRepository
    {
        List<City> GetCity(string name);
        WeatherResponse GetWeather(double lat, double lon);
    }
}
