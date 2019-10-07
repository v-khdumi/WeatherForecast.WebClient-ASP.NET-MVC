using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Service.Model
{
    public class MainInfo
    {
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public double Temp_min { get; set; }
        public double Temp_max { get; set; }
        public double Humidity { get; set; }
    }
}
