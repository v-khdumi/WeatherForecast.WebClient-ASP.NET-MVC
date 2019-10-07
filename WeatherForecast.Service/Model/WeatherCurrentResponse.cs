using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Service.Model
{
    public class WeatherCurrentResponse
    {
        public WeatherInfo[] Weather { get; set; }
        public MainInfo Main { get; set; }
        public WindInfo Wind { get; set; }
        public CountryInfo Sys { get; set; }
        public string Name { get; set; }
    }
}
