using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastProvider _weatherForecastProvider;

    public WeatherForecastController(IWeatherForecastProvider weatherForecastProvider)
    {
        _weatherForecastProvider = weatherForecastProvider;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult<IEnumerable<WeatherForecast>> Get([FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        try
        {
            if (from == null || to == null || to < from)
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