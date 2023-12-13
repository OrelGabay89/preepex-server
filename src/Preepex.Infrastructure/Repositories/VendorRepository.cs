using Microsoft.EntityFrameworkCore;
using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Domain.Entities;
using Preepex.Infrastructure.DbContexts;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly PreepexContext _context;
        public VendorRepository(PreepexContext context)
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
