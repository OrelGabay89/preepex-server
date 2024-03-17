using Swiftrade.Core.Domain.Entities.Common;


namespace Swiftrade.Core.Domain.Entities
{
    public class Subscriber : BaseEntity<int>
    {
        public string Email { get; set; }
        public string Name { get; set; } // Add the 'Name' property
    }
}
