using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Preepex.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace Preepex.Web.Presentation.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

          
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    //var context = services.GetRequiredService<ApplicationDbContext>();
                    //await context.Database.MigrateAsync();
                    //await StoreContextSeed.SeedAsync(context, loggerFactory);

                    //var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    //var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
                    //var identityContext = services.GetRequiredService<AppIdentityDbContext>();
                    //await identityContext.Database.MigrateAsync();
                    //await AppIdentityDbContextSeed.SeedUsersAsync(userManager, roleManager);



                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occured during migration");
                }

                var slackClient = services.GetRequiredService<ISlackClientService>();
                slackClient.PostMessage("Application is running");
            }

            host.Run();

  
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
