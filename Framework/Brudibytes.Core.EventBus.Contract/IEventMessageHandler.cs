namespace Brudibytes.Core.EventBus.Contract;

public interface IEventMessageHandler<in TEventMessage>
    where TEventMessage : class, IEventMessage
{
    Task HandleAsync(TEventMessage eventMessage);
}
