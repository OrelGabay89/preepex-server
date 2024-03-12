using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Infrastructure.DbContexts;
using System.Linq;

namespace Swiftrade.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly SwiftradeContext _preepexContext;
        public AddressRepository(SwiftradeContext preepexContext)
        {
            _preepexContext = preepexContext;
        }
        public IQueryable<NopAddress> GetAddresses()
        {
            return _preepexContext.Addresses.AsQueryable();
        }
    }
}
