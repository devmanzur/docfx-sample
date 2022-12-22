namespace WeatherApi.Models;

public class WeatherForecast
{
    /// <summary>
    /// Date the weather forecast is generated for
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Temperature value in celsius
    /// </summary>
    public int TemperatureCelsius { get; set; }
    /// <summary>
    /// Temperature value in fahrenheit
    /// </summary>
    public int TemperatureFahrenheit { get; set; }
    /// <summary>
    /// Text summary of weather
    /// </summary>
    public string? Summary { get; set; }
}