namespace Brudibytes.Core.EventBus.Contract;

public interface IEventMessage
{
    DateTimeOffset CreatedAt { get; }
}