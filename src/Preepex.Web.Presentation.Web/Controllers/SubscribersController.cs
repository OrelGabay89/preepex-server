using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Preepex.Core.Domain.Entities;
using Preepex.Presentation.Framework.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace Preepex.Web.Presentation.Web.Controllers
{
    // Controllers/SubscribersController.cs
    [AllowAnonymous]
    [ApiController]
    [Route("api/subscribers")]
    public class SubscribersController : BaseApiController
    {
        private List<Subscriber> subscribers = new List<Subscriber>();

        [HttpGet]
        public ActionResult<IEnumerable<Subscriber>> GetSubscribers()
        {
            return Ok(subscribers);
        }

        [HttpPost]
        public ActionResult<Subscriber> AddSubscriber(Subscriber subscriber)
        {
            subscriber.Id = subscribers.Count + 1;
            subscribers.Add(subscriber);
            return CreatedAtAction(nameof(GetSubscriberById), new { id = subscriber.Id }, subscriber);
        }

        [HttpGet("{id}")]
        public ActionResult<Subscriber> GetSubscriberById(int id)
        {
            var subscriber = subscribers.FirstOrDefault(s => s.Id == id);
            if (subscriber == null)
            {
                return NotFound();
            }
            return Ok(subscriber);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubscriber(int id, Subscriber subscriber)
        {
            var existingSubscriber = subscribers.FirstOrDefault(s => s.Id == id);
            if (existingSubscriber == null)
            {
                return NotFound();
            }

            existingSubscriber.Email = subscriber.Email; // Update other properties as needed
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubscriber(int id)
        {
            var subscriber = subscribers.FirstOrDefault(s => s.Id == id);
            if (subscriber == null)
            {
                return NotFound();
            }

            subscribers.Remove(subscriber);
            return NoContent();
        }
    }
}