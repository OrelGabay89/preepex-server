
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Preepex.Common.Options;
using Preepex.Infrastructure.Extensions;
using System;

namespace Preepex.Web.Presentation.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddInfrastructureLayer(configuration, environment);
            services.AddSharedServices();
            services.AddApplicationCookie();

            services.AddStorageOptions(configuration);

            services.AddValidatorsFromAssemblyContaining<Startup>();

        }

        private static void AddApplicationCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.Name = "SwiftradeAuth";
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
                options.SlidingExpiration = true;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            });
        }


        private static void AddStorageOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FileStorageOptions>(x => configuration.GetSection("Storage").Bind(x));
        }

    }
}
