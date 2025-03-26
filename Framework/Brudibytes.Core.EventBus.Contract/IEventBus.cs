namespace Brudibytes.Core.EventBus.Contract;

public interface IEventBus
{
    Task PublishAsync<TEventMessage>(TEventMessage eventMessage)
        where TEventMessage : class, IEventMessage;

    void Subscribe<TEventMessage>(IEventMessageHandler<TEventMessage> handler)
        where TEventMessage : class, IEventMessage;
}
