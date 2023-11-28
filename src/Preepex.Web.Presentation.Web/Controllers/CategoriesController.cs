using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Preepex.Core.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Preepex.Presentation.Framework.Controllers;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Application.Interfaces.Factories;
using Preepex.Core.Application.Models;
using Microsoft.AspNetCore.Http;
using Preepex.Core.Application.Attributes;
using Microsoft.AspNetCore.Authorization;

namespace Preepex.Web.Presentation.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/categories")]
    //[AutoValidateAntiforgeryToken]
    public class CategoriesController : BaseApiController
    {
        private readonly ICategoryService _categoryService;
        private readonly ICatalogModelFactory _catalogModelFactory;

        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, ICatalogModelFactory catalogModelFactory, IMapper mapper)
        {
            _categoryService = categoryService;
            _catalogModelFactory = catalogModelFactory;
            _mapper = mapper;   
        }



        //[ResponseCache(CacheProfileName = "Default30")]
        //[ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
        [HttpGet("top-menu-categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [RedisCached(600)]
        public async Task<ActionResult<TopMenuDto>> GetTopMenuCategories()
        {
            var model = await _catalogModelFactory.PrepareTopMenuModelAsync();
            var result = _mapper.Map<TopMenuModel, TopMenuDto>(model);

            return result;
        }

        /// <summary>
        /// Get all categories for Main Menu
        /// </summary>
        /// <returns></returns>
        [HttpGet("home-menu-categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [RedisCached(600)]
        
        //[ResponseCache(CacheProfileName = "Default30")]
        //[ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<ActionResult<IReadOnlyList<HomeCategoriesDto>>> GetCategoriesHomeMenu()
        {
            var categories = await _catalogModelFactory.PrepareHomepageCategoryModelsAsync();
            var result = _mapper.Map<IReadOnlyList<CategoryModel>, IReadOnlyList<HomeCategoriesDto>>(categories);
            return Ok(result);
           
        }
    }
}
