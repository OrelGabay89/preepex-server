using Swiftrade.Core.Domain.Entities;
using System.Threading.Tasks;

namespace Swiftrade.Core.Application.Interfaces.Shared
{
    public interface IVendorService
    {
        public Task<Vendor> GetVendorByIdAsync(int vendorId);
    }
}
