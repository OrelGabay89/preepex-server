using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Application.Interfaces.Shared.Shipping;
using Preepex.Core.Domain.Entities;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Services.Shipping
{
    /// <summary>
    /// Represents the date range service
    /// </summary>
    public class DateRangeService : IDateRangeService
    {
        private readonly IDateRangeRepository _deliveryDateRepository;

        public DateRangeService(IDateRangeRepository deliveryDateRepository)
        {
            _deliveryDateRepository = deliveryDateRepository;
        }
        public virtual async Task<Deliverydate> GetDeliveryDateByIdAsync(int deliveryDateId)
        {
            return await _deliveryDateRepository.GetDeliveryDateByIdAsync(deliveryDateId);
        }
    }
}
