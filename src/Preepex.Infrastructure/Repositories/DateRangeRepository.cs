using Microsoft.EntityFrameworkCore;
using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Domain.Entities;
using Preepex.Infrastructure.DbContexts;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Repositories
{
    public class DateRangeRepository : IDateRangeRepository
    {
        private readonly PreepexContext _dateRangeContext;
        public DateRangeRepository(PreepexContext dateRangeContext)
        {
            _dateRangeContext = dateRangeContext;
        }
        public async Task<Deliverydate> GetDeliveryDateByIdAsync(int deliveryDateId)
        {
            return await _dateRangeContext.Deliverydates.FirstOrDefaultAsync(x => x.Id == deliveryDateId);
        }
    }
}
