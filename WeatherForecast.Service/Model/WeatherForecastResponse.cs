using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Service.Model
{
    public class WeatherForecastResponse
    {
        public ForecastInfo[] List { get; set; }
    }
}
