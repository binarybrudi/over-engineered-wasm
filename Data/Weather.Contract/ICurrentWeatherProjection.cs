using Diamond.Data.Weather.Contract.DataClasses;

namespace Diamond.Data.Weather.Contract;

public interface ICurrentWeatherProjection
{
    Task<CurrentWeather> GetCurrentWeatherAsync();
}
