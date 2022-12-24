//using DataBaseEf;
//using DataBaseEf.Model;
using DataBaseEf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Repository;
using Servises.Interface;

namespace LinkShorteningService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        /*private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };*/

        /*public HomeController(IOptions<MyConfig> config)
        {
            this.config = config;
        }*/

        //private readonly ILogger<WeatherForecastController> _logger;
        private IServiseLinkStorage _servise;

        public WeatherForecastController(IServiseLinkStorage servise)
        {
            _servise = servise;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IList<Repository.Model.LinkStorageBaseModel> Get()
        {
            //_servise.SaveToRepo(null);
            _servise.GetModels();
            return _servise.GetModels();
            
        }
    }
}