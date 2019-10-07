using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Service.Model
{
    public class ForecastInfo
    {
        public MainInfo Main { get; set; }
        public WeatherInfo[] Weather { get; set; }
        public string Dt_txt { get; set; }

    }
}
