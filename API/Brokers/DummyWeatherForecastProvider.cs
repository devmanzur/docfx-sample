using API.Interfaces;
using API.Models;

namespace API.Brokers;

public class DummyWeatherForecastProvider : IWeatherForecastProvider
{
    public IEnumerable<WeatherForecast> GetForecasts(DateTime from, DateTime to)
    {
        if (to == default || from == default || to < from)
        {
            throw new ArgumentException("Invalid date range");
        }

        var days = (to - from).Days;
        var baseTemperature = GenerateRandomTemperatureInCelsius();

        for (var i = 0; i < days; i++)
        {
            var celsius = baseTemperature + GenerateRandomSlightDeviation();
            yield return new WeatherForecast()
            {
                Date = from.AddDays(i).Date,
                TemperatureCelsius = celsius,
                TemperatureFahrenheit = ConvertCelsiusToFahrenheit(celsius),
                Summary = GetTemperatureSummary(celsius)
            };
        }
    }

    private static int ConvertCelsiusToFahrenheit(int temperatureInCelsius)
    {
        return 32 + (int)(temperatureInCelsius * (9 / 5));
    }

    private static int GenerateRandomTemperatureInCelsius()
    {
        return Random.Shared.Next(-20, 55);
    }

    private static int GenerateRandomSlightDeviation()
    {
        return Random.Shared.Next(-5, 5);
    }

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