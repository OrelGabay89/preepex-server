using Preepex.Core.Domain.Entities;
using System.Threading.Tasks;

namespace Preepex.Core.Application.Interfaces.Repositories.Domain
{
    public interface IVendorRepository
    {
        public Task<Vendor> GetVendorByIdAsync(int vendorId);
    }
}
