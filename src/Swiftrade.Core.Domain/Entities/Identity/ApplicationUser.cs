using Microsoft.AspNetCore.Identity;

namespace Swiftrade.Core.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }

    }
}