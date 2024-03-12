using Microsoft.EntityFrameworkCore;
using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Infrastructure.DbContexts;
using System.Threading.Tasks;

namespace Swiftrade.Infrastructure.Repositories
{
    public class DateRangeRepository : IDateRangeRepository
    {
        private readonly SwiftradeContext _dateRangeContext;
        public DateRangeRepository(SwiftradeContext dateRangeContext)
        {
            _dateRangeContext = dateRangeContext;
        }
        public async Task<Deliverydate> GetDeliveryDateByIdAsync(int deliveryDateId)
        {
            return await _dateRangeContext.Deliverydates.FirstOrDefaultAsync(x => x.Id == deliveryDateId);
        }
    }
}
