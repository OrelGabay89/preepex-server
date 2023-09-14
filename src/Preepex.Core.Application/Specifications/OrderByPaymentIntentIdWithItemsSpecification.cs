using Preepex.Core.Domain.Entities.OrderAggregate;

namespace Preepex.Core.Application.Specifications
{
    public class OrderByPaymentIntentIdSpecification : BaseSpecification<OrigOrder>
    {
        public OrderByPaymentIntentIdSpecification(string paymentIntentId)
            : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }


    }
}