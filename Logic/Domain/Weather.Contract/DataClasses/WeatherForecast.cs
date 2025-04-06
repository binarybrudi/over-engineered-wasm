namespace Diamond.Logic.Domain.Weather.Contract.DataClasses;

public class WeatherForecast
{
    public DateTimeOffset DateTime { get; set; }
    public double Temperature { get; set; }
}