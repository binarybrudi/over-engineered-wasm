namespace Diamond.Data.Weather.Contract.DataClasses;

public sealed record CurrentWeather
{
    public bool IsDay { get; init; }
    public DateTimeOffset DateTime { get; init; }
    public double Temperature { get; init; }
}
