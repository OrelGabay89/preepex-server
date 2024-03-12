using Microsoft.EntityFrameworkCore;
using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Infrastructure.DbContexts;
using System.Threading.Tasks;

namespace Swiftrade.Infrastructure.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly SwiftradeContext _context;
        public VendorRepository(SwiftradeContext context)
        {
            _context = context;
        }
        public async Task<Vendor> GetVendorByIdAsync(int vendorId)
        {
            var vendor = await _context.Vendors.FirstOrDefaultAsync(x => x.Id == vendorId && !x.Deleted && x.Active);
            return vendor;
        }
    }
}
