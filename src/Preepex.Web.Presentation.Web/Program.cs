using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Preepex.Infrastructure.Services;
using System;
using System.Threading.Tasks;
using Preepex.Core.Application.Interfaces.Shared;

namespace Preepex.Web.Presentation.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

          
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                var importantMessagesLogger = services.GetRequiredService<IImportantMessagesLogger>();
                importantMessagesLogger.PostMessage("Application is running");
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
