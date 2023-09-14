using Preepex.Core.Domain.Entities;
using System.Threading.Tasks;

namespace Preepex.Core.Application.Interfaces.Shared
{
    public interface IVendorService
    {
        public Task<Vendor> GetVendorByIdAsync(int vendorId);
    }
}
