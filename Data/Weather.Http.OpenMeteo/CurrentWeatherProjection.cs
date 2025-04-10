using Diamond.Data.Weather.Contract;
using Diamond.Data.Weather.Contract.DataClasses;

namespace Diamond.Data.Weather.Http.OpenMeteo;

internal sealed class CurrentWeatherProjection : ICurrentWeatherProjection
{
    public Task<CurrentWeather> GetCurrentWeatherAsync()
    {
        throw new NotImplementedException();
    }
}