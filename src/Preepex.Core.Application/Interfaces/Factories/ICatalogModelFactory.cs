using Preepex.Core.Application.Models;
using Preepex.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Preepex.Core.Application.Interfaces.Factories
{
    public interface ICatalogModelFactory
    {

        /// <summary>
        /// Prepare category model
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="filter">Model to get the catalog products</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the category model
        /// </returns>
        Task<CategoryModel> PrepareCategoryModelAsync(Category category, CatalogProductsFilter filter = null);
        
        /// <summary>
        /// Prepare homepage category models
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the list of homepage category models
        /// </returns>
        Task<List<CategoryModel>> PrepareHomepageCategoryModelsAsync(int storeId);


        /// <summary>
        /// Prepare top menu model
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the op menu model
        /// </returns>
        Task<TopMenuModel> PrepareTopMenuModelAsync();




    }
}
