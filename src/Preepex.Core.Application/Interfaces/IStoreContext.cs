using Preepex.Core.Domain.Entities;
using System.Threading.Tasks;

namespace Preepex.Core.Application.Interfaces
{
    /// <summary>
    /// Store context
    /// </summary>
    public interface IStoreContext
    {
        /// <summary>
        /// Gets the current store
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<Store> GetCurrentStoreAsync();

        /// <summary>
        /// Gets the current store
        /// </summary>
        Store GetCurrentStore();

        /// <summary>
        /// Gets active store scope configuration
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        //Task<int> GetActiveStoreScopeConfigurationAsync();
    }
}
