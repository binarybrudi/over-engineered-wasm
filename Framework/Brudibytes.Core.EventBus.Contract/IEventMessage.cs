namespace Brudibytes.Core.EventBus.Contract;

public interface IEventMessage
{
    DateTime CreatedAt { get; }
}