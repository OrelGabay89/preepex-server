using Microsoft.AspNetCore.Mvc;
using Preepex.Core.Application;
using System.Threading.Tasks;
using System;
using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Domain.Entities;

namespace Preepex.Web.Presentation.Web.Controllers
{
    [Route("api/newsletter")]
    [ApiController]
    public class NewsletterController : ControllerBase
    {
        private readonly IStoreContext _storeContext;
        private readonly ILocalizationService _localizationService;
        private readonly IWorkContext _workContext;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly INewsLetterSubscriptionService _newsLetterSubscriptionService;


        public NewsletterController(ILocalizationService localizationService,
               INewsLetterSubscriptionService newsLetterSubscriptionService,
               IStoreContext storeContext,
               IWorkContext workContext,
               IWorkflowMessageService workflowMessageService)
        {
            _localizationService = localizationService;
            _newsLetterSubscriptionService = newsLetterSubscriptionService;
            _storeContext = storeContext;
            _workContext = workContext;
            _workflowMessageService = workflowMessageService;
        }

        [HttpPost]
        public virtual async Task<IActionResult> SubscribeNewsletter(string email, bool subscribe)
        {
            string result;
            var success = false;

            if (!CommonHelper.IsValidEmail(email))
            {
                result = await _localizationService.GetResourceAsync("Newsletter.Email.Wrong");
            }
            else
            {
                email = email.Trim();
                var store = await _storeContext.GetCurrentStoreAsync();
                var subscription = await _newsLetterSubscriptionService.GetNewsLetterSubscriptionByEmailAndStoreIdAsync(email, store.Id);
                var currentLanguage = await _workContext.GetWorkingLanguageAsync();
                if (subscription != null)
                {
                    if (subscribe)
                    {
                        if (!subscription.Active)
                        {
                            await _workflowMessageService.SendNewsLetterSubscriptionActivationMessageAsync(subscription, currentLanguage.Id);
                        }
                        result = await _localizationService.GetResourceAsync("Newsletter.SubscribeEmailSent");
                    }
                    else
                    {
                        if (subscription.Active)
                        {
                            await _workflowMessageService.SendNewsLetterSubscriptionDeactivationMessageAsync(subscription, currentLanguage.Id);
                        }
                        result = await _localizationService.GetResourceAsync("Newsletter.UnsubscribeEmailSent");
                    }
                }
                else if (subscribe)
                {
                    subscription = new NewsLetterSubscription
                    {
                        NewsLetterSubscriptionGuid = Guid.NewGuid(),
                        Email = email,
                        Active = false,
                        StoreId = store.Id,
                        CreatedOnUtc = DateTime.UtcNow
                    };
                    await _newsLetterSubscriptionService.InsertNewsLetterSubscriptionAsync(subscription);
                    await _workflowMessageService.SendNewsLetterSubscriptionActivationMessageAsync(subscription, currentLanguage.Id);

                    result = await _localizationService.GetResourceAsync("Newsletter.SubscribeEmailSent");
                }
                else
                {
                    result = await _localizationService.GetResourceAsync("Newsletter.UnsubscribeEmailSent");
                }
                success = true;
            }

            return Ok(new
            {
                Success = success,
                Result = result,
            });
        }
    }
}
