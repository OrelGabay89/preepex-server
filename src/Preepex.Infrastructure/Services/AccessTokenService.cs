using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Preepex.Core.Application.Dtos;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Services
{
    public class AccessTokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SymmetricSecurityKey _key;
        public AccessTokenService(IConfiguration config, UserManager<ApplicationUser> userManager)
        {
            _config = config;
            _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
        }

        public async Task<string> CreateToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim("UserId", Convert.ToString(user.Id)),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.DisplayName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = creds,
                Subject = new ClaimsIdentity(claims),
                Issuer = _config["Token:Issuer"],
                Audience = _config["Token:Audience"],
                Expires = DateTime.Now.AddDays(7),
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        public async Task<JwtResponseDto> ValidateToken(string token)
        {
            var tokenValidRes = new JwtResponseDto();
            if (token == null)
                return tokenValidRes;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Token:Key"]);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidIssuer = _config["Token:Issuer"],
                    ValidAudience = _config["Token:Audience"],
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                if (jwtToken != null)
                {
                    tokenValidRes.IsValidToken = true;
                    tokenValidRes.Email = jwtToken.Claims.FirstOrDefault(x => x.Type == "email").Value;
                    tokenValidRes.DisplayName = jwtToken.Claims.FirstOrDefault(x => x.Type == "given_name").Value;
                }

                return tokenValidRes;
            }
            catch
            {
                // return null if validation fails
                return tokenValidRes;
            }
        }
    }
}