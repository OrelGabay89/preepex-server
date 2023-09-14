

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Application.Messages;
using Preepex.Core.Application.Models;
using Preepex.Core.Domain.Entities.Messages;
using System;
using System.Threading.Tasks;
using Preepex.Presentation.Framework.Controllers;
using Preepex.Core.Application.Interfaces;
using Preepex.Common.Exceptions;
using Preepex.Core.Application;

namespace Preepex.Web.Presentation.Web.Controllers
{
    [AllowAnonymous]
    public class EmailAccountController : BaseApiController
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly IEmailAccountService _emailAccountService;
        private readonly IEmailSender _emailSender;
        private readonly IStoreContext _storeContext;
        #endregion

        #region Ctor

        public EmailAccountController(
            IEmailAccountService emailAccountService,
            IEmailSender emailSender,
            ILocalizationService localizationService,
            IStoreContext storeContext)
        {
            _emailAccountService = emailAccountService;
            _emailSender = emailSender;
            _localizationService = localizationService;
            _storeContext = storeContext;
        }

        #endregion

        #region Methods

        [HttpPost("add-smtp")]
        public virtual async Task<IActionResult> Create(EmailAccountModel model, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                var emailAccount = new EmailAccount
                {
                    DisplayName = model.DisplayName,
                    Email = model.Email,
                    EnableSsl = model.EnableSsl,
                    Host = model.Host,
                    Password = model.Password,
                    Id = model.Id,
                    Port = model.Port,
                    UseDefaultCredentials = model.UseDefaultCredentials,
                    Username = model.Username,
                };

                //set password manually
                emailAccount.Password = model.Password;
                await _emailAccountService.InsertEmailAccountAsync(emailAccount);

                return continueEditing ? RedirectToAction("Edit", new { id = emailAccount.Id }) : RedirectToAction("List");
            }

            //if we got this far, something failed, redisplay form
            return Content("");
        }


        [HttpPost("edit-smtp")]
        public virtual async Task<IActionResult> Edit(EmailAccountModel model, bool continueEditing)
        {
            //try to get an email account with the specified id
            var emailAccount = await _emailAccountService.GetEmailAccountByIdAsync(model.Id);
            if (emailAccount == null)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                emailAccount = new EmailAccount
                {
                    DisplayName = model.DisplayName,
                    Email = model.Email,
                    EnableSsl = model.EnableSsl,
                    Host = model.Host,
                    Password = model.Password,
                    Id = model.Id,
                    Port = model.Port,
                    UseDefaultCredentials = model.UseDefaultCredentials,
                    Username = model.Username,
                };
                await _emailAccountService.UpdateEmailAccountAsync(emailAccount);

                return continueEditing ? RedirectToAction("Edit", new { id = emailAccount.Id }) : RedirectToAction("List");
            }


            //if we got this far, something failed, redisplay form
            return Content("");
        }

        [HttpPost("changeSmtpPassword")]
        public virtual async Task<IActionResult> ChangePassword(EmailAccountModel model)
        {
           
            //try to get an email account with the specified id
            var emailAccount = await _emailAccountService.GetEmailAccountByIdAsync(model.Id);
            if (emailAccount == null)
                return RedirectToAction("List");

            //do not validate model
            emailAccount.Password = model.Password;
            await _emailAccountService.UpdateEmailAccountAsync(emailAccount);

            return RedirectToAction("Edit", new { id = emailAccount.Id });
        }

        [HttpPost]
        [Route("sendtestemail")]
        public virtual async Task<string> SendTestEmail(EmailAccountModel model)
        {
            //if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageEmailAccounts))
            //    return AccessDeniedView();

            //try to get an email account with the specified id
            var emailAccount = await _emailAccountService.GetEmailAccountByIdAsync(model.Id);
            if (emailAccount == null)
                return "List";

            if (!CommonHelper.IsValidEmail(model.SendTestEmailTo))
            {
                //_notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Common.WrongEmail"));
                return "Admin.Common.WrongEmail";
            }

            try
            {
                if (string.IsNullOrWhiteSpace(model.SendTestEmailTo))
                    throw new PreepexException("Enter test email address");
                var store = await _storeContext.GetCurrentStoreAsync();
                var subject = store.Name + ". Testing email functionality.";
                var body = "Email works fine.";
                await _emailSender.SendEmailAsync(emailAccount, subject, body, emailAccount.Email, emailAccount.DisplayName, model.SendTestEmailTo, null);

                //_notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Configuration.EmailAccounts.SendTestEmail.Success"));
                return "Admin.Configuration.EmailAccounts.SendTestEmail.Success";
            }
            catch (Exception exc)
            {
                //_notificationService.ErrorNotification(exc.Message);
                return exc.Message;
            }

            //prepare model
            //model = await _emailAccountModelFactory.PrepareEmailAccountModelAsync(model, emailAccount, true);

            //if we got this far, something failed, redisplay form
            return "Send";
        }

        [HttpPost("delete-smtp")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            //try to get an email account with the specified id
            var emailAccount = await _emailAccountService.GetEmailAccountByIdAsync(id);
            if (emailAccount == null)
                return RedirectToAction("List");

            try
            {
                await _emailAccountService.DeleteEmailAccountAsync(emailAccount);
                return RedirectToAction("List");
            }
            catch (Exception exception)
            {
                //_notificationService.ErrorNotification(exc.Message);                
                return RedirectToAction("Edit", new { id = emailAccount.Id });
            }
        }

        #endregion
        
    }
}
