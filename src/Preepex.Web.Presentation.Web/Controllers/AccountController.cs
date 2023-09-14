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
using Preepex.Presentation.Framework.Controllers;
using Preepex.Core.Application.Messages;

namespace Preepex.Web.Presentation.Web.Controllers
{
    [Route("api/account")]
    public class AccountController : BaseApiController
    {
        #region declaration
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly IPasswordGeneratorService _passwordGeneratorService;
        #endregion

        #region ctor
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ITokenService tokenService, IEmailSender emailSender, IMapper mapper,
            IPasswordGeneratorService passwordGeneratorService)
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _emailSender = emailSender;
            _signInManager = signInManager;
            _userManager = userManager;
            _passwordGeneratorService = passwordGeneratorService;
            //_localization = localization;
        }
        #endregion

        #region methods

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByIdFromClaimsPrinciple(HttpContext.User);

            return new UserDto
            {
                Email = user.Email,
                Token = await _tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
        }

        [HttpGet("email-exists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("get-address")]
        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
            var user = await _userManager.FindByUserByClaimsPrincipleWithAddressAsync(HttpContext.User);

            return _mapper.Map<Address, AddressDto>(user.Address);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("update-address")]
        public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto address)
        {
            var user = await _userManager.FindByUserByClaimsPrincipleWithAddressAsync(HttpContext.User);

            user.Address = _mapper.Map<AddressDto, Address>(address);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) return Ok(_mapper.Map<Address, AddressDto>(user.Address));

            return BadRequest("Problem updating the user");
        }

        [HttpPost("login")]

        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

            return new UserDto
            {
                Email = user.Email,
                Token = await _tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
        }

        [HttpPost("register")]
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

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Token = await _tokenService.CreateToken(user),
                Email = user.Email
            };
        }

        [HttpPost("external-login")]
        public async Task<ActionResult<UserDto>> ExternalLogin(SocialUserDto socialUserDto)
        {
            var user = await _userManager.FindByEmailAsync(socialUserDto.Email);
            if (user == null)
            {
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
                return new UserDto
                {
                    DisplayName = user.DisplayName,
                    Token = await _tokenService.CreateToken(user),
                    Email = user.Email
                };
            }
            else
            {
                return new UserDto
                {
                    Email = user.Email,
                    Token = await _tokenService.CreateToken(user),
                    DisplayName = user.DisplayName
                };
            }
        }

        [HttpGet("forgot-password")]
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

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("user-account-info")]
        public async Task<UserAccountInformationDto> GetCurrentUserAccountInformation()
        {
            var user = await _userManager.FindByIdFromClaimsPrinciple(User);

            return new UserAccountInformationDto
            {
                UserId = user.Id,
                Email = user.Email,
                MobileNumber = user.PhoneNumber,
                DisplayName = user.DisplayName,
                AddressDto = _mapper.Map<Address, AddressDto>(user.Address)
            };
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
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
                user.PhoneNumber = model.MobileNumber;
                model.AddressDto.AppUserId = user.Id;
                user.Address = _mapper.Map<AddressDto, Address>(model.AddressDto);

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return new UserAccountInformationDto
                    {
                        UserId = user.Id,
                        Email = user.Email,
                        MobileNumber = user.PhoneNumber,
                        DisplayName = user.DisplayName,
                        AddressDto = _mapper.Map<Address, AddressDto>(user.Address)
                    };
            }
            return new UserAccountInformationDto
            {
                UserId = user.Id,
                Email = user.Email,
                MobileNumber = user.PhoneNumber,
                DisplayName = user.DisplayName,
                AddressDto = _mapper.Map<Address, AddressDto>(user.Address)
            };
        }

        #endregion

        //[HttpGet]
        //public ActionResult<IEnumerable<LocalizedString>> GetAllCulturedLocalizedString()
        //{
        //    var localised = _localization.GetAllCulturedLocalizedString();

        //    return Ok(localised);
        //}


    }
}