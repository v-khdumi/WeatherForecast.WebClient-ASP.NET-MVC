using System.Web.Mvc;
using WeatherForecast.Service;

namespace WeatherForecast.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOpenWeatherMapService _openWeatherMapService;

        public HomeController(IOpenWeatherMapService openWeatherMapService)
        {
            _openWeatherMapService = openWeatherMapService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetWeatherByCity(string city)
        {
            var weatherInfo = _openWeatherMapService.GetWeatherInfo(city);

            return PartialView("WeatherPartialView", weatherInfo);
        }
    }
}