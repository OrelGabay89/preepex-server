using Microsoft.AspNetCore.Identity;

namespace Preepex.Core.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }

    }
}