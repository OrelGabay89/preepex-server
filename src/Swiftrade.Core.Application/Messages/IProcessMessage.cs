namespace Swiftrade.Core.Application.Messages
{
    public interface IProcessMessage
    {
    }

    public interface IProcessMessageAsync : IProcessMessage
    {
    }

    public interface IProcessMessage<TMessage> : IProcessMessage
    {
    }

    public interface IProcessMessageAsync<TMessage> : IProcessMessageAsync
    {
    }
}
