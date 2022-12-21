using API.Models;

namespace API.Interfaces;

public interface IWeatherForecastProvider
{
    IEnumerable<WeatherForecast> GetForecasts(DateTime from, DateTime to);
}