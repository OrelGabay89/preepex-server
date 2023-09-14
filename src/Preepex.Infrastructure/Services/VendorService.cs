using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Domain.Entities;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Services
{
    public class VendorService : IVendorService
    {
        #region declaration
        private readonly IVendorRepository _vendorRepository;
        #endregion

        #region ctor
        public VendorService(IVendorRepository vendorRepository)
        { 
            _vendorRepository = vendorRepository;
        }
        #endregion

        #region methods
        public async Task<Vendor> GetVendorByIdAsync(int vendorId)
        {
            return await _vendorRepository.GetVendorByIdAsync(vendorId);
        }
        #endregion
    }
}
