using Swiftrade.Core.Application.Events;

namespace Swiftrade.SignalR
{
    public class SignalRMessage
    {
        public object Body { get; set; }
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public ModelAction Action { get; set; }
    }
}
