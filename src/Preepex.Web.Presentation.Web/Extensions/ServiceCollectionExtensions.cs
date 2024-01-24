
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Preepex.Common.Options;
using Preepex.Infrastructure.Extensions;
using System;

namespace Preepex.Web.Presentation.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureLayer(configuration);
            services.AddSharedServices();
            
            //services.AddApplicationCookie();

            //services.AddTransient<IAuthenticatedUserService, AuthenticatedUserService>();
            services.AddStorageOptions(configuration);

            services.AddValidatorsFromAssemblyContaining<Startup>();

        }

        private static void AddStorageOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FileStorageOptions>(x => configuration.GetSection("Storage").Bind(x));
        }
    }
}
