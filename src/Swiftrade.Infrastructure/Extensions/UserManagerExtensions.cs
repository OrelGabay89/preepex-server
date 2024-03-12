using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Swiftrade.Core.Domain.Entities.Identity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Swiftrade.Infrastructure.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<ApplicationUser> FindByUserByClaimsPrincipleWithAddressAsync(this UserManager<ApplicationUser> input, ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            return await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
        }

        public static async Task<ApplicationUser> FindByEmailFromClaimsPrinciple(this UserManager<ApplicationUser> input, ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        public static async Task<ApplicationUser> FindByIdFromClaimsPrinciple(this UserManager<ApplicationUser> input, ClaimsPrincipal user)
        {
            var userId = user?.Claims?.FirstOrDefault(x => x.Type == "UserId")?.Value;
            return await input.Users.Include("Address").SingleOrDefaultAsync(x => x.Id == userId);
        }
    }
}