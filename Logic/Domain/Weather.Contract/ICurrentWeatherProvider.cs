using Diamond.Logic.Domain.Weather.Contract.DataClasses;

namespace Diamond.Logic.Domain.Weather.Contract;

public interface ICurrentWeatherProvider
{
    Task<CurrentWeather> ProvideCurrentAsync();
}