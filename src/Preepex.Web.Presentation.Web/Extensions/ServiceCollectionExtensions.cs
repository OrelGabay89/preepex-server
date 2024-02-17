
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.AddApplicationCookie(environment);

            services.AddStorageOptions(configuration);

            services.AddValidatorsFromAssemblyContaining<Startup>();

        }

        private static void AddApplicationCookie(this IServiceCollection services, IWebHostEnvironment environment)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.Name = "SwiftradeAuth";
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
                options.SlidingExpiration = true;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;


                // Adjust SameSite setting for development environment
                if (environment.IsDevelopment())
                {
                    options.Cookie.SameSite = SameSiteMode.Lax;
                }
                else
                {
                    // In production, you might want to use a more restrictive setting
                    options.Cookie.SameSite = SameSiteMode.Strict;
                }
            });
        }


        private static void AddStorageOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FileStorageOptions>(x => configuration.GetSection("Storage").Bind(x));
        }

    }
}
