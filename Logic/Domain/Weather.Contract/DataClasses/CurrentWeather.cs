namespace Diamond.Logic.Domain.Weather.Contract.DataClasses;

public record CurrentWeather
{
    public bool IsDay { get; init; }
    public DateTimeOffset DateTime { get; init; }
    public double Temperature { get; init; }
}
