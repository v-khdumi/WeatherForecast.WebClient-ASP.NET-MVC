using Ninject.Modules;
using WeatherForecast.Service;

namespace WeatherForecast.Web.IoC
{
    public class NinjectRejistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IOpenWeatherMapService>().To<OpenWeatherMapService>();
        }
    }
}