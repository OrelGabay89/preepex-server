using Preepex.Core.Domain.Entities.Common;

namespace Preepex.Core.Domain.Entities.OrderAggregate
{
    public class DeliveryMethod : BaseEntity<int>
    {
        public DeliveryMethod()
        {

        }
        public DeliveryMethod(object obj)
        {

        }

        public DeliveryMethod(object obj, object obj1)
        {

        }
        public string ShortName { get; set; }
        public string DeliveryTime { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}