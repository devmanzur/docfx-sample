using WeatherApi.Interfaces;
using WeatherApi.Models;

namespace WeatherApi.Brokers;

public class DummyWeatherForecastProvider : IWeatherForecastProvider
{
    /// <summary>
    /// Returns weather forecast for the requested date range
    /// </summary>
    /// <param name="from">Starting date</param>
    /// <param name="to">Ending date</param>
    /// <exception cref="ArgumentException">Thrown when the given starting date is in past, or after the ending date or either dates are set to default date</exception>
    public IEnumerable<WeatherForecast> GetForecasts(DateTime from, DateTime to)
    {
        if (to < DateTime.UtcNow.Date || to == default || from == default || to < from)
        {
            throw new ArgumentException("Invalid date range");
        }

        var days = (to - from).Days;
        var baseTemperature = GenerateRandomTemperatureInCelsius();

        for (var i = 0; i <= days; i++)
        {
            var celsius = baseTemperature + GenerateRandomSlightDeviation();
            yield return new WeatherForecast()
            {
                Date = from.AddDays(i).Date,
                TemperatureCelsius = celsius,
                TemperatureFahrenheit = (int)ConvertCelsiusToFahrenheit(celsius),
                Summary = GetTemperatureSummary(celsius)
            };
        }
    }

    /// <summary>
    /// Converts celsius value to fahrenheit
    /// </summary>
    /// <param name="temperatureInCelsius">temperature value in celsius</param>
    /// <returns>converted fahrenheit value</returns>
    private static double ConvertCelsiusToFahrenheit(int temperatureInCelsius)
    {
        return temperatureInCelsius * 1.8 + 32;
    }

    /// <summary>
    /// Generates random temperature value in celsius
    /// </summary>
    /// <returns>Random temperature value</returns>
    private static int GenerateRandomTemperatureInCelsius()
    {
        return Random.Shared.Next(-20, 55);
    }

    /// <summary>
    /// Generates slight deviation values, that make the data look more realistic
    /// </summary>
    /// <returns>Random number between -5 and 5</returns>
    private static int GenerateRandomSlightDeviation()
    {
        return Random.Shared.Next(-5, 5);
    }

    /// <summary>
    /// Returns text summary for given temperature value
    /// </summary>
    /// <param name="temperature"></param>
    /// <returns>text summarizing the temparature</returns>
    private static string GetTemperatureSummary(int temperature)
    {
        return temperature switch
        {
            < -5 => "Freezing",
            < -1 => "Chilly",
            < 7 => "Cool",
            < 15 => "Mild",
            < 25 => "Warm",
            < 35 => "Hot",
            < 45 => "Sweltering",
            _ => "Scorching"
        };
    }
}