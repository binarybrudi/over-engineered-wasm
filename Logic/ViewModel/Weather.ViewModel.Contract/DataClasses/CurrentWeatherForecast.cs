namespace Diamond.Logic.ViewModel.Weather.ViewModel.Contract.DataClasses;

public record CurrentWeatherForecast
{
    public DateTimeOffset Date { get; init; }
    public double Temperature { get; init; }
    public double Humidity { get; init; }
    public double WindSpeed { get; init; }
}
