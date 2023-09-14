using Microsoft.AspNetCore.Identity;
using Preepex.Core.Domain.Entities.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.DbContexts
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<ApplicationUser>
                {
                    new ApplicationUser
                    {
                        DisplayName = "Bob",
                        Email = "bob@test.com",
                        UserName = "bob@test.com",
                        Address = new Address
                        {
                            FirstName = "Bob",
                            LastName = "Bobbity",
                            Street = "10 The Street",
                            City = "New York",
                            State = "NY",
                            Zipcode = "90210"
                        }
                    },
                    new ApplicationUser
                    {
                        DisplayName = "Admin",
                        Email = "admin@test.com",
                        UserName = "admin@test.com"
                    }
                };

                var roles = new List<ApplicationRole>
                {
                    new ApplicationRole {Name = "Admin"},
                    new ApplicationRole {Name = "Member"}
                };

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(role);
                }

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                    await userManager.AddToRoleAsync(user, "Member");
                    if (user.Email == "admin@test.com") await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}