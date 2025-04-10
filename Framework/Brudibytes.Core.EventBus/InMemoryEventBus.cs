using System.Collections.Concurrent;
using Brudibytes.Core.EventBus.Contract;

namespace Brudibytes.Core.EventBus;

public class InMemoryEventBus : IEventBus
{
    private readonly ConcurrentDictionary<Type, List<object>> _subscribers = new();

    public async Task PublishAsync<TEventMessage>(TEventMessage eventMessage)
        where TEventMessage : class, IEventMessage
    {
        var messageType = typeof(TEventMessage);

        if (_subscribers.TryGetValue(messageType, out var handlers))
        {
            var typedHandlers = handlers.OfType<IEventMessageHandler<TEventMessage>>().ToArray();
            foreach (var handler in typedHandlers)
            {
                await handler.HandleAsync(eventMessage);
            }
        }
    }

    public void Subscribe<TEventMessage>(IEventMessageHandler<TEventMessage> handler)
        where TEventMessage : class, IEventMessage
    {
        var messageType = typeof(TEventMessage);
        _subscribers.AddOrUpdate(
            messageType,
            [handler],
            (key, existingList) =>
            {
                existingList.Add(handler);
                return existingList;
            }
        );
    }
}
