
namespace Swiftrade.SignalR
{
    public interface IBroadcastSignalRMessage
    {
        bool IsConnected { get; }
        Task BroadcastMessage(SignalRMessage message);
    }
}
