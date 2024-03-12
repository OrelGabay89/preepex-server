using CH.CleanArchitecture.Core.Application.Dtos;
using Swiftrade.Common;
using Swiftrade.Common.Results;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Swiftrade.Core.Application.Interfaces.Shared
{
    public interface IApplicationConfigurationService
    {
        #region Public Methods
        /// <summary>
        /// Retrieves all application configurations from DB
        /// </summary>
        /// <returns></returns>
        Result<IQueryable<ApplicationConfigurationDto>> GetAll();

        /// <summary>
        /// Insert a configuration to the database
        /// </summary>
        /// <param name="applicationConfiguration">Configuration details. See <see cref="ApplicationConfigurationDTO"/> for more information.</param>
        Task<Result> CreateAsync(ApplicationConfigurationDto applicationConfiguration);

        /// <summary>
        /// Retrieves application configuration details.
        /// </summary>
        /// <param name="id">The ID of record</param>
        /// <param name="decrypt">If is true the value of application configuration returned is decrypted.</param>
        /// <returns></returns>
        Task<Result<ApplicationConfigurationDto>> DetailsAsync(string id, bool decrypt);

        /// <summary>
        /// Edit an exsisting configuration to the database
        /// </summary>
        /// <param name="appConfig">Configuration details. See <see cref="ApplicationConfigurationDTO"/> for more information.</param>
        Task<Result> EditAsync(ApplicationConfigurationDto appConfig);

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="id">Primary key of the entity.</param>
        /// <returns>True if the delete was successfull.</returns>
        Task<Result> DeleteAsync(string id);

        /// <summary>
        /// Retrieves a configuration value based on the given key.
        /// </summary>
        /// <param name="key">Configuration Key.</param>
        /// <returns>Result with the configuration value.</returns>
        Result<string> GetValue(string key);

        /// <summary>
        /// Retrieves a configuration value converted to an INT type based on the given key.
        /// </summary>
        /// <param name="key">Configuration Key.</param>
        /// <returns>Result with the configuration value converted to an INT type.</returns>
        Result<int> GetValueInt(string key);

        /// <summary>
        /// Retrieves a configuration value converted to an Bool type based on the given key.
        /// </summary>
        /// <param name="key">Configuration Key.</param>
        /// <returns>Result with the configuration value converted to an Bool type.</returns>
        Result<bool> GetValueBool(string key);

        /// <summary>
        /// Retrieves a configuration value converted to a DateTime type based on the given key.
        /// </summary>
        /// <param name="key">Configuration Key.</param>
        /// <returns>Result with the configuration value converted to an DateTime type.</returns>
        Result<DateTime> GetValueDateTime(string key);

        /// <summary>
        /// Retrieves a configuration value which is delimited by the default '|' character
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Result<string[]> GetMultiple(string key);

        /// <summary>
        /// Retrieves a configuration value which is delimited by a character
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Result<string[]> GetMultiple(string key, string delimiter);

        #endregion Public Methods
    }
}
