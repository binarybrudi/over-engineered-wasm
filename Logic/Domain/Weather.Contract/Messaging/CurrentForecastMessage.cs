using Brudibytes.Core.EventBus.Contract;
using Diamond.Logic.Domain.Weather.Contract.DataClasses;

namespace Diamond.Logic.Domain.Weather.Contract.Messaging;

public record CurrentForecastMessage : IEventMessage
{
    public required DateTimeOffset CreatedAt { get; init; }
    public required WeatherForecast WeatherForecast { get; init; }
}