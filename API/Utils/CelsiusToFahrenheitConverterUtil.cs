namespace API.Utils;

public static class CelsiusToFahrenheitConverterUtil
{
    public static int ConvertCelsiusToFahrenheit(int temperatureInCelsius)
    {
        return 32 + (int)(temperatureInCelsius * (9 / 5));
    }

    public static int ConvertFahrenheitToCelsius(int temperatureInFahrenheit)
    {
        return (int)((temperatureInFahrenheit - 32) * 5 / 9);
    }
}