using Microsoft.AspNetCore.Mvc;
using WeatherApi.Interfaces;
using WeatherApi.Models;

namespace WeatherApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastProvider _weatherForecastProvider;

    public WeatherForecastController(IWeatherForecastProvider weatherForecastProvider)
    {
        _weatherForecastProvider = weatherForecastProvider;
    }

    /// <summary>
    /// Returns list of weather forecast response
    /// </summary>
    /// <param name="from">Starting date</param>
    /// <param name="to">Ending date</param>
    /// <returns>list of weather forecast</returns>
    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult<IEnumerable<WeatherForecast>> Get([FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        try
        {
            if (from == null || to == null || to < from || to < DateTime.UtcNow.Date)
            {
                return ValidationProblem("Invalid date range");
            }

            var weatherForecasts = _weatherForecastProvider.GetForecasts(from.Value, to.Value);
            return Ok(weatherForecasts);
        }
        catch (ArgumentException e)
        {
            return ValidationProblem(e.Message);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
}