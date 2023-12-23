using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Preepex.Core.Application.Dtos;
using Preepex.Core.Application.Errors;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Domain.Entities.Identity;
using Preepex.Infrastructure.Extensions;
using System.Text;
using System.Threading.Tasks;
using Preepex.Core.Application.Messages;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Security.Claims;

namespace Preepex.Web.Presentation.Web.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("api/account")]
    public class AccountController : BaseApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly IPasswordGeneratorService _passwordGeneratorService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender, IMapper mapper,
            IPasswordGeneratorService passwordGeneratorService)
        {
            _mapper = mapper;
            _emailSender = emailSender;
            _signInManager = signInManager;
            _userManager = userManager;
            _passwordGeneratorService = passwordGeneratorService;
        }


        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByIdFromClaimsPrinciple(HttpContext.User);

            return new UserDto
            {
                Email = user.Email,
                DisplayName = user.DisplayName
            };
        }

        [HttpGet("email-exists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        [HttpGet("get-address")]
        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
            var user = await _userManager.FindByUserByClaimsPrincipleWithAddressAsync(HttpContext.User);

            return _mapper.Map<Address, AddressDto>(user.Address);
        }

        [HttpPut("update-address")]
        public async Task<ActionResult<AddressDto>> UpdateUserAddress([FromBody] AddressDto address)
        {
            var user = await _userManager.FindByUserByClaimsPrincipleWithAddressAsync(HttpContext.User);

            user.Address = _mapper.Map<AddressDto, Address>(address);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) return Ok(_mapper.Map<Address, AddressDto>(user.Address));

            return BadRequest("Problem updating the user");
        }

        [HttpPost("login")]
        [AllowAnonymous]

        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

            await SetAuthenticatedCookie(user);

            return new UserDto
            {
                Email = user.Email,
                DisplayName = user.DisplayName
            };
        }

        [HttpPost("register")]
        [AllowAnonymous]

        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (CheckEmailExistsAsync(registerDto.Email).Result.Value)
            {
                return new BadRequestObjectResult(new ApiValidationErrorResponse { Errors = new[] { "Email address is in use" } });
            }

            var user = new ApplicationUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            var roleAddResult = await _userManager.AddToRoleAsync(user, "Member");

            if (!roleAddResult.Succeeded) return BadRequest("Failed to add to role");

            await SetAuthenticatedCookie(user);

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email
            };
        }

        
        [HttpPost("external-login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> ExternalLogin(SocialUserDto socialUserDto)
        {
            var user = await _userManager.FindByEmailAsync(socialUserDto.Email);

            if (user != null)
            {
                await SetAuthenticatedCookie(user);

                return new UserDto
                {
                    Email = user.Email,
                    DisplayName = user.DisplayName
                };
            }

            user = new ApplicationUser
            {
                DisplayName = socialUserDto.Name,
                Email = socialUserDto.Email,
                UserName = socialUserDto.Email
            };

            var result = await _userManager.CreateAsync(user, _passwordGeneratorService.GenerateRandomPassword());

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Member");
            }

            await SetAuthenticatedCookie(user);

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email
            };
        }

        [HttpGet("forgot-password")]
        [AllowAnonymous]

        public async Task<ActionResult> ForgotPassword([FromQuery] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !await _userManager.IsEmailConfirmedAsync(user))
            {
                return NotFound(new ApiResponse(404, "User not found"));
            }
            else
            {
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = $"/account/reset-password?email={user.Email}&code={code}";

                //await _emailSender.SendEmailAsync(new Preepex.Core.Entities.Messages.EmailAccount(), "Reset your password",
                //    $"Please reset your password by <a href = '{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.",
                //    fromAddress: user.Email, fromName: user.DisplayName,
                //    toAddress: user.Email, toName: user.DisplayName);

                return Ok(new ApiResponse(200, "User found", callbackUrl));
            }
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<ActionResult> ResetPassword(ResetPasswordDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.IsEmailConfirmedAsync(user))
            {
                return NotFound(new ApiResponse(404, "User not found"));
            }
            else
            {
                model.Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(model.Code));
                var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
                if (result.Succeeded)
                {
                    return Ok(new ApiResponse(200, "Password successfully changed.", "/account/login"));
                }

                return Ok();
            }
        }
        
        [HttpGet("user-account-info")]
        public async Task<UserAccountInformationDto> GetCurrentUserAccountInformation()
        {
            var user = await _userManager.FindByIdFromClaimsPrinciple(User);

            return new UserAccountInformationDto
            {
                UserId = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                DisplayName = user.DisplayName,
                AddressDto = _mapper.Map<Address, AddressDto>(user.Address)
            };
        }

        
        [HttpPut("user-account-info")]
        public async Task<ActionResult<UserAccountInformationDto>> UpdateCurrentAccountInformation([FromBody] UserAccountInformationDto model)
        {
            var user = await _userManager.FindByIdFromClaimsPrinciple(HttpContext.User);

            if (user != null)
            {

                if (model.IsEmailChange)
                {
                    //check email is same or not
                    if (user.Email.Equals(model.NewEmail)) return BadRequest(new ApiResponse(400));

                    //check current password 
                    var checkCurrentPassword = await _signInManager.CheckPasswordSignInAsync(user, model.CurrentPassword, false);
                    if (!checkCurrentPassword.Succeeded) return Unauthorized(new ApiResponse(401));
                    user.Email = model.NewEmail;
                }

                if (model.IsPasswordChange)
                {
                    //check current password 
                    var checkCurrentPassword = await _signInManager.CheckPasswordSignInAsync(user, model.CurrentPassword, false);
                    if (!checkCurrentPassword.Succeeded) return Unauthorized(new ApiResponse(401));
                    //update new password
                    var changeConfirmPassword = await _userManager.CreateAsync(user, model.ConfirmNewPassword);
                    if (!changeConfirmPassword.Succeeded) return BadRequest(new ApiResponse(400));
                }

                user.DisplayName = model.DisplayName;
                user.PhoneNumber = model.PhoneNumber;
                model.AddressDto.AppUserId = user.Id;
                user.Address = _mapper.Map<AddressDto, Address>(model.AddressDto);

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return new UserAccountInformationDto
                    {
                        UserId = user.Id,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        DisplayName = user.DisplayName,
                        AddressDto = _mapper.Map<Address, AddressDto>(user.Address)
                    };
            }
            return new UserAccountInformationDto
            {
                UserId = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                DisplayName = user.DisplayName,
                AddressDto = _mapper.Map<Address, AddressDto>(user.Address)
            };
        }

        private async Task SetAuthenticatedCookie(ApplicationUser user)
        {

            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.DisplayName),
                new Claim("UserId", user.Id)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, // Make the cookie persistent
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7) // Set cookie to expire in 7 days
            };

            
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties
            );
        }


    }
}