using Diamond.Logic.Domain.Weather.Contract.DataClasses;

namespace Diamond.Logic.Domain.Weather.Contract;

public interface IWeatherForecastProvider
{
    Task<WeatherForecast> ProvideCurrentAsync();
}