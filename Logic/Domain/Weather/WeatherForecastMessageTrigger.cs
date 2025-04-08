using Diamond.Logic.Domain.Weather.Contract;

namespace Diamond.Logic.Domain.Weather;

public class WeatherForecastMessageTrigger  : IWeatherForecastMessageTrigger
{
    public Task<bool> TriggerCurrentForecastAsync()
    {
        return Task.FromResult(true);   
    }
}