using CityWeather.Model;
using Microsoft.AspNetCore.Mvc;

namespace CityWeather.Controllers
{
    public class WeatherController : Controller
    {
        List<WeatherCity> cityWeather = new List<WeatherCity>()
            {
                new WeatherCity { CityUniqueCode = "LDN", CityName = "London", DateAndTime = new DateTime(2030,01,01,8,00,00), TemperatureFah = 33 },
                new WeatherCity { CityUniqueCode = "NYC", CityName = "New York City", DateAndTime = new DateTime(2030,01,01,8,00,00), TemperatureFah = 60 },
                new WeatherCity { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = new DateTime(2030,01,01,8,00,00), TemperatureFah = 82 }
            };
        [Route("/")]
        public IActionResult Index(string cityCode)
        {
            return View(cityWeather);
        }
        [Route("/weather/{cityCode}")]
        public IActionResult City(string cityCode) {
            if (string.IsNullOrEmpty(cityCode))
                return View();

                WeatherCity? cityQuery = cityWeather.Where(c => c.CityUniqueCode == cityCode).FirstOrDefault();
                if (cityQuery == null)
                {
                    ViewData["error"] = "This is not a valid city code";
                    ControllerContext.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    return View();
                }
            return View(cityQuery);
        }
    }
            
}

