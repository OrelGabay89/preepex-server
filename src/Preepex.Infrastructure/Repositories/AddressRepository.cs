using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Domain.Entities;
using Preepex.Infrastructure.DbContexts;
using System.Linq;

namespace Preepex.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly PreepexContext _preepexContext;
        public AddressRepository(PreepexContext preepexContext)
        {
            _preepexContext = preepexContext;
        }
        public IQueryable<NopAddress> GetAddresses()
        {
            return _preepexContext.Addresses.AsQueryable();
        }
    }
}
