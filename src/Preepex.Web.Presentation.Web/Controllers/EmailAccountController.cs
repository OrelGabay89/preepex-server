using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Application.Messages;
using Preepex.Core.Application.Models;
using Preepex.Core.Domain.Entities.Messages;
using System;
using System.Threading.Tasks;
using Preepex.Common.Exceptions;
using Preepex.Core.Application;
using Preepex.Presentation.Framework.Controllers;
using Preepex.Core.Application.Interfaces;

namespace Preepex.Web.Presentation.Web.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class EmailAccountController : BaseApiController
    {

        private readonly ILocalizationService _localizationService;
        private readonly IEmailAccountService _emailAccountService;
        private readonly IEmailSender _emailSender;
        private readonly IStoreContext _storeContext;

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


        [HttpPost("add-smtp")]
        public async Task<IActionResult> Create(EmailAccountModel model, bool continueEditing)
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
                    Username = model.Username
                };

                await _emailAccountService.InsertEmailAccountAsync(emailAccount);

                return Ok(new { success = true, data = emailAccount, message = "Created successfully." });
            }
            return BadRequest(new { success = false, message = "Error in creating the email account." });
        }

        [HttpPost("edit-smtp")]
        public async Task<IActionResult> Edit(EmailAccountModel model, bool continueEditing)
        {
            var emailAccount = await _emailAccountService.GetEmailAccountByIdAsync(model.Id);
            if (emailAccount == null)
                return NotFound(new { success = false, message = "Email account not found." });

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
                    Username = model.Username
                };

                await _emailAccountService.UpdateEmailAccountAsync(emailAccount);

                return Ok(new { success = true, data = emailAccount, message = "Updated successfully." });
            }
            return BadRequest(new { success = false, message = "Error in editing the email account." });
        }

        [HttpPost("delete-smtp")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var emailAccount = await _emailAccountService.GetEmailAccountByIdAsync(id);
            if (emailAccount == null)
                return NotFound(new { success = false, message = "Email account not found." });

            try
            {
                await _emailAccountService.DeleteEmailAccountAsync(emailAccount);
                return Ok(new { success = true, message = "Email account deleted successfully." });
            }
            catch (Exception exception)
            {
                return BadRequest(new { success = false, message = exception.Message });
            }
        }

        [HttpPost("changeSmtpPassword")]
        public virtual async Task<IActionResult> ChangePassword(EmailAccountModel model)
        {
            var emailAccount = await _emailAccountService.GetEmailAccountByIdAsync(model.Id);
            if (emailAccount == null)
                return NotFound(new { success = false, message = "Email account not found." });

            emailAccount.Password = model.Password;
            await _emailAccountService.UpdateEmailAccountAsync(emailAccount);

            return Ok(new { success = true, message = "Password changed successfully." });
        }

        [HttpPost("sendtestemail")]
        public virtual async Task<IActionResult> SendTestEmail(EmailAccountModel model)
        {
            var emailAccount = await _emailAccountService.GetEmailAccountByIdAsync(model.Id);
            if (emailAccount == null)
                return NotFound(new { success = false, message = "Email account not found." });

            if (!CommonHelper.IsValidEmail(model.SendTestEmailTo))
                return BadRequest(new { success = false, message = "Invalid email address." });

            try
            {
                if (string.IsNullOrWhiteSpace(model.SendTestEmailTo))
                    throw new PreepexException("Enter test email address");

                var store = await _storeContext.GetCurrentStoreAsync();
                var subject = $"{store.Name}. Testing email functionality.";
                var body = "Email works fine.";
                await _emailSender.SendEmailAsync(emailAccount, subject, body, emailAccount.Email, emailAccount.DisplayName, model.SendTestEmailTo, null);

                return Ok(new { success = true, message = "Test email sent successfully." });
            }
            catch (Exception exc)
            {
                return BadRequest(new { success = false, message = exc.Message });
            }
        }
        
    }
}
