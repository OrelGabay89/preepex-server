using Swiftrade.Common.Messaging;

namespace Swiftrade.Core.Application.Messages.Events
{
    public interface IHandle<TEvent> : IProcessMessage<TEvent>
        where TEvent : IEvent
    {
        void Handle(TEvent message);
    }

    public interface IHandleAsync<TEvent> : IProcessMessageAsync<TEvent>
        where TEvent : IEvent
    {
        void HandleAsync(TEvent message);
    }
}
