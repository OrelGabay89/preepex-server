using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Infrastructure.Services;
using System.Threading.Tasks;
using System.Linq;
using Swiftrade.Core.Application.Interfaces;
using System.Collections.Generic;
using Swiftrade.Core.Application.Interfaces.Shared;

namespace Swiftrade.Web.Presentation.Web.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/subscribers")]
    public class SubscribersController : BaseApiController
    {
        private readonly ISubscribersService _subscribersService;
        private readonly IStoreContext _storeContext;

        public SubscribersController(ISubscribersService subscribersService, IStoreContext storeContext)
        {
            _subscribersService = subscribersService;
            _storeContext = storeContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscriber>>> GetSubscribers()
        {
            var subscribers = await _subscribersService.GetAllSubscribersAsync();
            return Ok(subscribers);
        }

        [HttpPost]
        public async Task<ActionResult<Subscriber>> AddSubscriber(Subscriber subscriber)
        {
            await _subscribersService.AddSubscriberAsync(subscriber);
            return CreatedAtAction(nameof(GetSubscriberById), new { id = subscriber.Id }, subscriber);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subscriber>> GetSubscriberById(int id)
        {
            var subscriber = await _subscribersService.GetSubscriberByIdAsync(id);
            if (subscriber == null)
            {
                return NotFound();
            }
            return Ok(subscriber);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubscriber(int id, Subscriber subscriberUpdate)
        {
            var subscriber = await _subscribersService.GetSubscriberByIdAsync(id);
            if (subscriber == null)
            {
                return NotFound();
            }

            // Update properties of subscriber
            subscriber.Email = subscriberUpdate.Email; // Update other properties as needed
            await _subscribersService.UpdateSubscriberAsync(subscriber);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            var subscriber = await _subscribersService.GetSubscriberByIdAsync(id);
            if (subscriber == null)
            {
                return NotFound();
            }

            await _subscribersService.DeleteSubscriberAsync(subscriber);
            return NoContent();
        }
    }
}