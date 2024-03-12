using Swiftrade.Core.Domain.Entities;
using System.Threading.Tasks;

namespace Swiftrade.Core.Application.Interfaces.Repositories.Domain
{
    public interface IVendorRepository
    {
        public Task<Vendor> GetVendorByIdAsync(int vendorId);
    }
}
