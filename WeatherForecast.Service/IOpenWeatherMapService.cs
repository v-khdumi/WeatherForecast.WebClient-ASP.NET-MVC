using System;
using System.Collections.Generic;
using WeatherForecast.Service.Model;

namespace WeatherForecast.Service
{
    public interface IOpenWeatherMapService
    {
        Tuple<WeatherCurrentResponse, List<ForecastInfo>> GetWeatherInfo(string city);
        WeatherCurrentResponse GetCurrentWeather(string city);
        List<ForecastInfo> GetWeatherForecastFor5Days(string city, string country);
    }
}
