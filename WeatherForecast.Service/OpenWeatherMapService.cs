using Newtonsoft.Json;
using System.IO;
using System.Net;
using System;
using WeatherForecast.Service.Model;
using System.Collections.Generic;

namespace WeatherForecast.Service
{
    public class OpenWeatherMapService : IOpenWeatherMapService
    {
        // General method which send two model to controller 
        // (First model - current weather info and second model - weather forecast for nearest 5 days)
        public Tuple<WeatherCurrentResponse, List<ForecastInfo>> GetWeatherInfo(string city)
        {
            WeatherCurrentResponse weatherCurrentResponse = GetCurrentWeather(city);

            List<ForecastInfo> weatherForecastResponse = null;

            if (weatherCurrentResponse != null)
            {
                weatherForecastResponse = GetWeatherForecastFor5Days(city, weatherCurrentResponse.Sys.Country);
            }
            else
            {
                return null;
            }

            return Tuple.Create(weatherCurrentResponse, weatherForecastResponse);
        }

        public WeatherCurrentResponse GetCurrentWeather(string city)
        {
            // String url address to our weather api
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&units=metric&appid=5c6f05c93a1ad6bda0ce9271cde5ec7f";

            // Create request object
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            // Create response object
            HttpWebResponse httpWebResponse;
            try
            {
                 httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch
            {
                return null;
            }

            string response;

            //Read all datas from out httpWebresponse object
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            // Deserialize API response - json to object
            WeatherCurrentResponse weatherResponse = JsonConvert.DeserializeObject<WeatherCurrentResponse>(response);

            return weatherResponse;
        }
        
        public List<ForecastInfo> GetWeatherForecastFor5Days(string city, string country)
        {
            // String url address to our weather api
            string url = "http://api.openweathermap.org/data/2.5/forecast?q=" + city + "," + country + "&units=metric&appid=5c6f05c93a1ad6bda0ce9271cde5ec7f";

            // Create request object
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            // Create response object
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            //Read all datas from out httpWebresponse object
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            // Deserialize API response - json to object
            var weatherForecastResponse = JsonConvert.DeserializeObject<WeatherForecastResponse>(response);

            // Create final result with only necessary average day info, not every 3 hours per day 
            List<ForecastInfo> result = new List<ForecastInfo>();

            var dateNow = DateTime.Now.ToString("dd.MM.yyyy");
            foreach (var item in weatherForecastResponse.List)
            {
                if ((item.Dt_txt).ToString().Substring(0, 10) != dateNow 
                    && (item.Dt_txt).ToString().Substring(11, 8) == "12:00:00")
                {
                    result.Add(item);
                }
            }

            if(result.Count == 5)
            {
                result.RemoveAt(4);
            }

            return result;
        }
    }
}
