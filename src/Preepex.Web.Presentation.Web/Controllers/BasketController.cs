using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Preepex.Core.Application.Dtos;
using System.Threading.Tasks;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Application.Interfaces;
using Preepex.Core.Domain.Entities.ApplicationEntities;
using Microsoft.AspNetCore.Authorization;

namespace Preepex.Web.Presentation.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/basket")]
    public class BasketController : BaseApiController
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        private readonly IWorkContext _workContext;

        public BasketController(IBasketService basketService, IMapper mapper , IWorkContext workContext)
        {
            _mapper = mapper;
            _basketService = basketService;
            _workContext = workContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            if (id == null)
            {
                return BadRequest("The 'id' parameter cannot be null.");
            }

            var basket = await _basketService.GetBasketAsync(id);
            if (basket == null)
            {
                return Ok($"Basket with id '{id}' not found.");
            }
            else
            {
                basket.CurrencyCode = (await _workContext.GetWorkingCurrencyAsync()).CurrencyCode;
                return Ok(basket);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket([FromBody] CustomerBasketDto basket)
        {
            var customerBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
            customerBasket.CurrencyCode = (await _workContext.GetWorkingCurrencyAsync()).CurrencyCode;
            var updatedBasket = await _basketService.UpdateBasketAsync(customerBasket);
            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketService.DeleteBasketAsync(id);
        }
    }
}