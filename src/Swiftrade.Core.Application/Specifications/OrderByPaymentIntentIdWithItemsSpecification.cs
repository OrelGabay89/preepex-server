using Swiftrade.Core.Domain.Entities.OrderAggregate;

namespace Swiftrade.Core.Application.Specifications
{
    public class OrderByPaymentIntentIdSpecification : BaseSpecification<OrigOrder>
    {
        public OrderByPaymentIntentIdSpecification(string paymentIntentId)
            : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }


    }
}