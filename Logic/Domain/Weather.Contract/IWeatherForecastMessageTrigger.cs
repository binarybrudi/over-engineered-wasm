namespace Diamond.Logic.Domain.Weather.Contract;

public interface IWeatherForecastMessageTrigger
{
    Task<bool> TriggerCurrentForecastAsync();
}
